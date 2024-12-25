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
    public partial class LoginUI : Form
    {
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;";

        public LoginUI()
        {
            InitializeComponent();
            this.KeyPreview = true; // Enable key preview
            this.KeyDown += LoginUI_KeyDown; // Attach KeyDown event
            txtUser.KeyDown += txtUser_KeyDown;
            txtPass.KeyDown += txtPass_KeyDown;

        }
        private void LoginUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
        private void LoginUI_Load(object sender, EventArgs e)
        {
            // Load saved settings
            if (Properties.Settings.Default.RememberMe)
            {
                txtUser.Text = Properties.Settings.Default.SavedUsername;
                checkBox1.Checked = true; // Remember Me is checked
            }
            else
            {
                txtUser.Text = string.Empty;
                checkBox1.Checked = false;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Sai mã nhân viên hoặc mật khẩu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM user WHERE ID = @username AND PASS = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //MessageBox.Show("Đăng nhập thành công! Xin chào: " + reader["MANV"].ToString());
                                string userMaNV = reader["MANV"].ToString();


                                if (checkBox1.Checked)
                                {
                                    Properties.Settings.Default.RememberMe = true;
                                    Properties.Settings.Default.SavedUsername = username;
                                }
                                else
                                {
                                    Properties.Settings.Default.RememberMe = false;
                                    Properties.Settings.Default.SavedUsername = string.Empty;
                                }
                                Properties.Settings.Default.Save();

                                TieuChiCaNhanfrm tieuChiCaNhan = new TieuChiCaNhanfrm(userMaNV);
                                MainScreen mainScreen = new MainScreen(userMaNV);
                                timKiemfrm timKiemfrm = new timKiemfrm(userMaNV);
                                mainScreen.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Sai mã nhân viên hoặc mật khẩu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
