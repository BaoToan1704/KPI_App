namespace KPI
{
    partial class configAdminfrm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configAdminfrm));
            dataGridView1 = new DataGridView();
            lblTitle = new Label();
            label1 = new Label();
            comboBoxNV = new ComboBox();
            comboBoxMonth = new ComboBox();
            btnFind = new Button();
            btnUpdate = new Button();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
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
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.ForeColor = Color.FromArgb(158, 161, 176);
            lblTitle.Name = "lblTitle";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(158, 161, 176);
            label1.Name = "label1";
            // 
            // comboBoxNV
            // 
            comboBoxNV.BackColor = Color.FromArgb(24, 30, 54);
            resources.ApplyResources(comboBoxNV, "comboBoxNV");
            comboBoxNV.ForeColor = Color.White;
            comboBoxNV.FormattingEnabled = true;
            comboBoxNV.Name = "comboBoxNV";
            // 
            // comboBoxMonth
            // 
            comboBoxMonth.BackColor = Color.FromArgb(24, 30, 54);
            resources.ApplyResources(comboBoxMonth, "comboBoxMonth");
            comboBoxMonth.ForeColor = Color.White;
            comboBoxMonth.FormattingEnabled = true;
            comboBoxMonth.Name = "comboBoxMonth";
            // 
            // btnFind
            // 
            btnFind.BackColor = Color.FromArgb(0, 117, 214);
            resources.ApplyResources(btnFind, "btnFind");
            btnFind.ForeColor = Color.Snow;
            btnFind.Name = "btnFind";
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 117, 214);
            resources.ApplyResources(btnUpdate, "btnUpdate");
            btnUpdate.ForeColor = Color.Snow;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(37, 42, 64);
            resources.ApplyResources(btnReset, "btnReset");
            btnReset.ForeColor = Color.Snow;
            btnReset.Name = "btnReset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click_1;
            // 
            // configAdminfrm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            Controls.Add(btnReset);
            Controls.Add(btnUpdate);
            Controls.Add(btnFind);
            Controls.Add(comboBoxMonth);
            Controls.Add(comboBoxNV);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "configAdminfrm";
            Load += configAdminfrm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblTitle;
        private Label label1;
        private ComboBox comboBoxNV;
        private ComboBox comboBoxMonth;
        private Button btnFind;
        private Button btnUpdate;
        private Button btnReset;
    }
}