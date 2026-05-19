using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project
{
    public partial class frmCategory : Form
    {

        DBConnection db = new DBConnection();

        public frmCategory()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            DGV.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            ShowData();
            AutoId();
        }

        void AutoId()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT MAX(categoryID) FROM tbCategory";
                SqlCommand cmd = new SqlCommand(sql, conn);

                object result = cmd.ExecuteScalar();

                if (result == DBNull.Value || result == null)
                {
                    txtCategoryID.Text = "0";
                }
                else
                {
                    string lastID = result.ToString(); // CAT-005

                    int number = int.Parse(lastID); // remove "CAT-"

                    number++;

                    txtCategoryID.Text = number.ToString();
                }
            }
        }

        void ShowData()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM tbCategory";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                DGV.DataSource = dt;

                DGV.Columns["categoryID"].HeaderText = "Category ID";
                DGV.Columns["categoryName"].HeaderText = "Category Name";

                DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DGV.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                try
                {
                    // ❌ Input validation
                    if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
                    {
                        MessageBox.Show("Please enter Category ID");
                        txtCategoryID.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                    {
                        MessageBox.Show("Please enter Category Name");
                        txtCategoryName.Focus();
                        return;
                    }

                    conn.Open();

                    string sql = "INSERT INTO tbCategory (categoryID, categoryName) VALUES (@categoryID, @categoryName)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.Add("@categoryID", SqlDbType.NVarChar).Value = txtCategoryID.Text.Trim();
                    cmd.Parameters.Add("@categoryName", SqlDbType.NVarChar).Value = txtCategoryName.Text.Trim();

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Save successful",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        txtCategoryID.Clear();
                        txtCategoryName.Clear();
                        txtCategoryName.Focus();

                        ShowData();
                        AutoId();
                    }
                    else
                    {
                        MessageBox.Show("Insert failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = DGV.Rows[e.RowIndex];

                if (row.Cells["categoryID"].Value == null) return;

                txtCategoryID.Text = row.Cells["categoryID"].Value.ToString();
                txtCategoryName.Text = row.Cells["categoryName"].Value.ToString();

                txtCategoryName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "System",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           using(SqlConnection conn = db.GetConnection())
            {
                if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
                {
                    MessageBox.Show("Please select category ID");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                {
                    MessageBox.Show("Please select category name");
                    return;
                }

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE tbCategory SET categoryName = @categoryName WHERE categoryID = @categoryID",
                        conn);

                    cmd.Parameters.Add("@categoryID", SqlDbType.NVarChar).Value = txtCategoryID.Text.Trim();
                    cmd.Parameters.Add("@categoryName", SqlDbType.NVarChar).Value = txtCategoryName.Text.Trim();

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Update success");

                        ShowData();

                        txtCategoryID.Clear();
                        txtCategoryName.Clear();
                        txtCategoryName.Focus();

                        AutoId();
                    }
                    else
                    {
                        MessageBox.Show("No data found to update");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
                {
                    MessageBox.Show("Please select category ID");
                    return;
                }

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM tbCategory WHERE categoryID = @categoryID",
                        conn);

                    cmd.Parameters.Add("@categoryID", SqlDbType.NVarChar).Value = txtCategoryID.Text.Trim();

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Delete successful",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        ShowData();

                        txtCategoryID.Clear();
                        txtCategoryName.Clear();
                        txtCategoryName.Focus();

                        AutoId();
                    }
                    else
                    {
                        MessageBox.Show("No data found to delete");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
