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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KPI
{
    public partial class LoginUI : Form
    {
        private string connectionString = "Server=10.164.2.41;Database=kpi;User ID=toan;Password=123456;";

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

            // Focus on the second textbox
            this.ActiveControl = txtPass;
            LoadMonth();

        }
        private void LoadMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add($"Tháng {i}");
            }

            int currentMonth = DateTime.Now.Month; // Get current month as integer (1-12)
            comboBoxMonth.SelectedIndex = currentMonth - 1; // Set index (0-based)
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUser.Text;
            string password = txtPass.Text;

            if (comboBoxMonth.SelectedIndex == -1 || comboBoxMonth.SelectedIndex == null)
            {
                MessageBox.Show("Vui lòng chọn tháng.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                                string selectedMonth = "thang" + comboBoxMonth.SelectedItem.ToString().Split(' ')[1];



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

                                TieuChiCaNhanfrm tieuChiCaNhan = new TieuChiCaNhanfrm(userMaNV, selectedMonth);
                                MainScreen mainScreen = new MainScreen(userMaNV, selectedMonth);
                                timKiemfrm timKiemfrm = new timKiemfrm(userMaNV, selectedMonth);
                                toTruongChamfrm toTruongChamfrm = new toTruongChamfrm(userMaNV, selectedMonth);
                                lichSufrm lichSufrm = new lichSufrm(userMaNV);
                                configAdminfrm configAdminfrm = new configAdminfrm(userMaNV);
                                generalfrm generalfrm = new generalfrm(userMaNV, selectedMonth);

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

        private void LoginUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void createAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            createAccountfrm createAccountfrm = new createAccountfrm();
            createAccountfrm.Show();
            this.Hide();
        }   
    }
}
