using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project
{
    public partial class frmCategory : Form
    {

        public frmCategory()
        {
            InitializeComponent();
        }

        string strcon = "Data source=DESKTOP-V2EDS8D; initial catalog=dbMinimartBCSP6E; integrated security=true";
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        private void frmCategory_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = strcon;
            ShowData();
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

                MessageBox.Show("Save successful");

                ShowData();

                txtCategoryID.Clear();
                txtCategoryName.Clear();
                txtCategoryID.Focus();
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
            txtCategoryID.Clear();
            txtCategoryName.Clear();
            if (e.RowIndex < 0) return;

            var id = DGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            var name = DGV.Rows[e.RowIndex].Cells[1].Value.ToString();

            txtCategoryID.Text = id;
            txtCategoryName.Text = name;
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
              
                SqlCommand cmd = new SqlCommand(
                "UPDATE tbCategory SET categoryName = @categoryName WHERE categoryID = @categoryID", conn)
                cmd.Parameters.Add("@categoryName", SqlDbType.VarChar).Value = txtCategoryName.Text;
                cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = Convert.ToInt32(txtCategoryID.Text);

                cmd.ExecuteNonQuery();
                

                MessageBox.Show("Update success");

                ShowData();

                txtCategoryID.Clear();
                txtCategoryName.Clear();
                txtCategoryID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
