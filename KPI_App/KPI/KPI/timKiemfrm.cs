using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace KPI
{
    public partial class timKiemfrm : Form
    {
        private string userMaNV; // Logged-in user's MaNV
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;Charset=utf8mb4";
        private string selectedMonth;
        public timKiemfrm(string username, string selectedMonth)
        {
            this.userMaNV = username;
            InitializeComponent();
            this.selectedMonth = selectedMonth;
        }

        private void timKiemfrm_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadDefaultData();
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

                    // Populate ComboBox with employees in the same department (BP)
                    string query = "SELECT MaNV, HOTEN FROM user WHERE BP = @BP";
                    DataTable employeeTable = new DataTable();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BP", userBP);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(employeeTable);
                        }
                    }

                    comboBox1.DisplayMember = "HOTEN";
                    comboBox1.ValueMember = "MaNV";
                    comboBox1.DataSource = employeeTable;
                    comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

                    // If admin is logged in, show all employees in the ComboBox
                    if (userMaNV == "admin")
                    {
                        query = "SELECT MaNV, HOTEN FROM user";
                        employeeTable = new DataTable();
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                            {
                                adapter.Fill(employeeTable);
                            }
                        }
                        comboBox1.DisplayMember = "HOTEN";
                        comboBox1.ValueMember = "MaNV";
                        comboBox1.DataSource = employeeTable;
                        comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
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

                    string query = $"SELECT `TIÊU CHÍ`, TO_TRUONG_CHAM,LAN_PHAM_LOI, `Lần 1`, `Lần 2`, `Lần 3`, `Lần 4` FROM {selectedMonth} WHERE MaNV = @MaNV";
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Automatically adjust column widths
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Optionally: Set word wrap for "TIÊU_CHÍ"
            dataGridView1.Columns["TIÊU CHÍ"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                string selectedUser = comboBox1.SelectedValue?.ToString() ?? "UnknownUser";

                // Set font for the entire sheet
                Excel.Range entireSheet = worksheet.Cells;
                entireSheet.Font.Name = "Times New Roman";
                entireSheet.Font.Size = 13;

                // Set the header text
                worksheet.Cells[1, 1] = "LIÊN HIỆP HỢP TÁC XÃ THƯƠNG MẠI";
                worksheet.Cells[2, 1] = "THÀNH PHỐ HỒ CHÍ MINH";
                worksheet.Cells[3, 1] = "CÔNG TY TNHH SAIGON CO-OP FAIRPRICE";

                // Merge row A4 to F4 and set text
                Excel.Range titleRange = worksheet.Range["A4", "F4"];
                titleRange.Merge();
                titleRange.Value = "TIÊU CHÍ ĐÁNH GIÁ CÁ NHÂN ĐỐI VỚI CHỨC DANH: ";
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 18;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                titleRange.RowHeight = 40;

                // Employee information
                worksheet.Cells[5, 1] = $"Mã tổ trưởng (nhóm trưởng chấm điểm): {userMaNV}";
                Excel.Range highEmployeeLabel = (Excel.Range)worksheet.Cells[7, 1];
                highEmployeeLabel.Font.Bold = true;
                highEmployeeLabel.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                highEmployeeLabel.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(37, 150, 190));

                worksheet.Cells[6, 1] = $"Mã nhân viên: {selectedUser}";
                Excel.Range employeeLabel = (Excel.Range)worksheet.Cells[7, 1];
                employeeLabel.Font.Bold = true;
                employeeLabel.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                employeeLabel.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(37, 150, 190));

                // Section title before data
                worksheet.Cells[8, 1] = "1. ĐÁNH GIÁ TRONG KÌ";
                Excel.Range sectionTitle = (Excel.Range)worksheet.Cells[9, 1];
                sectionTitle.Font.Bold = true;

                // Set Column Headers (starting from A10)
                int startRow = 9;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    Excel.Range headerCell = (Excel.Range)worksheet.Cells[startRow, i + 1];
                    headerCell.Value = dataGridView1.Columns[i].HeaderText;
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    // Rename column headers from TO_TRUONG_CHAM to "Tổ trưởng chấm" and "LAN_PHAM_LOI" to "Lần phạm lỗi"
                    if (headerCell.Value.ToString() == "TO_TRUONG_CHAM")
                    {
                        headerCell.Value = "Tổ trưởng chấm";
                    }
                    else if (headerCell.Value.ToString() == "LAN_PHAM_LOI")
                    {
                        headerCell.Value = "Lần phạm lỗi";
                    }
                }

                // Set Data for DataGridView (starting from A11)
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        Excel.Range cell = (Excel.Range)worksheet.Cells[row + startRow + 1, col + 1];
                        cell.Value = dataGridView1.Rows[row].Cells[col].Value?.ToString();
                        cell.WrapText = true;
                        cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        // Manually set row height and width for each data cell
                        cell.RowHeight = 40;
                        cell.ColumnWidth = 118;
                    }
                }

                //// Manually set row height for all rows
                //worksheet.Rows.RowHeight = 40;
                //((Excel.Range)worksheet.Columns[1]).ColumnWidth = 118;

                // AutoFit other columns (except column A)
                for (int i = 2; i <= dataGridView1.Columns.Count; i++)
                {
                    ((Excel.Range)worksheet.Columns[i]).AutoFit();
                }

                // Hide microsoft excel warning window when saving the file with the same name
                excelApp.DisplayAlerts = false;

                // Save the Excel file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save an Excel File",
                    FileName = $"{selectedUser}_KPI.xlsx"

                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cleanup
                workbook.Close(false);
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {

        }
    }
}
