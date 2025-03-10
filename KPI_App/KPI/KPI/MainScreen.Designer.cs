namespace KPI
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            panel1 = new Panel();
            btnConfig = new Button();
            btnGeneral = new Button();
            btnHistory = new Button();
            pnlNav = new Panel();
            btnSetting = new Button();
            btnLeaderMarking = new Button();
            btnFind = new Button();
            btnSelfMarking = new Button();
            panel2 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            lblTitle = new Label();
            pnlFormLoader = new Panel();
            lblCalendar = new Label();
            lblTime = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            btn_close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            btnMinimize = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlFormLoader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(btnConfig);
            panel1.Controls.Add(btnGeneral);
            panel1.Controls.Add(btnHistory);
            panel1.Controls.Add(pnlNav);
            panel1.Controls.Add(btnSetting);
            panel1.Controls.Add(btnLeaderMarking);
            panel1.Controls.Add(btnFind);
            panel1.Controls.Add(btnSelfMarking);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(186, 641);
            panel1.TabIndex = 0;
            // 
            // btnConfig
            // 
            btnConfig.Dock = DockStyle.Top;
            btnConfig.FlatAppearance.BorderSize = 0;
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfig.ForeColor = Color.FromArgb(0, 126, 149);
            btnConfig.Image = (Image)resources.GetObject("btnConfig.Image");
            btnConfig.ImageAlign = ContentAlignment.BottomLeft;
            btnConfig.Location = new Point(0, 354);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(186, 42);
            btnConfig.TabIndex = 9;
            btnConfig.Text = "Điều chỉnh";
            btnConfig.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            btnConfig.Leave += btnConfig_Leave;
            // 
            // btnGeneral
            // 
            btnGeneral.Dock = DockStyle.Top;
            btnGeneral.FlatAppearance.BorderSize = 0;
            btnGeneral.FlatStyle = FlatStyle.Flat;
            btnGeneral.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGeneral.ForeColor = Color.FromArgb(0, 126, 149);
            btnGeneral.Image = (Image)resources.GetObject("btnGeneral.Image");
            btnGeneral.ImageAlign = ContentAlignment.BottomLeft;
            btnGeneral.Location = new Point(0, 312);
            btnGeneral.Name = "btnGeneral";
            btnGeneral.Size = new Size(186, 42);
            btnGeneral.TabIndex = 8;
            btnGeneral.Text = "Tổng hợp";
            btnGeneral.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnGeneral.UseVisualStyleBackColor = true;
            btnGeneral.Click += btnGeneral_Click;
            btnGeneral.Leave += btnGeneral_Leave;
            // 
            // btnHistory
            // 
            btnHistory.Dock = DockStyle.Top;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistory.ForeColor = Color.FromArgb(0, 126, 149);
            btnHistory.Image = (Image)resources.GetObject("btnHistory.Image");
            btnHistory.ImageAlign = ContentAlignment.BottomLeft;
            btnHistory.Location = new Point(0, 270);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(186, 42);
            btnHistory.TabIndex = 7;
            btnHistory.Text = "Lịch sử";
            btnHistory.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            btnHistory.Leave += btnHistory_Leave;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.FromArgb(0, 126, 249);
            pnlNav.Location = new Point(0, 150);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(3, 203);
            pnlNav.TabIndex = 6;
            // 
            // btnSetting
            // 
            btnSetting.Dock = DockStyle.Bottom;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSetting.ForeColor = Color.FromArgb(0, 126, 149);
            btnSetting.ImageAlign = ContentAlignment.BottomLeft;
            btnSetting.Location = new Point(0, 599);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(186, 42);
            btnSetting.TabIndex = 5;
            btnSetting.Text = "Đăng xuất";
            btnSetting.UseVisualStyleBackColor = true;
            btnSetting.Click += btnSetting_Click;
            btnSetting.Leave += btnSetting_Leave;
            // 
            // btnLeaderMarking
            // 
            btnLeaderMarking.Dock = DockStyle.Top;
            btnLeaderMarking.FlatAppearance.BorderSize = 0;
            btnLeaderMarking.FlatStyle = FlatStyle.Flat;
            btnLeaderMarking.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLeaderMarking.ForeColor = Color.FromArgb(0, 126, 149);
            btnLeaderMarking.Image = (Image)resources.GetObject("btnLeaderMarking.Image");
            btnLeaderMarking.ImageAlign = ContentAlignment.BottomLeft;
            btnLeaderMarking.Location = new Point(0, 228);
            btnLeaderMarking.Name = "btnLeaderMarking";
            btnLeaderMarking.Size = new Size(186, 42);
            btnLeaderMarking.TabIndex = 4;
            btnLeaderMarking.Text = "Tổ trưởng chấm";
            btnLeaderMarking.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnLeaderMarking.UseVisualStyleBackColor = true;
            btnLeaderMarking.Click += btnLeaderMarking_Click;
            btnLeaderMarking.Leave += btnLeaderMarking_Leave;
            // 
            // btnFind
            // 
            btnFind.Dock = DockStyle.Top;
            btnFind.FlatAppearance.BorderSize = 0;
            btnFind.FlatStyle = FlatStyle.Flat;
            btnFind.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFind.ForeColor = Color.FromArgb(0, 126, 149);
            btnFind.Image = (Image)resources.GetObject("btnFind.Image");
            btnFind.ImageAlign = ContentAlignment.BottomLeft;
            btnFind.Location = new Point(0, 186);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(186, 42);
            btnFind.TabIndex = 2;
            btnFind.Text = "Tìm kiếm";
            btnFind.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            btnFind.Leave += btnFind_Leave;
            // 
            // btnSelfMarking
            // 
            btnSelfMarking.Dock = DockStyle.Top;
            btnSelfMarking.FlatAppearance.BorderSize = 0;
            btnSelfMarking.FlatStyle = FlatStyle.Flat;
            btnSelfMarking.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelfMarking.ForeColor = Color.FromArgb(0, 126, 149);
            btnSelfMarking.Image = (Image)resources.GetObject("btnSelfMarking.Image");
            btnSelfMarking.ImageAlign = ContentAlignment.BottomLeft;
            btnSelfMarking.Location = new Point(0, 144);
            btnSelfMarking.Name = "btnSelfMarking";
            btnSelfMarking.Size = new Size(186, 42);
            btnSelfMarking.TabIndex = 1;
            btnSelfMarking.Text = "Tiêu chí cá nhân";
            btnSelfMarking.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSelfMarking.UseVisualStyleBackColor = true;
            btnSelfMarking.Click += btnSelfMarking_Click;
            btnSelfMarking.Leave += btnSelfMarking_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(186, 144);
            panel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 126, 149);
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(49, 16);
            label2.TabIndex = 2;
            label2.Text = "MaNV";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(40, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(158, 161, 176);
            lblTitle.Location = new Point(201, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tiêu chí cá nhân";
            // 
            // pnlFormLoader
            // 
            pnlFormLoader.Controls.Add(lblCalendar);
            pnlFormLoader.Controls.Add(lblTime);
            pnlFormLoader.Controls.Add(pictureBox2);
            pnlFormLoader.Location = new Point(186, 52);
            pnlFormLoader.Name = "pnlFormLoader";
            pnlFormLoader.Size = new Size(981, 589);
            pnlFormLoader.TabIndex = 2;
            pnlFormLoader.Paint += pnlFormLoader_Paint;
            // 
            // lblCalendar
            // 
            lblCalendar.AutoSize = true;
            lblCalendar.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCalendar.ForeColor = Color.FromArgb(158, 161, 176);
            lblCalendar.Location = new Point(331, 352);
            lblCalendar.Name = "lblCalendar";
            lblCalendar.Size = new Size(60, 25);
            lblCalendar.TabIndex = 6;
            lblCalendar.Text = "Time";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(367, 306);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(108, 46);
            lblTime.TabIndex = 5;
            lblTime.Text = "Time";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(322, 98);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(256, 256);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // panel3
            // 
            panel3.Location = new Point(0, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(1070, 36);
            panel3.TabIndex = 8;
            panel3.Paint += panel3_Paint;
            panel3.MouseDown += mouseDown_Event;
            panel3.MouseMove += mouseMove_Event;
            panel3.MouseUp += mouseUp_Event;
            // 
            // btn_close
            // 
            btn_close.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.ForeColor = Color.White;
            btn_close.Location = new Point(1148, 1);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(30, 30);
            btn_close.TabIndex = 3;
            btn_close.Text = "X";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            btn_close.MouseHover += btn_close_MouseHover;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1112, 1);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(30, 30);
            btnMinimize.TabIndex = 7;
            btnMinimize.Text = "─";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1179, 643);
            Controls.Add(btnMinimize);
            Controls.Add(btn_close);
            Controls.Add(pnlFormLoader);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ";
            Load += MainScreen_Load_1;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlFormLoader.ResumeLayout(false);
            pnlFormLoader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label2;
        private Button btnSelfMarking;
        private Button btnSetting;
        private Button btnLeaderMarking;
        private Button btnFind;
        private Panel pnlNav;
        private Label lblTitle;
        private Panel pnlFormLoader;
        private Button btn_close;
        private System.Windows.Forms.Timer timer1;
        private Label lblTime;
        private Button btnHistory;
        private Button btnMinimize;
        private Label lblCalendar;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Button btnGeneral;
        private Button btnConfig;
    }
}
