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

                string sql = 'INSERT INTO tbUnit(unitName) VALUES(@unitName)';
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@unitName", txtUnitName.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(this, "Insert Unit Success");
            }
        }
    }
}
