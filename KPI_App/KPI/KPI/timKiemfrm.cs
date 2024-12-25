using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KPI
{
    public partial class timKiemfrm : Form
    {
        private string userMaNV;
        private string connectionString = "Server=127.0.0.1;Database=kpi;User ID=root;Password=123456;Charset=utf8mb4";

        public timKiemfrm(string username)
        {
            this.userMaNV = username;
            InitializeComponent();
        }

        private void timKiemfrm_Load(object sender, EventArgs e)
        {
            LoadUserData(); // Load initial data
            CheckUserRoleAndLoadData();

        }

        private void CheckUserRoleAndLoadData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check the current user's role (CD)
                    string roleQuery = "SELECT CD FROM user WHERE MaNV = @MaNV";
                    string userRole = null;

                    using (MySqlCommand cmd = new MySqlCommand(roleQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                        userRole = cmd.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(userRole))
                    {
                        MessageBox.Show("Could not determine the user's role (CD).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // If the user is not 'TT', disable search and load only their updated data
                    if (userRole != "TT")
                    {
                        txtSearch.Enabled = false;
                        btnFind.Enabled = false;
                        LoadUpdatedDataForUser(conn); // Load only the user's updated data
                    }
                    else
                    {
                        // If the user is 'TT', enable search and load data as before
                        txtSearch.Enabled = true;
                        btnFind.Enabled = true;
                        LoadUserData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking user role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUpdatedDataForUser(MySqlConnection conn)
        {
            try
            {
                // Query to load only data updated by the user in 'tieuChiCaNhanfrm'
                string dataQuery = "SELECT * FROM `12` WHERE MaNV = @MaNV";

                DataTable dataTable = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand(dataQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                // Bind data to DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading updated data for user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get user's department (BP)
                    string bpQuery = "SELECT BP FROM user WHERE MaNV = @MaNV";
                    string userBP = null;

                    using (MySqlCommand bpCmd = new MySqlCommand(bpQuery, conn))
                    {
                        bpCmd.Parameters.AddWithValue("@MaNV", userMaNV);
                        userBP = bpCmd.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(userBP))
                    {
                        MessageBox.Show("Could not determine the user's department (BP).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Query to fetch data for the DataGridView
                    string dataQuery = @"
                        SELECT * 
                        FROM `12` 
                        WHERE (CD = 'TT' AND BP = @BP)
                        OR (MaNV = @MaNV)";

                    DataTable dataTable = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand(dataQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BP", userBP);
                        cmd.Parameters.AddWithValue("@MaNV", userMaNV);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string searchMaNV = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(searchMaNV))
                {
                    MessageBox.Show("Please enter an MaNV to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get user's department (BP)
                    string bpQuery = "SELECT BP FROM user WHERE MaNV = @MaNV";
                    string userBP = null;

                    using (MySqlCommand bpCmd = new MySqlCommand(bpQuery, conn))
                    {
                        bpCmd.Parameters.AddWithValue("@MaNV", userMaNV);
                        userBP = bpCmd.ExecuteScalar()?.ToString();
                    }

                    if (string.IsNullOrEmpty(userBP))
                    {
                        MessageBox.Show("Could not determine the user's department (BP).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Query to search for specific MaNV
                    string searchQuery = @"
                        SELECT * 
                        FROM `12` 
                        WHERE (CD = 'TT' AND BP = @BP AND MaNV = @SearchMaNV)";

                    DataTable dataTable = new DataTable();
                    using (MySqlCommand cmd = new MySqlCommand(searchQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BP", userBP);
                        cmd.Parameters.AddWithValue("@SearchMaNV", searchMaNV);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    // Check if results were found
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No results found for the entered MaNV.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Bind results to DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for MaNV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Data Error: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false; // Suppress the exception
        }
    }
}
