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
            pnlNav = new Panel();
            btnSetting = new Button();
            btnLeaderMarking = new Button();
            btnFind = new Button();
            btnSelfMarking = new Button();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblTitle = new Label();
            pnlFormLoader = new Panel();
            btn_close = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            lblTime = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            panel1.Controls.Add(pnlNav);
            panel1.Controls.Add(btnSetting);
            panel1.Controls.Add(btnLeaderMarking);
            panel1.Controls.Add(btnFind);
            panel1.Controls.Add(btnSelfMarking);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(186, 577);
            panel1.TabIndex = 0;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.FromArgb(0, 126, 249);
            pnlNav.Location = new Point(0, 150);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(3, 100);
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
            btnSetting.Location = new Point(0, 535);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(186, 42);
            btnSetting.TabIndex = 5;
            btnSetting.Text = "Cài đặt";
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
            btnLeaderMarking.ImageAlign = ContentAlignment.BottomLeft;
            btnLeaderMarking.Location = new Point(0, 228);
            btnLeaderMarking.Name = "btnLeaderMarking";
            btnLeaderMarking.Size = new Size(186, 42);
            btnLeaderMarking.TabIndex = 4;
            btnLeaderMarking.Text = "Tổ trưởng chấm";
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
            btnFind.ImageAlign = ContentAlignment.BottomLeft;
            btnFind.Location = new Point(0, 186);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(186, 42);
            btnFind.TabIndex = 2;
            btnFind.Text = "Tìm kiếm";
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
            btnSelfMarking.UseVisualStyleBackColor = true;
            btnSelfMarking.Click += btnSelfMarking_Click;
            btnSelfMarking.Leave += btnSelfMarking_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
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
            label2.Location = new Point(100, 85);
            label2.Name = "label2";
            label2.Size = new Size(49, 16);
            label2.TabIndex = 2;
            label2.Text = "MaNV";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 126, 149);
            label1.Location = new Point(34, 85);
            label1.Name = "label1";
            label1.Size = new Size(70, 16);
            label1.TabIndex = 1;
            label1.Text = "Xin chào,";
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
            pnlFormLoader.Dock = DockStyle.Bottom;
            pnlFormLoader.Location = new Point(186, 52);
            pnlFormLoader.Name = "pnlFormLoader";
            pnlFormLoader.Size = new Size(765, 525);
            pnlFormLoader.TabIndex = 2;
            // 
            // btn_close
            // 
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.ForeColor = Color.White;
            btn_close.Location = new Point(914, 12);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(25, 25);
            btn_close.TabIndex = 3;
            btn_close.Text = "X";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            btn_close.MouseHover += btn_close_MouseHover;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.FromArgb(158, 161, 176);
            lblTime.Location = new Point(456, 30);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(42, 16);
            lblTime.TabIndex = 5;
            lblTime.Text = "Time";
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(951, 577);
            Controls.Add(lblTime);
            Controls.Add(btn_close);
            Controls.Add(pnlFormLoader);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ";
            Load += MainScreen_Load_1;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label1;
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
    }
}
