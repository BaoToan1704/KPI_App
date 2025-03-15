namespace KPI
{
    partial class TieuChiCaNhanfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TieuChiCaNhanfrm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel3 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblCongrat = new Label();
            pBoxCongrat = new PictureBox();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            btnUpdate = new Button();
            lblTitle = new Label();
            lblTotal = new Label();
            btnReset = new Button();
            label6 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pBoxCongrat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(lblCongrat);
            panel3.Controls.Add(pBoxCongrat);
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(12, 44);
            panel3.Name = "panel3";
            panel3.Size = new Size(1036, 562);
            panel3.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(848, 75);
            label5.Name = "label5";
            label5.Size = new Size(78, 24);
            label5.TabIndex = 13;
            label5.Text = "30 điểm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(848, 27);
            label4.Name = "label4";
            label4.Size = new Size(111, 24);
            label4.TabIndex = 12;
            label4.Text = "cộng không";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(848, 3);
            label2.Name = "label2";
            label2.Size = new Size(103, 24);
            label2.TabIndex = 11;
            label2.Text = "Tổng điểm";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(784, 3);
            label1.Name = "label1";
            label1.Size = new Size(67, 24);
            label1.TabIndex = 10;
            label1.Text = "Lưu ý:";
            // 
            // lblCongrat
            // 
            lblCongrat.AutoSize = true;
            lblCongrat.Font = new Font("Consolas", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCongrat.ForeColor = Color.FromArgb(43, 182, 115);
            lblCongrat.Location = new Point(277, 461);
            lblCongrat.Name = "lblCongrat";
            lblCongrat.Size = new Size(449, 32);
            lblCongrat.TabIndex = 10;
            lblCongrat.Text = "BẠN ĐÃ NỘP KPI THÁNG NÀY RỒI!";
            lblCongrat.Visible = false;
            // 
            // pBoxCongrat
            // 
            pBoxCongrat.Image = (Image)resources.GetObject("pBoxCongrat.Image");
            pBoxCongrat.Location = new Point(257, -22);
            pBoxCongrat.Name = "pBoxCongrat";
            pBoxCongrat.Size = new Size(480, 480);
            pBoxCongrat.SizeMode = PictureBoxSizeMode.StretchImage;
            pBoxCongrat.TabIndex = 10;
            pBoxCongrat.TabStop = false;
            pBoxCongrat.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(46, 51, 73);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(46, 51, 73);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(37, 42, 64);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(37, 42, 64);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(46, 51, 73);
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1036, 556);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.DataError += dataGridView1_DataError;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(158, 161, 176);
            label3.Location = new Point(-1, -40);
            label3.Name = "label3";
            label3.Size = new Size(238, 32);
            label3.TabIndex = 3;
            label3.Text = "Tiêu chí cá nhân";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 117, 214);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.Snow;
            btnUpdate.Location = new Point(12, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(111, 26);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "CẬP NHẬT";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(158, 161, 176);
            lblTitle.Location = new Point(308, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(137, 25);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "Tổng cộng: ";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(158, 161, 176);
            lblTotal.Location = new Point(441, 13);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(51, 25);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "100";
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(37, 42, 64);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.Snow;
            btnReset.Location = new Point(657, 12);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(111, 26);
            btnReset.TabIndex = 9;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(848, 51);
            label6.Name = "label6";
            label6.Size = new Size(82, 24);
            label6.TabIndex = 14;
            label6.Text = "vượt quá";
            // 
            // TieuChiCaNhanfrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1060, 643);
            Controls.Add(btnReset);
            Controls.Add(lblTotal);
            Controls.Add(lblTitle);
            Controls.Add(btnUpdate);
            Controls.Add(panel3);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TieuChiCaNhanfrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TieuChiCaNhanfrm";
            Load += TieuChiCaNhanfrm_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pBoxCongrat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private DataGridView dataGridView1;
        private Label label3;
        private Button btnUpdate;
        private Label lblTitle;
        private Label lblTotal;
        private Button btnReset;
        private PictureBox pBoxCongrat;
        private Label lblCongrat;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label6;
    }
}