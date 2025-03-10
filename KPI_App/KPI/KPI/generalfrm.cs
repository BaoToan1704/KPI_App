using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;


namespace KPI
{
    public partial class generalfrm : Form
    {
        private string userMaNV; // Logged-in user's MaNV
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;Charset=utf8mb4";
        private string selectedMonth;

        public generalfrm(string username, string selectedMonth)
        {
            this.userMaNV = username;
            InitializeComponent();
            this.selectedMonth = selectedMonth;
        }

        private void generalfrm_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }

        private void LoadTableData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get the user's BP (Department)
                    string userBP = GetUserBP(conn);

                    if (string.IsNullOrEmpty(userBP))
                    {
                        MessageBox.Show("Error retrieving user's BP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check if Total_NV and Total_TT are null, set to 0
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["TCCN"].Value == DBNull.Value)
                        {
                            row.Cells["TCCN"].Value = 0;
                        }
                        if (row.Cells["BĐH"].Value == DBNull.Value)
                        {
                            row.Cells["BĐH"].Value = 0;
                        }
                    }

                    // Query to join tong_ket_table with selectedMonth and sum Total_NV and Total_TT
                    string query;
                    if (userBP == "GĐ")
                    {
                        query = $@"
                    SELECT tkt.MANV, tkt.HOTEN, tkt.CD, tkt.BP,
                        COALESCE(SUM(CAST({selectedMonth}.Total_NV AS SIGNED)), 0) + 100 AS TCCN,
                        COALESCE(SUM(CAST({selectedMonth}.Total_TT AS SIGNED)), 0) + 100 AS BĐH,
                        tkt.HĐTĐ, tkt.`KPI CHUNG`, tkt.`TỔNG ĐIỂM`, tkt.`XẾP LOẠI`, tkt.`GHI CHÚ`
                    FROM tong_ket_table tkt
                    LEFT JOIN {selectedMonth} ON tkt.MANV = {selectedMonth}.MANV
                    GROUP BY tkt.MANV;";
                    }
                    else
                    {
                        query = $@"
                    SELECT tkt.MANV, tkt.HOTEN, tkt.CD, tkt.BP,
                        COALESCE(SUM(CAST({selectedMonth}.Total_NV AS SIGNED)), 0) + 100 AS TCCN,
                        COALESCE(SUM(CAST({selectedMonth}.Total_TT AS SIGNED)), 0) + 100 AS BĐH,
                        tkt.HĐTĐ, tkt.`KPI CHUNG`, tkt.`TỔNG ĐIỂM`, tkt.`XẾP LOẠI`, tkt.`GHI CHÚ`
                    FROM tong_ket_table tkt
                    LEFT JOIN {selectedMonth} ON tkt.MANV = {selectedMonth}.MANV
                    WHERE tkt.BP = @BP
                    GROUP BY tkt.MANV;";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (userBP != "GĐ")
                        {
                            cmd.Parameters.AddWithValue("@BP", userBP);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }

                    // If TCCN or BĐH > 100, set to 100 or if < 0, set to 0
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["TCCN"].Value) > 100)
                        {
                            row.Cells["TCCN"].Value = 100;
                        }
                        else if (Convert.ToInt32(row.Cells["TCCN"].Value) < 0)
                        {
                            row.Cells["TCCN"].Value = 0;
                        }
                        if (Convert.ToInt32(row.Cells["BĐH"].Value) > 100)
                        {
                            row.Cells["BĐH"].Value = 100;
                        }
                        else if (Convert.ToInt32(row.Cells["BĐH"].Value) < 0)
                        {
                            row.Cells["BĐH"].Value = 0;
                        }
                    }
                }

                // Adjust column formatting
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FormatDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns["MANV"].HeaderText = "Mã NV";
                dataGridView1.Columns["HOTEN"].HeaderText = "Họ Tên";
                dataGridView1.Columns["CD"].HeaderText = "Chức Danh";
                dataGridView1.Columns["BP"].HeaderText = "Bộ Phận";
                dataGridView1.Columns["TCCN"].HeaderText = "TCCN";
                dataGridView1.Columns["BĐH"].HeaderText = "BĐH";
                dataGridView1.Columns["HĐTĐ"].HeaderText = "HĐTĐ";
                dataGridView1.Columns["KPI CHUNG"].HeaderText = "KPI Chung";
                dataGridView1.Columns["TỔNG ĐIỂM"].HeaderText = "Tổng Điểm";
                dataGridView1.Columns["XẾP LOẠI"].HeaderText = "Xếp Loại";
                dataGridView1.Columns["GHI CHÚ"].HeaderText = "Ghi Chú";

                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
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

                // Set font for the entire sheet
                Excel.Range entireSheet = worksheet.Cells;
                entireSheet.Font.Name = "Times New Roman";
                entireSheet.Font.Size = 13;


                // Merge row A4 to F4 and set text
                Excel.Range titleRange = worksheet.Range["A1", "F1"];
                titleRange.Merge();
                titleRange.Value = "TỔNG HỢP ĐÁNH GIÁ KPI THÁNG: ";
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 20;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                titleRange.RowHeight = 40;

                
                // Set Column Headers (starting from A10)
                int startRow = 2;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    Excel.Range headerCell = (Excel.Range)worksheet.Cells[startRow, i + 1];
                    headerCell.Value = dataGridView1.Columns[i].HeaderText;
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    if (headerCell.Value.ToString() == "TCCN")
                    {
                        headerCell.Value = "Tiêu Chí Cá Nhân";
                    }
                    else if (headerCell.Value.ToString() == "BĐH")
                    {
                        headerCell.Value = "Ban Điều Hành";
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
                        cell.RowHeight = 20;
                        cell.ColumnWidth = 40;
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
                    FileName = "TongHopKPI.xlsx"

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
    }
}
