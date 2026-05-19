using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project
{
    public partial class frmCategory : Form
    {

        string strcon = "Data source=DESKTOP-V2EDS8D; initial catalog=dbMinimartBCSP6E; integrated security=true";
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        public frmCategory()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = strcon;
            DGV.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            ShowData();
            AutoId();
        }

        void AutoId()
        {
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT COUNT(*) AS count FROM tbCategory", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                int count = Convert.ToInt32(dt.Rows[0]["count"]) + 1;

                txtCategoryID.Text = count.ToString();
            }
        }

        void ShowData()
        {
            try
            {
                ds.Tables.Clear();

                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbCategory", conn))
                {
                    da.Fill(ds, "Category");
                }

                if (ds.Tables["Category"].Rows.Count > 0)
                {
                    DGV.DataSource = ds.Tables["Category"];
                    DGV.Columns[0].HeaderText = "Category ID";
                    DGV.Columns[1].HeaderText = "Category Name";
                }
                else
                {
                    DGV.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd = new SqlCommand("INSERT INTO tbCategory (categoryID, categoryName) VALUES (@categoryID, @categoryName)", conn);

                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = int.Parse(txtCategoryID.Text);
                cmd.Parameters.Add("@categoryName", SqlDbType.NVarChar).Value = txtCategoryName.Text;

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Save successful",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ShowData();

                txtCategoryID.Clear();
                txtCategoryName.Clear();
                txtCategoryID.Focus();

                AutoId();
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

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGV.Rows[e.RowIndex].Cells[0].Value == null)
            {
                return;
            }

            try
            {
                DataGridViewRow row = DGV.Rows[e.RowIndex];

                txtCategoryID.Text = row.Cells["categoryID"].Value?.ToString() ?? "";
                txtCategoryName.Text = row.Cells["categoryName"].Value?.ToString() ?? "";

                txtCategoryName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error : " + ex.Message,
                    "System",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                MessageBox.Show("Please select data category id");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please select data category name");
                return;
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd = new SqlCommand(
                "UPDATE tbCategory SET categoryName = @categoryName WHERE categoryID = @categoryID", conn);

                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = int.Parse(txtCategoryID.Text);
                cmd.Parameters.Add("@categoryName", SqlDbType.NVarChar).Value = txtCategoryName.Text;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Update success");

                ShowData();

                txtCategoryID.Clear();
                txtCategoryName.Clear();
                txtCategoryID.Focus();

                AutoId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryID.Text))
            {
                MessageBox.Show("Please select data category id");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please select data category name");
                return;
            }

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd = new SqlCommand(
                "DELETE FROM tbCategory WHERE categoryID = @categoryID", conn);

                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = int.Parse(txtCategoryID.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                     "Delete successful",
                     "Success",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                 );

                ShowData();

                txtCategoryID.Clear();
                txtCategoryName.Clear();
                txtCategoryID.Focus();

                AutoId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
