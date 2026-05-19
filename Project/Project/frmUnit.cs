using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Project
{
    public partial class frmUnit : Form
    {

        DBConnection db = new DBConnection();

        public frmUnit()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            ShowData();
        }

        void ShowData()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM tbUnit";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataUnitView.DataSource = dt;

                dataUnitView.Columns[0].HeaderText = "ລະຫັດຫົວໜ່ວຍ";
                dataUnitView.Columns[1].HeaderText = "ຊື່ຫົວໜ່ວຍ";

                dataUnitView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataUnitView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataUnitView.ReadOnly = true;
            }

            AutoId();
        }

        void AutoId()
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "SELECT COUNT(*) FROM tbUnit";
                SqlCommand cmd = new SqlCommand(sql, conn);

                int count = (int)cmd.ExecuteScalar();

                txtUnitID.Text = (count + 1).ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitID.Text))
            {
                MessageBox.Show("Please select data Unit Id");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                MessageBox.Show("Please select data Unit name");
                return;
            }

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = "INSERT INTO tbUnit(unitName) VALUES(@unitName)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@unitName", txtUnitName.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(this, "Insert Unit Success");
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataUnitView.Rows[e.RowIndex].Cells[0].Value == null)
            {
                return;
            }

            try
            {
                DataGridViewRow row = dataUnitView.Rows[e.RowIndex];

                txtUnitID.Text = row.Cells["UnitID"].Value?.ToString() ?? "";
                txtUnitName.Text = row.Cells["UnitName"].Value?.ToString() ?? "";

                txtUnitName.Focus();
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitID.Text))
            {
                MessageBox.Show("Please enter Unit ID",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUnitID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                MessageBox.Show("Please enter Unit Name",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUnitName.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = "INSERT INTO tbUnit (unitID, unitName) VALUES (@unitID, @unitName)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.Add("@unitID", SqlDbType.NVarChar).Value = txtUnitID.Text;
                    cmd.Parameters.Add("@unitName", SqlDbType.NVarChar).Value = txtUnitName.Text;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Insert successful",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    ShowData();
                    AutoId();

                    txtUnitName.Clear();
                    txtUnitName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitID.Text))
            {
                MessageBox.Show("Please select data to edit",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUnitName.Text))
            {
                MessageBox.Show("Please enter Unit Name",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUnitName.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = "UPDATE tbUnit SET unitName = @unitName WHERE unitID = @unitID";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.Add("@unitName", SqlDbType.NVarChar).Value = txtUnitName.Text.Trim();
                    cmd.Parameters.Add("@unitID", SqlDbType.NVarChar).Value = txtUnitID.Text.Trim();

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Update successful",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        ShowData();
                        AutoId();

                        txtUnitID.Clear();
                        txtUnitName.Clear();
                        txtUnitName.Focus();
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
            // ✅ 1. Check input
            if (string.IsNullOrWhiteSpace(txtUnitID.Text))
            {
                MessageBox.Show("Please select data to delete",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // ✅ 2. Confirm delete
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this record?",
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

                    string sql = "DELETE FROM tbUnit WHERE unitID = @unitID";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.Add("@unitID", SqlDbType.NVarChar).Value = txtUnitID.Text.Trim();

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show(
                            "Delete successful",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        ShowData();
                        AutoId();

                        txtUnitID.Clear();
                        txtUnitName.Clear();
                        txtUnitName.Focus();
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
    }
}
