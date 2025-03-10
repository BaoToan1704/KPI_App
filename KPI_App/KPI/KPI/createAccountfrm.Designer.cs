namespace KPI
{
    partial class createAccountfrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(createAccountfrm));
            txtID = new TextBox();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnLogin = new Button();
            label1 = new Label();
            bpComboBox = new ComboBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.BackColor = Color.FromArgb(46, 51, 73);
            txtID.BorderStyle = BorderStyle.None;
            txtID.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtID.ForeColor = Color.FromArgb(0, 117, 214);
            txtID.Location = new Point(63, 266);
            txtID.Name = "txtID";
            txtID.PlaceholderText = "Mã nhân viên";
            txtID.Size = new Size(205, 15);
            txtID.TabIndex = 17;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 117, 214);
            panel2.Location = new Point(32, 287);
            panel2.Name = "panel2";
            panel2.Size = new Size(236, 1);
            panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(32, 255);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_left_50;
            pictureBox2.Location = new Point(2, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 117, 214);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(24, 30, 54);
            btnLogin.Location = new Point(32, 394);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(236, 33);
            btnLogin.TabIndex = 19;
            btnLogin.Text = "Tạo tài khoản";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(32, 307);
            label1.Name = "label1";
            label1.Size = new Size(77, 18);
            label1.TabIndex = 21;
            label1.Text = "Bộ Phận:";
            // 
            // bpComboBox
            // 
            bpComboBox.BackColor = Color.FromArgb(24, 30, 54);
            bpComboBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bpComboBox.ForeColor = Color.White;
            bpComboBox.FormattingEnabled = true;
            bpComboBox.Location = new Point(135, 307);
            bpComboBox.Name = "bpComboBox";
            bpComboBox.Size = new Size(133, 24);
            bpComboBox.TabIndex = 22;
            bpComboBox.Text = "Chọn BP";
            // 
            // pictureBox3
            // 
            pictureBox3.ErrorImage = null;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(60, 44);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(203, 154);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 23;
            pictureBox3.TabStop = false;
            // 
            // createAccountfrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(308, 486);
            Controls.Add(pictureBox3);
            Controls.Add(bpComboBox);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Controls.Add(txtID);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "createAccountfrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo tài khoản";
            FormClosing += createAccountfrm_FormClosing;
            Load += createAccountfrm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtID;
        private Panel panel2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnLogin;
        private Label label1;
        private ComboBox bpComboBox;
        private PictureBox pictureBox3;
    }
}