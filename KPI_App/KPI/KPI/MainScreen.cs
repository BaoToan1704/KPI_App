using System.Data;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace KPI
{
    public partial class MainScreen : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

        );
        bool mouseDown;
        private Point offSet;
        private string userMaNV;
        private string selectedMonth;
        private string connectionString = "Server=10.164.2.41;Database=kpi;User ID=toan;Password=123456;Charset=utf8mb4"; // Your DB connection string
        public MainScreen(string username, string selectedMonth)
        {
            InitializeComponent();
            this.userMaNV = username;
            this.selectedMonth = selectedMonth;
            //btnSelfMarking.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSelfMarking_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSelfMarking.Height;
            pnlNav.Top = btnSelfMarking.Top;
            pnlNav.Left = btnSelfMarking.Left;
            btnSelfMarking.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Tiêu chí cá nhân";
            this.pnlFormLoader.Controls.Clear();
            TieuChiCaNhanfrm tieuChiCaNhanfrm = new TieuChiCaNhanfrm(userMaNV, selectedMonth) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            tieuChiCaNhanfrm.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(tieuChiCaNhanfrm);
            tieuChiCaNhanfrm.Show();
            this.pnlFormLoader.ResumeLayout(false);

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnFind.Height;
            pnlNav.Top = btnFind.Top;
            pnlNav.Left = btnFind.Left;
            btnFind.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Tìm kiếm";
            this.pnlFormLoader.Controls.Clear();
            timKiemfrm tieuChiCaNhanfrm = new timKiemfrm(userMaNV, selectedMonth) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            timKiemfrm.ActiveForm.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(tieuChiCaNhanfrm);
            tieuChiCaNhanfrm.Show();
            this.pnlFormLoader.ResumeLayout(false);
        }

        private void btnLeaderMarking_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnLeaderMarking.Height;
            pnlNav.Top = btnLeaderMarking.Top;
            pnlNav.Left = btnLeaderMarking.Left;
            btnLeaderMarking.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Tổ trưởng chấm";
            this.pnlFormLoader.Controls.Clear();
            toTruongChamfrm tieuChiCaNhanfrm = new toTruongChamfrm(userMaNV, selectedMonth) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            toTruongChamfrm.ActiveForm.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(tieuChiCaNhanfrm);
            tieuChiCaNhanfrm.Show();
            this.pnlFormLoader.ResumeLayout(false);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnHistory.Height;
            pnlNav.Top = btnHistory.Top;
            pnlNav.Left = btnHistory.Left;
            btnHistory.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Lịch sử nộp KPI";
            this.pnlFormLoader.Controls.Clear();
            lichSufrm tieuChiCaNhanfrm = new lichSufrm(userMaNV) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            lichSufrm.ActiveForm.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(tieuChiCaNhanfrm);
            tieuChiCaNhanfrm.Show();
            this.pnlFormLoader.ResumeLayout(false);
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnGeneral.Height;
            pnlNav.Top = btnGeneral.Top;
            pnlNav.Left = btnGeneral.Left;
            btnGeneral.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Tổng hợp";
            this.pnlFormLoader.Controls.Clear();
            generalfrm generalfrm = new generalfrm(userMaNV, selectedMonth) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            generalfrm.ActiveForm.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(generalfrm);
            generalfrm.Show();
            this.pnlFormLoader.ResumeLayout(false);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnConfig.Height;
            pnlNav.Top = btnConfig.Top;
            pnlNav.Left = btnConfig.Left;
            btnConfig.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Điều chỉnh";
            this.pnlFormLoader.Controls.Clear();
            configAdminfrm configAdminfrm = new configAdminfrm(userMaNV) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            configAdminfrm.ActiveForm.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(configAdminfrm);
            configAdminfrm.Show();
            this.pnlFormLoader.ResumeLayout(false);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSetting.Height;
            pnlNav.Top = btnSetting.Top;
            pnlNav.Left = btnSetting.Left;
            btnSetting.BackColor = Color.FromArgb(46, 51, 73);

            // Logout 
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                LoginUI login = new LoginUI();
                login.Show();

            }
            else
            {
                btnSetting.BackColor = Color.FromArgb(24, 30, 54);
            }
        }

        private void btnSelfMarking_Leave(object sender, EventArgs e)
        {
            btnSelfMarking.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnFind_Leave(object sender, EventArgs e)
        {
            btnFind.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnLeaderMarking_Leave(object sender, EventArgs e)
        {
            btnLeaderMarking.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnHistory_Leave(object sender, EventArgs e)
        {
            btnHistory.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSetting_Leave(object sender, EventArgs e)
        {
            btnSetting.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnGeneral_Leave(object sender, EventArgs e)
        {
            btnGeneral.BackColor = Color.FromArgb(24, 30, 54);

        }
        private void btnConfig_Leave(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                btn_close.BackColor = Color.FromArgb(24, 30, 54);
            }

        }

        private void btn_close_MouseHover(object sender, EventArgs e)
        {

        }

        private void MainScreen_Load_1(object sender, EventArgs e)
        {
            // Display user's MaNV in label2
            string userName = GetUserName(userMaNV);
            if (!string.IsNullOrEmpty(userName))
            {
                label2.Text = userName; // Display name
            }
            else
            {
                label2.Text = userMaNV; // Fallback to ID if name not found
            }


            //lblTitle.Text = "Tiêu chí cá nhân";
            //this.pnlFormLoader.Controls.Clear();
            //TieuChiCaNhanfrm tieuChiCaNhanfrm = new TieuChiCaNhanfrm(userMaNV) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //tieuChiCaNhanfrm.FormBorderStyle = FormBorderStyle.None;
            //this.pnlFormLoader.Controls.Add(tieuChiCaNhanfrm);
            //tieuChiCaNhanfrm.Show();
            //this.pnlFormLoader.ResumeLayout(false);

            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblCalendar.Text = DateTime.Now.ToLongDateString();
            timer1.Start();

            CheckUserPermission();


        }

        private string GetUserName(string maNV)
        {
            string userName = null;
            string query = "SELECT HOTEN FROM user WHERE MaNV = @MaNV";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            userName = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tên người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return userName;
        }


        private void CheckUserPermission()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to check the CD of the logged-in user
                    string query = "SELECT CD FROM user WHERE MaNV = @MaNV";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", userMaNV);

                        object result = cmd.ExecuteScalar();

                        if (result != null && result.ToString() == "TT")
                        {
                            btnLeaderMarking.Visible = true; // Show button if CD = 'TT'
                            btnFind.Visible = true;
                            btnGeneral.Visible = true;
                            btnConfig.Visible = false;
                        }
                        else if (result != null && result.ToString() == "admin") // Show button if CD = 'admin'
                        {
                            btnFind.Visible = true;
                            btnConfig.Visible = true;
                            btnLeaderMarking.Visible = false;
                            btnGeneral.Visible = true;
                            btnLeaderMarking.Visible = false;
                            btnHistory.Visible = false;
                        }
                        else
                        {
                            btnLeaderMarking.Visible = false; // Hide button otherwise
                            btnFind.Visible = false;
                            btnGeneral.Visible = false;
                            btnConfig.Visible = false;
                            if (result != null && (result.ToString() == "TT" || result.ToString() == "GĐ"))
                            {
                                btnLeaderMarking.Visible = true; // Show button if CD = 'TT' or 'GĐ'
                                btnFind.Visible = true;
                                btnGeneral.Visible = true;
                            }
                            else
                            {
                                btnLeaderMarking.Visible = false; // Hide button otherwise
                                btnFind.Visible = false;
                                btnGeneral.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking user permission: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            // Maximize the form
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                Region = null;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Load MainScreen form
        }

        private void mouseDown_Event(object sender, MouseEventArgs e)
        {
            offSet.X = e.X;
            offSet.Y = e.Y;
            mouseDown = true;
        }

        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offSet.X, currentScreenPos.Y - offSet.Y);
            }
        }

        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnlFormLoader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}