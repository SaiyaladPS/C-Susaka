using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmProduct : Form
    {
        DBConnection db = new DBConnection();
        public frmProduct()
        {
            InitializeComponent();
            LoadcoboUnit();
            LoadcoboCategory();
            showData();
            AutoProductID();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void LoadcoboUnit()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT unitID, unitName FROM tbUnit";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboUnit.DataSource = dt;
                comboUnit.DisplayMember = "unitName";   // show name
                comboUnit.ValueMember = "unitID";       // store ID
            }
        }

        void LoadcoboCategory()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT categoryID, categoryName FROM tbCategory";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboCategory.DataSource = dt;
                comboCategory.DisplayMember = "categoryName";
                comboCategory.ValueMember = "categoryID";
            }
        }

        void AutoProductID()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT MAX(productID) FROM tbProduct";
                SqlCommand cmd = new SqlCommand(sql, conn);

                object result = cmd.ExecuteScalar();

                if (result == DBNull.Value || result == null)
                {
                    txtProductID.Text = "P-001";
                }
                else
                {
                    string lastID = result.ToString();   // e.g. P-005

                    int number = int.Parse(lastID.Substring(2)); // remove "P-"

                    number++;

                    txtProductID.Text = "P-" + number.ToString("D3");
                }
            }
        }

        void showData()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        p.productID,
                        p.productName,
                        p.price,
                        p.qty,
                        u.unitName,
                        c.categoryName
                    FROM tbProduct p
                    LEFT JOIN tbUnit u ON p.unitID = u.unitID
                    LEFT JOIN tbCategory c ON p.categoryID = c.categoryID";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // Optional UI improve
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;

                // Rename headers
                dataGridView1.Columns[0].HeaderText = "ລະຫັດສິນຄ້າ";
                dataGridView1.Columns[1].HeaderText = "ຊື່ສິນຄ້າ";
                dataGridView1.Columns[2].HeaderText = "ລາຄາ";
                dataGridView1.Columns[3].HeaderText = "ຈຳນວນ";
                dataGridView1.Columns[4].HeaderText = "ຫັວໜ່ວຍ";
                dataGridView1.Columns[5].HeaderText = "ປະເພດສິນຄ້າ";
            }

            LoadProductCount();
        }

        void LoadProductCount()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM tbProduct";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int count = (int)cmd.ExecuteScalar();

                productCount.Text = count.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // ✅ Input check
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please enter Product ID");
                txtProductID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter Product Name");
                txtProductName.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                    INSERT INTO tbProduct
                    (productID, productName, price, qty, unitID, categoryID, conditionCheck)
                    VALUES
                    (@productID, @productName, @price, @qty, @unitID, @categoryID, @conditionCheck)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.Add("@productID", SqlDbType.VarChar).Value = txtProductID.Text.Trim();
                    cmd.Parameters.Add("@productName", SqlDbType.NVarChar).Value = txtProductName.Text.Trim();
                    cmd.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(txtPrice.Text);
                    cmd.Parameters.Add("@qty", SqlDbType.Float).Value = Convert.ToDouble(txtQty.Text);

                    // ComboBox values
                    cmd.Parameters.Add("@unitID", SqlDbType.Int).Value = comboUnit.SelectedValue;
                    cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = comboCategory.SelectedValue;

                    cmd.Parameters.Add("@conditionCheck", SqlDbType.Int).Value = 1;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Insert Product Success",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    showData();   // refresh grid
                    AutoProductID();     // generate new ID

                    txtProductName.Clear();
                    txtPrice.Clear();
                    txtQty.Clear();
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ❌ prevent header click error
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtProductID.Text = row.Cells["productID"].Value?.ToString();
                txtProductName.Text = row.Cells["productName"].Value?.ToString();
                txtPrice.Text = row.Cells["price"].Value?.ToString();
                txtQty.Text = row.Cells["qty"].Value?.ToString();

                // ComboBox (important)
                comboUnit.Text = row.Cells["unitName"].Value?.ToString();
                comboCategory.Text = row.Cells["categoryName"].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please select a product to edit");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter product name");
                txtProductName.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"
            UPDATE tbProduct 
            SET productName = @productName,
                price = @price,
                qty = @qty,
                unitID = @unitID,
                categoryID = @categoryID,
                conditionCheck = @conditionCheck
            WHERE productID = @productID";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.Add("@productID", SqlDbType.VarChar).Value = txtProductID.Text.Trim();
                    cmd.Parameters.Add("@productName", SqlDbType.NVarChar).Value = txtProductName.Text.Trim();
                    cmd.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(txtPrice.Text);
                    cmd.Parameters.Add("@qty", SqlDbType.Float).Value = Convert.ToDouble(txtQty.Text);

                    cmd.Parameters.Add("@unitID", SqlDbType.Int).Value = comboUnit.SelectedValue;
                    cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = comboCategory.SelectedValue;

                    cmd.Parameters.Add("@conditionCheck", SqlDbType.Int).Value = 1;

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show(
                            "Update successful",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        showData();

                        txtProductID.Clear();
                        txtProductName.Clear();
                        txtPrice.Clear();
                        txtQty.Clear();

                        AutoProductID();
                    }
                    else
                    {
                        MessageBox.Show("No data found to update");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please select a product to delete",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // ⚠️ Confirm delete
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = "DELETE FROM tbProduct WHERE productID = @productID";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.Add("@productID", SqlDbType.VarChar).Value = txtProductID.Text.Trim();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show(
                            "Delete successful",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        showData();

                        txtProductID.Clear();
                        txtProductName.Clear();
                        txtPrice.Clear();
                        txtQty.Clear();

                        AutoProductID();
                    }
                    else
                    {
                        MessageBox.Show("Data not found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = @"
        SELECT 
            p.productID,
            p.productName,
            p.price,
            p.qty,  
            u.unitName,
            c.categoryName
        FROM tbProduct p
        LEFT JOIN tbUnit u ON p.unitID = u.unitID
        LEFT JOIN tbCategory c ON p.categoryID = c.categoryID
        WHERE p.productID LIKE @search
           OR p.productName LIKE @search";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                da.SelectCommand.Parameters.Add("@search", SqlDbType.NVarChar).Value =
                    "%" + txtSearch.Text.Trim() + "%";

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                productCount.Text = dt.Rows.Count.ToString();
            }
        }
    }
}
