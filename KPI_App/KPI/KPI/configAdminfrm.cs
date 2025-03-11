using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KPI
{
    public partial class configAdminfrm : Form
    {
        private string userMaNV;
        private string connectionString = "Server=10.164.2.41;Database=kpi;User ID=toan;Password=123456;Charset=utf8mb4";

        public configAdminfrm(string username)
        {
            this.userMaNV = username;
            InitializeComponent();
        }

        private void configAdminfrm_Load(object sender, EventArgs e)
        {
            LoadMonths();
            LoadEmployees();
        }

        private void LoadMonths()
        {
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add($"Tháng {i}");
            }
        }

        private void LoadEmployees()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = userMaNV == "admin" ? "SELECT MaNV FROM user" : "SELECT MaNV FROM user WHERE MaNV = @MaNV";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (userMaNV != "admin")
                            cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxNV.Items.Add(reader["MaNV"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            if (comboBoxMonth.SelectedItem == null || comboBoxNV.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedMonth = "thang" + comboBoxMonth.SelectedItem.ToString().Split(' ')[1];
            string selectedMaNV = comboBoxNV.SelectedItem.ToString();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = userMaNV == "admin" && selectedMaNV == "admin" ? $"SELECT MaNV, `TIÊU CHÍ`, TO_TRUONG_CHAM, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4` FROM {selectedMonth}" : $"SELECT * FROM {selectedMonth} WHERE MaNV = @MaNV";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (userMaNV != "admin" || selectedMaNV != "admin")
                            cmd.Parameters.AddWithValue("@MaNV", selectedMaNV);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                            dataGridView1.ReadOnly = false; // Make editable
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (comboBoxMonth.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedMonth = "thang" + comboBoxMonth.SelectedItem.ToString().Split(' ')[1];
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        string updateQuery = $"UPDATE {selectedMonth} SET COLUMN_NAME = @Value WHERE MaNV = @MaNV";
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Value", row.Cells["COLUMN_NAME"].Value);
                            cmd.Parameters.AddWithValue("@MaNV", row.Cells["MaNV"].Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            comboBoxMonth.SelectedIndex = -1;
            comboBoxNV.SelectedIndex = -1;

            // Reset all the data in the datagridview to the original data
            LoadEmployees();
        }
    }
}
