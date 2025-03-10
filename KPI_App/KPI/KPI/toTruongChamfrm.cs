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
        private string selectedMonth;

        public toTruongChamfrm(string username, string selectedMonth)
        {
            this.userMaNV = username;
            this.selectedMonth = selectedMonth;
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
                    string query = "SELECT MaNV, HOTEN FROM user WHERE BP = @BP AND MaNV != @MaNV";
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

                    comboBox1.DisplayMember = "HOTEN";
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

        private void LoadEmployeeData(string maNV)
        {
            try
            {
                string bp;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string userQuery = "SELECT BP FROM user WHERE MaNV = @MaNV";
                    using (MySqlCommand cmd = new MySqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                        bp = cmd.ExecuteScalar()?.ToString();
                    }
                }

                DataTable dataTable = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string dataQuery = $"SELECT `TIÊU CHÍ`, TO_TRUONG_CHAM, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4` FROM {selectedMonth} WHERE MaNV = @MaNV";

                    using (MySqlCommand cmd = new MySqlCommand(dataQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }

                // Bind data to DataGridView
                dataGridView1.DataSource = dataTable;

                // Check if all LAN_PHAM_LOI values are 0
                bool allZero = dataTable.AsEnumerable().All(row => row["LAN_PHAM_LOI"] != DBNull.Value && Convert.ToInt32(row["LAN_PHAM_LOI"]) == 0);

                // Update label1 based on check
                if (allZero)
                {
                    label1.Text = "NV chưa chấm KPI";
                }
                else
                {
                    label1.Text = "";
                }

                // Remove existing column
                if (dataGridView1.Columns.Contains("TO_TRUONG_CHAM"))
                {
                    dataGridView1.Columns.Remove("TO_TRUONG_CHAM");
                }

                // Add a TextBoxColumn instead of a ComboBoxColumn
                var textBoxColumn = new DataGridViewTextBoxColumn
                {
                    Name = "TO_TRUONG_CHAM",
                    HeaderText = "TO_TRUONG_CHAM",
                    DataPropertyName = "TO_TRUONG_CHAM",
                };

                dataGridView1.Columns.Insert(1, textBoxColumn);

                // Make only LAN_PHAM_LOI editable
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = column.Name != "TO_TRUONG_CHAM";
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.Columns["TIÊU CHÍ"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Attach event for validation and movement
                dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
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
                    string updateQuery = $"UPDATE {selectedMonth} SET `TO_TRUONG_CHAM` = @TO_TRUONG_CHAM WHERE MaNV = @MaNV AND `TIÊU CHÍ` = @TIÊU_CHÍ";
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
                    // Query to update Total_NV based on LAN_PHAM_LOI values
                    string updateTotalQuery = $@"
                        UPDATE {selectedMonth} 
                        SET Total_TT = 
                            CASE 
                                WHEN TO_TRUONG_CHAM = 1 THEN `Lần 1`
                                WHEN TO_TRUONG_CHAM = 2 THEN `Lần 2`
                                WHEN TO_TRUONG_CHAM = 3 THEN `Lần 3`
                                WHEN TO_TRUONG_CHAM = 4 THEN `Lần 4`
                                ELSE 0 
                            END
                        WHERE MaNV = @MaNV";

                    using (MySqlCommand cmdTotal = new MySqlCommand(updateTotalQuery, conn))
                    {
                        cmdTotal.Parameters.AddWithValue("@MaNV", userMaNV);
                        cmdTotal.ExecuteNonQuery();
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

            if (dataGridView1.Columns.Contains("TO_TRUONG_CHAM") && e.ColumnIndex == dataGridView1.Columns["TO_TRUONG_CHAM"].Index && e.RowIndex >= 0)
            {
                // Reset colors for all rows
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(37, 42, 64);
                    row.DefaultCellStyle.ForeColor = Color.White;  // Default text color
                }

                // Change color of the selected row
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(34, 44, 89);
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
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress -= TextBox_KeyPress; // Remove previous handlers
                    textBox.KeyPress += TextBox_KeyPress; // Add KeyPress event to allow only numbers

                    textBox.KeyDown -= TextBox_KeyDown; // Remove previous handlers
                    textBox.KeyDown += TextBox_KeyDown; // Add KeyDown event for Enter & Down Arrow
                }
            }
        }
        // Allow only numeric input
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-numeric input
            }
        }

        // Move to next row when pressing Enter or Arrow Down
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true; // Prevent default behavior
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                if (rowIndex < dataGridView1.Rows.Count - 1)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex + 1].Cells["TO_TRUONG_CHAM"];
                }
            }
        }
    }
}
