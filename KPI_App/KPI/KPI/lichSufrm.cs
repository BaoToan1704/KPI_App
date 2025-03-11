using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace KPI
{
    public partial class lichSufrm : Form
    {
        private string userMaNV; // Logged-in user's MaNV
        private string connectionString = "Server=10.164.2.41;Database=kpi;User ID=toan;Password=123456;Charset=utf8mb4";

        public lichSufrm(string username)
        {
            this.userMaNV = username;
            InitializeComponent();
        }

        private void lichSufrm_Load(object sender, EventArgs e)
        {
            LoadMonth();
            comboBoxMonth.SelectedIndexChanged += comboBoxMonth_SelectedIndexChanged;

        }
        private void LoadMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add($"Tháng {i}");
            }
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonth.SelectedIndex != -1)
            {
                string selectedMonth = $"thang{comboBoxMonth.SelectedIndex + 1}"; // Convert to table name
                LoadData(selectedMonth);
            }
        }

        private void LoadData(string tableName)
        {
            string query = $"SELECT `TIÊU CHÍ`, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4` FROM {tableName} WHERE MaNV = @MaNV";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", userMaNV);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Optionally: Set word wrap for "TIÊU_CHÍ"
                dataGridView1.Columns["TIÊU CHÍ"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }
    }
}
