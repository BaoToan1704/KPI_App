namespace KPI
{
    partial class LoginUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUI));
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            panel5 = new Panel();
            panel6 = new Panel();
            panel7 = new Panel();
            panel8 = new Panel();
            btnLogin = new Button();
            checkBox1 = new CheckBox();
            txtUser = new TextBox();
            txtPass = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(38, 254);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(25, 25);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(38, 302);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(25, 25);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(0, 117, 214);
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(38, 333);
            panel5.Name = "panel5";
            panel5.Size = new Size(236, 1);
            panel5.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(0, 117, 214);
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(236, 1);
            panel6.TabIndex = 3;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(0, 117, 214);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(38, 285);
            panel7.Name = "panel7";
            panel7.Size = new Size(236, 1);
            panel7.TabIndex = 4;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(0, 117, 214);
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(236, 1);
            panel8.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 117, 214);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(24, 30, 54);
            btnLogin.Location = new Point(38, 387);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(236, 33);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = Color.WhiteSmoke;
            checkBox1.Location = new Point(38, 350);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(155, 20);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Ghi nhớ đăng nhập";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // txtUser
            // 
            txtUser.BackColor = Color.FromArgb(46, 51, 73);
            txtUser.BorderStyle = BorderStyle.None;
            txtUser.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUser.ForeColor = Color.FromArgb(0, 117, 214);
            txtUser.Location = new Point(69, 264);
            txtUser.Name = "txtUser";
            txtUser.PlaceholderText = "Mã nhân viên";
            txtUser.Size = new Size(205, 15);
            txtUser.TabIndex = 7;
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.FromArgb(46, 51, 73);
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass.ForeColor = Color.FromArgb(0, 117, 214);
            txtPass.Location = new Point(69, 312);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '•';
            txtPass.PlaceholderText = "Mật khẩu";
            txtPass.Size = new Size(205, 15);
            txtPass.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(60, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 154);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // LoginUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(308, 486);
            Controls.Add(pictureBox1);
            Controls.Add(txtPass);
            Controls.Add(txtUser);
            Controls.Add(checkBox1);
            Controls.Add(btnLogin);
            Controls.Add(panel7);
            Controls.Add(panel5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Off;
            MaximizeBox = false;
            Name = "LoginUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            Load += LoginUI_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Button btnLogin;
        private CheckBox checkBox1;
        private TextBox txtUser;
        private TextBox txtPass;
        private PictureBox pictureBox1;
    }
}