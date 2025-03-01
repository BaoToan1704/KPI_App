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

namespace KPI
{
    public partial class toTruongChamfrm : Form
    {
        private string userMaNV; // Logged-in user's MaNV
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;Charset=utf8mb4";
        private ComboBox activeComboBox = null;

        public toTruongChamfrm(string username)
        {
            this.userMaNV = username;
            InitializeComponent();
        }

        private void toTruongChamfrm_Load(object sender, EventArgs e)
        {
            //LoadDefaultData();
            LoadComboBoxData();
            dataGridView1.CellEnter += dataGridView1_CellEnter;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            // Handle when the ComboBox is shown in DataGridView
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;

            // Handle when a ComboBox value changes
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
        }

        private void LoadComboBoxData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Fetch the department (BP) of the logged-in user
                    string userBP = GetUserBP(conn);

                    if (string.IsNullOrEmpty(userBP))
                    {
                        MessageBox.Show("Error retrieving user's department (BP).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Populate ComboBox with employees in the same department (BP), excluding the logged-in user
                    string query = "SELECT MaNV FROM user WHERE BP = @BP AND MaNV != @MaNV";
                    DataTable employeeTable = new DataTable();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BP", userBP);
                        cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(employeeTable);
                        }
                    }

                    comboBox1.DisplayMember = "MaNV";
                    comboBox1.ValueMember = "MaNV";
                    comboBox1.DataSource = employeeTable;

                    // Ensure the event is only attached once
                    comboBox1.SelectedIndexChanged -= ComboBox1_SelectedIndexChanged;
                    comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

                    // Automatically select the first employee and load their data
                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0; // Select first employee in the ComboBox
                        string selectedMaNV = comboBox1.SelectedValue.ToString();
                        LoadEmployeeData(selectedMaNV); // Load first employee's data
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ComboBox data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                string selectedMaNV = comboBox1.SelectedValue.ToString();
                LoadEmployeeData(selectedMaNV);
            }
        }

        private void LoadDefaultData()
        {
            // Load the logged-in user's data by default
            LoadEmployeeData(userMaNV);
        }

        private void LoadEmployeeData(string maNV)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT `TIÊU CHÍ`, TO_TRUONG_CHAM, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4` FROM t12 WHERE MaNV = @MaNV";
                    DataTable dataTable = new DataTable();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    dataGridView1.DataSource = dataTable;

                    // Add a combobox column for "TO_TRUONG_CHAM"
                    var comboBoxColumn = new DataGridViewComboBoxColumn
                    {
                        Name = "TO_TRUONG_CHAM",
                        HeaderText = "TO_TRUONG_CHAM",
                        DataPropertyName = "TO_TRUONG_CHAM", // Bind to the column in the DataTable
                        DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                    };

                    // Replace existing column with ComboBoxColumn from 1 to 4
                    dataGridView1.Columns.Remove("TO_TRUONG_CHAM");
                    dataGridView1.Columns.Insert(1, comboBoxColumn);

                    // Set the ComboBoxColumn's DataSource
                    comboBoxColumn.Items.AddRange(new string[] { "1", "2", "3", "4" });
                    dataGridView1.DataSource = dataTable;

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        if (column.Name != "TO_TRUONG_CHAM") // Make only TO_TRUONG_CHAM editable
                        {
                            column.ReadOnly = true;
                        }
                    }

                    // Automatically adjust column widths
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    // Optionally: Set word wrap for "TIÊU_CHÍ"
                    dataGridView1.Columns["TIÊU CHÍ"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    dataGridView1.CellValueChanged += dataGridView1_CellValueChanged; // Attach event for value change

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string GetUserBP(MySqlConnection conn)
        {
            try
            {
                string query = "SELECT BP FROM user WHERE MaNV = @MaNV";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving BP: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Query to update the database
                    string updateQuery = "UPDATE t12 SET `TO_TRUONG_CHAM` = @TO_TRUONG_CHAM WHERE MaNV = @MaNV AND `TIÊU CHÍ` = @TIÊU_CHÍ";
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["TO_TRUONG_CHAM"].Value != null)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@TO_TRUONG_CHAM", row.Cells["TO_TRUONG_CHAM"].Value);
                                cmd.Parameters.AddWithValue("@MaNV", comboBox1.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@TIÊU_CHÍ", row.Cells["TIÊU CHÍ"].Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                // Hide the data grid view and show a success message
                // dataGridView1.Visible = false;
                MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset all TO_TRUONG_CHAM values to 0
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["TO_TRUONG_CHAM"].Value = "0";
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewComboBoxColumn)
                {
                    dataGridView1.BeginEdit(true);
                    var comboBox = dataGridView1.EditingControl as ComboBox;
                    if (comboBox != null)
                    {
                        comboBox.DroppedDown = true; // Automatically open dropdown on entry
                    }
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["TO_TRUONG_CHAM"].Index && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;

                // Get selected ComboBox value
                string selectedValue = dataGridView1.Rows[rowIndex].Cells["TO_TRUONG_CHAM"].Value?.ToString();

                // Default to 0 adjustment if ComboBox is empty or "0"
                if (string.IsNullOrEmpty(selectedValue) || selectedValue == "0")
                {
                    selectedValue = "0";
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
            if (e.Context == DataGridViewDataErrorContexts.Commit ||
                e.Context == DataGridViewDataErrorContexts.CurrentCellChange ||
                e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                Console.WriteLine($"Data Error at Row {e.RowIndex}, Column {e.ColumnIndex}: {e.Exception.Message}");

                e.ThrowException = false;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                // Commit the change immediately
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Move focus to avoid needing an extra click
                dataGridView1.EndEdit();
                dataGridView1.Focus();
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["TO_TRUONG_CHAM"].Index)
            {
                ComboBox comboBox = e.Control as ComboBox;
                if (comboBox != null)
                {
                    // Open the dropdown immediately
                    comboBox.DroppedDown = true;
                }
            }
        }
    }
}
