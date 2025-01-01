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
        private string userMaNV;
        //private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;Charset=utf8mb4"; // Your DB connection string
        public MainScreen(string username)
        {
            InitializeComponent();
            this.userMaNV = username;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
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
            TieuChiCaNhanfrm tieuChiCaNhanfrm = new TieuChiCaNhanfrm(userMaNV) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
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
            timKiemfrm tieuChiCaNhanfrm = new timKiemfrm(userMaNV) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
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
            toTruongChamfrm tieuChiCaNhanfrm = new toTruongChamfrm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            toTruongChamfrm.ActiveForm.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(tieuChiCaNhanfrm);
            tieuChiCaNhanfrm.Show();
            this.pnlFormLoader.ResumeLayout(false);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSetting.Height;
            pnlNav.Top = btnSetting.Top;
            pnlNav.Left = btnSetting.Left;
            btnSetting.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Cài đặt";
            this.pnlFormLoader.Controls.Clear();
            caiDatfrm tieuChiCaNhanfrm = new caiDatfrm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            caiDatfrm.ActiveForm.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(tieuChiCaNhanfrm);
            tieuChiCaNhanfrm.Show();
            this.pnlFormLoader.ResumeLayout(false);
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

        private void btnSetting_Leave(object sender, EventArgs e)
        {
            btnSetting.BackColor = Color.FromArgb(24, 30, 54);
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
            label2.Text = userMaNV;

            //lblTitle.Text = "Tiêu chí cá nhân";
            //this.pnlFormLoader.Controls.Clear();
            //TieuChiCaNhanfrm tieuChiCaNhanfrm = new TieuChiCaNhanfrm(userMaNV) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //tieuChiCaNhanfrm.FormBorderStyle = FormBorderStyle.None;
            //this.pnlFormLoader.Controls.Add(tieuChiCaNhanfrm);
            //tieuChiCaNhanfrm.Show();
            //this.pnlFormLoader.ResumeLayout(false);

            lblTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
    }
}