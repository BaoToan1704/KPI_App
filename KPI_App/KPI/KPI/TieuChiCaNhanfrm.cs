using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KPI
{
    public partial class TieuChiCaNhanfrm : Form
    {
        private string userMaNV;
        private string connectionString = "Server=10.164.2.41;Database=kpi;User ID=toan;Password=123456;Charset=utf8mb4"; // DB connection string
        private int maxTotal = 100;
        private int currentTotal = 100;
        private string selectedMonth;

        private ComboBox activeComboBox = null;

        public TieuChiCaNhanfrm(string username, string selectedMonth)
        {
            InitializeComponent();
            this.userMaNV = username;
            this.selectedMonth = selectedMonth;
            lblTotal.Text = currentTotal.ToString();
            
        }

        private void TieuChiCaNhanfrm_Load(object sender, EventArgs e)
        {
            // Load data for the user
            LoadDataForUser(userMaNV);

            // Make cell enter and exit events for ComboBox
            dataGridView1.CellEnter += DataGridView1_CellEnter;
            // Handle when the ComboBox is shown in DataGridView
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;

            // Handle when a ComboBox value changes
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;

        }

        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            var column = dataGridView1.Columns["LAN_PHAM_LOI"];
            if (column != null && e.ColumnIndex == column.Index && e.RowIndex >= 0)
            {
                dataGridView1.BeginEdit(true);
                ComboBox comboBox = dataGridView1.EditingControl as ComboBox;
                if (comboBox != null)
                {
                    comboBox.DroppedDown = true;
                    activeComboBox = comboBox;
                }
            }

            if (e.ColumnIndex == dataGridView1.Columns["LAN_PHAM_LOI"].Index && e.RowIndex >= 0)
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

        private void LoadDataForUser(string maNV)
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
                    string dataQuery = $"SELECT `TIÊU CHÍ`, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4` FROM {selectedMonth} WHERE MaNV = @MaNV";

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
                    dataGridView1.Visible = true;
                    btnUpdate.Visible = true;
                    btnReset.Visible = true;
                    lblTotal.Visible = true;
                    lblTitle.Visible = true;
                    pBoxCongrat.Visible = false;
                    lblCongrat.Visible = false;
                }
                else
                {
                    dataGridView1.Visible = false;
                    btnUpdate.Visible = false;
                    btnReset.Visible = false;
                    lblTotal.Visible = false;
                    lblTitle.Visible = false;
                    pBoxCongrat.Visible = true;
                    lblCongrat.Visible = true;
                }

                // Remove existing column
                if (dataGridView1.Columns.Contains("LAN_PHAM_LOI"))
                {
                    dataGridView1.Columns.Remove("LAN_PHAM_LOI");
                }

                // Add a TextBoxColumn instead of a ComboBoxColumn
                var textBoxColumn = new DataGridViewTextBoxColumn
                {
                    Name = "LAN_PHAM_LOI",
                    HeaderText = "LAN_PHAM_LOI",
                    DataPropertyName = "LAN_PHAM_LOI",
                };

                dataGridView1.Columns.Insert(1, textBoxColumn);

                // Make only LAN_PHAM_LOI editable
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = column.Name != "LAN_PHAM_LOI";
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.Columns["TIÊU CHÍ"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Attach event for validation and movement
                dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
                dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


        // Dictionary to track previous adjustments for each row
        private Dictionary<int, int> previousAdjustments = new Dictionary<int, int>();

        // Flag to indicate if XLKL is currently active
        private bool isXLKLActive = false;

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["LAN_PHAM_LOI"].Index && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;

                // Get selected ComboBox value
                string selectedValue = dataGridView1.Rows[rowIndex].Cells["LAN_PHAM_LOI"].Value?.ToString();

                // Default to 0 adjustment if ComboBox is empty or "0"
                if (string.IsNullOrEmpty(selectedValue) || selectedValue == "0")
                {
                    selectedValue = "0";
                }

                // Parse the selected value to determine the column
                if (int.TryParse(selectedValue, out int lanNumber) && lanNumber >= 0 && lanNumber <= 4)
                {
                    int previousAdjustment = 0;

                    // Retrieve the previous adjustment for this row
                    if (previousAdjustments.TryGetValue(rowIndex, out previousAdjustment))
                    {
                        // Undo the previous adjustment only if XLKL is not active
                        if (!isXLKLActive)
                        {
                            currentTotal = Math.Max(0, Math.Min(maxTotal, currentTotal - previousAdjustment));
                        }
                    }

                    // Determine the new adjustment
                    int newAdjustment = 0;
                    if (lanNumber > 0)
                    {
                        string columnName = $"Lần {lanNumber}";
                        object cellValue = dataGridView1.Rows[rowIndex].Cells[columnName].Value;

                        if (cellValue != null && cellValue.ToString() == "XLKL")
                        {
                            lblTotal.Text = "XLKL"; // Set total to XLKL
                            isXLKLActive = true;    // Activate XLKL mode
                            Console.WriteLine($"Row {rowIndex}: XLKL detected. Total updated to 'XLKL'.");
                            return;                 // Exit without applying numerical adjustments
                        }
                        else if (cellValue != null && int.TryParse(cellValue.ToString(), out int adjustment))
                        {
                            newAdjustment = adjustment;
                        }
                    }

                    // Apply the new adjustment only if XLKL is not active
                    if (!isXLKLActive)
                    {
                        currentTotal = Math.Max(0, Math.Min(maxTotal, currentTotal + newAdjustment));
                        lblTotal.Text = currentTotal.ToString();
                    }

                    // Update the previous adjustment for this row
                    previousAdjustments[rowIndex] = newAdjustment;

                    // Debugging output
                    Console.WriteLine($"Row {rowIndex}: Selected Value = {selectedValue}, Previous Adjustment = {previousAdjustment}, New Adjustment = {newAdjustment}, Current Total = {currentTotal}");
                }
                else
                {
                    // Reset XLKL mode if ComboBox is reset to 0
                    isXLKLActive = false;
                    lblTotal.Text = currentTotal.ToString();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Query to update the database
                    string updateQuery = $"UPDATE {selectedMonth} SET `LAN_PHAM_LOI` = @LAN_PHAM_LOI WHERE MaNV = @MaNV AND `TIÊU CHÍ` = @TIÊU_CHÍ";
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["LAN_PHAM_LOI"].Value != null)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@LAN_PHAM_LOI", row.Cells["LAN_PHAM_LOI"].Value);
                                cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                                cmd.Parameters.AddWithValue("@TIÊU_CHÍ", row.Cells["TIÊU CHÍ"].Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    // Query to update Total_NV based on LAN_PHAM_LOI values
                    string updateTotalQuery = $@"
                        UPDATE {selectedMonth} 
                        SET Total_NV = 
                            CASE 
                                WHEN LAN_PHAM_LOI = 1 THEN `Lần 1`
                                WHEN LAN_PHAM_LOI = 2 THEN `Lần 2`
                                WHEN LAN_PHAM_LOI = 3 THEN `Lần 3`
                                WHEN LAN_PHAM_LOI = 4 THEN `Lần 4`
                                ELSE 0 
                            END
                        WHERE MaNV = @MaNV";

                    using (MySqlCommand cmdTotal = new MySqlCommand(updateTotalQuery, conn))
                    {
                        cmdTotal.Parameters.AddWithValue("@MaNV", userMaNV);
                        cmdTotal.ExecuteNonQuery();
                    }
                }
                // Yes No message box, Bạn chỉ được nộp được 1 lần, bạn có chắc chắn muốn nộp không?
                DialogResult dialogResult = MessageBox.Show("Bạn chỉ được nộp được 1 lần mỗi tháng, bạn có chắc chắn muốn nộp không?", "Lưu", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataGridView1.Visible = false;
                    btnUpdate.Visible = false;
                    btnReset.Visible = false;
                    lblTotal.Visible = false;
                    lblTitle.Visible = false;
                    pBoxCongrat.Visible = true;
                    lblCongrat.Visible = true;
                    MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset all Lan_PHAM_LOI values to 0
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["LAN_PHAM_LOI"].Value = "0";
            }

            // Reset the total and clear all previous adjustments 
            currentTotal = maxTotal;
            lblTotal.Text = currentTotal.ToString();
            previousAdjustments.Clear();
            isXLKLActive = false;

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["LAN_PHAM_LOI"].Index)
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
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex + 1].Cells["LAN_PHAM_LOI"];
                }
            }
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
    }
}
