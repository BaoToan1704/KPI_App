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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KPI
{
    public partial class TieuChiCaNhanfrm : Form
    {
        private string userMaNV;
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;Charset=utf8mb4"; // DB connection string
        private int maxTotal = 100;
        private int currentTotal = 100;

        private ComboBox activeComboBox = null;

        public TieuChiCaNhanfrm(string username)
        {
            InitializeComponent();
            this.userMaNV = username;
            lblTotal.Text = currentTotal.ToString();

        }

        private void TieuChiCaNhanfrm_Load(object sender, EventArgs e)
        {
            // Load data for the user
            LoadDataForUser(userMaNV);

            // Make cell enter and exit events for ComboBox
            dataGridView1.CellEnter += DataGridView1_CellEnter;
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
        }

        private void LoadDataForUser(string maNV)
        {
            try
            {
                string bp;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to get BP for the logged-in user
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

                    // Query to fetch data from both tables based on BP
                    string dataQuery = "SELECT `TIÊU CHÍ`, LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4` FROM t12 WHERE MaNV = @MaNV";
;

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

                // Add a ComboBoxColumn for LAN_PHAM_LOI
                var comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "LAN_PHAM_LOI",
                    HeaderText = "LAN_PHAM_LOI",
                    DataPropertyName = "LAN_PHAM_LOI", // Bind to the column in the DataTable
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                };

                // Replace existing column with ComboBoxColumn from 1 to 4
                dataGridView1.Columns.Remove("LAN_PHAM_LOI");
                dataGridView1.Columns.Insert(1, comboBoxColumn);

                // Set the ComboBoxColumn's DataSource
                comboBoxColumn.Items.AddRange(new string[] { "1", "2", "3", "4" });
                dataGridView1.DataSource = dataTable;


                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Name != "LAN_PHAM_LOI") // Make only LAN_PHAM_LOI editable
                    {
                        column.ReadOnly = true;
                    }
                }

                // Automatically adjust column widths
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Optionally: Set word wrap for "TIÊU_CHÍ"
                dataGridView1.Columns["TIÊU CHÍ"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dataGridView1.CellValueChanged += DataGridView1_CellValueChanged; // Attach event for value change

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
                    string updateQuery = "UPDATE t12 SET `LAN_PHAM_LOI` = @LAN_PHAM_LOI WHERE MaNV = @MaNV AND `TIÊU CHÍ` = @TIÊU_CHÍ";
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
                }
                // Hide the data grid view and show a success message
                dataGridView1.Visible = false;
                MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
