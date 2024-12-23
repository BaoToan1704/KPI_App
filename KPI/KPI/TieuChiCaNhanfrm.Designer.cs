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
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            btnUpdate = new Button();
            lblTitle = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Location = new Point(12, 44);
            panel3.Name = "panel3";
            panel3.Size = new Size(709, 443);
            panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(709, 469);
            dataGridView1.TabIndex = 0;
            dataGridView1.DataError += dataGridView1_DataError;
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
            btnUpdate.Location = new Point(24, 12);
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
            lblTitle.Location = new Point(439, 12);
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
            lblTotal.Location = new Point(572, 12);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(51, 25);
            lblTotal.TabIndex = 8;
            lblTotal.Text = "100";
            // 
            // TieuChiCaNhanfrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(733, 525);
            Controls.Add(lblTotal);
            Controls.Add(lblTitle);
            Controls.Add(btnUpdate);
            Controls.Add(dataGridView1);
            Controls.Add(panel3);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TieuChiCaNhanfrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TieuChiCaNhanfrm";
            Load += TieuChiCaNhanfrm_Load;
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
    }
}