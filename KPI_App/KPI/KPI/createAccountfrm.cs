using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KPI
{
    public partial class createAccountfrm : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;";

        public createAccountfrm()
        {
            InitializeComponent();
            LoadBPComboBox(); // Load BP options into the ComboBox
        }

        private void createAccountfrm_Load(object sender, EventArgs e)
        {
            bpComboBox.SelectedIndex = 0; // Set default selection
        }

        private void LoadBPComboBox()
        {
            bpComboBox.Items.AddRange(new string[] { "AN", "BT", "NH-HMP", "NH-TPTS", "NH-DDMM", "NH-TPCN", "KHO", "MAR", "TN", "IT" });
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void InsertIntoTable(string manv, string bp, string tieuchi, string lanPhamLoi, string lan1, string lan2, string lan3, string lan4)
        {
            string insertQuery = @"
                INSERT INTO thang12 (MANV, BP, `TIÊU CHÍ`, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4`)
                VALUES (@MANV, @BP, @TIÊU_CHÍ, @LAN_PHAM_LOI, @Lần_1, @Lần_2, @Lần_3, @Lần_4)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MANV", manv);
                    cmd.Parameters.AddWithValue("@BP", bp);
                    cmd.Parameters.AddWithValue("@TIÊU_CHÍ", tieuchi);
                    cmd.Parameters.AddWithValue("@LAN_PHAM_LOI", lanPhamLoi);
                    cmd.Parameters.AddWithValue("@Lần_1", lan1);
                    cmd.Parameters.AddWithValue("@Lần_2", lan2);
                    cmd.Parameters.AddWithValue("@Lần_3", lan3);
                    cmd.Parameters.AddWithValue("@Lần_4", lan4);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginUI loginUI = new LoginUI();
            loginUI.Show();
            this.Hide();
        }

        private bool IsEmployeeRegistered(string manv)
        {
            string checkQuery = "SELECT COUNT(*) FROM thang12 WHERE MANV = @MANV";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MANV", manv);
                    int count = Convert.ToInt32(cmd.ExecuteScalar()); // Get the count of records

                    return count > 0; // If count > 0, the MANV exists
                }
            }
        }


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string manv = txtID.Text.Trim();
            string bp = bpComboBox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(manv) || string.IsNullOrEmpty(bp))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên và chọn bộ phận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the MANV already exists
            if (IsEmployeeRegistered(manv))
            {
                MessageBox.Show("Mã nhân viên đã được tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Query to check BP in diem_cong_table and diem_tru_table
            string query = @"
                SELECT `TIÊU CHÍ`, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4`, BP 
                FROM diem_cong_table 
                WHERE BP = @BP OR BP IS NULL
                UNION
                SELECT `TIÊU CHÍ`, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4`, BP 
                FROM diem_tru_table 
                WHERE BP = @BP OR BP IS NULL";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BP", bp);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tieuchi = reader["TIÊU CHÍ"].ToString();
                            string lanPhamLoi = reader["LAN_PHAM_LOI"].ToString();
                            string lan1 = reader["Lần 1"].ToString();
                            string lan2 = reader["Lần 2"].ToString();
                            string lan3 = reader["Lần 3"].ToString();
                            string lan4 = reader["Lần 4"].ToString();

                            // Insert into thang12 table
                            InsertIntoTable(manv, bp, tieuchi, lanPhamLoi, lan1, lan2, lan3, lan4);
                        }
                    }
                }
                MessageBox.Show("Tài khoản được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createAccountfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
