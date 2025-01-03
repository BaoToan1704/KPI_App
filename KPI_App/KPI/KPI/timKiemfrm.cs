using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KPI
{
    public partial class timKiemfrm : Form
    {
        private string userMaNV; // Logged-in user's MaNV
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;Charset=utf8mb4";

        public timKiemfrm(string username)
        {
            this.userMaNV = username;
            InitializeComponent();
        }

        private void timKiemfrm_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadDefaultData();
        }

        private void LoadComboBoxData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Fetch the department (BP) of the logged-in user
                    string userBP = GetUserBP(conn);

                    if (string.IsNullOrEmpty(userBP))
                    {
                        MessageBox.Show("Error retrieving user's department (BP).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Populate ComboBox with employees in the same department (BP)
                    string query = "SELECT MaNV FROM user WHERE BP = @BP";
                    DataTable employeeTable = new DataTable();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BP", userBP);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(employeeTable);
                        }
                    }

                    comboBox1.DisplayMember = "MaNV";
                    comboBox1.ValueMember = "MaNV";
                    comboBox1.DataSource = employeeTable;
                    comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ComboBox data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                string selectedMaNV = comboBox1.SelectedValue.ToString();
                LoadEmployeeData(selectedMaNV);
            }
        }

        private void LoadDefaultData()
        {
            // Load the logged-in user's data by default
            LoadEmployeeData(userMaNV);
        }

        private void LoadEmployeeData(string maNV)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM t12 WHERE MaNV = @MaNV";
                    DataTable dataTable = new DataTable();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetUserBP(MySqlConnection conn)
        {
            try
            {
                string query = "SELECT BP FROM user WHERE MaNV = @MaNV";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving BP: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
