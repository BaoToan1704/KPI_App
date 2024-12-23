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
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;Charset=utf8mb4"; // Your DB connection string

        public TieuChiCaNhanfrm(string username)
        {
            InitializeComponent();
            this.userMaNV = username;

        }

        private void TieuChiCaNhanfrm_Load(object sender, EventArgs e)
        {
            // Load data for the user
            LoadDataForUser();
        }
        private void LoadDataForUser()
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
                    string dataQuery = @"
                    SELECT *
                    FROM diem_cong_table
                    WHERE BP IS NULL OR BP = @BP
                    UNION
                    SELECT *
                    FROM diem_tru_table
                    WHERE BP IS NULL OR BP = @BP";

                    using (MySqlCommand cmd = new MySqlCommand(dataQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BP", bp != null ? bp : (object)DBNull.Value);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
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
            
        }
    }
}
