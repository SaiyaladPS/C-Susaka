using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmBathToKip : Form
    {
        public frmBathToKip()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ແລກປ່ຽນບາດເປັນກີບ_Click(object sender, EventArgs e)
        {

        }

        private void frmBathToKip_Load(object sender, EventArgs e)
        {

        }

        private void btnExc_Click(object sender, EventArgs e)
        {
            if (txtbath.Text == "")
            {
                MessageBox.Show("ກະລຸນາປ້ອນເງິນບາດ", "ຜົນການກວດສອບ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbath.Focus();
            }
            else if(txtRate.Text == "")
            {
                MessageBox.Show("ກະລຸນາປ້ອນອັດຕາແລກ", "ຜົນການກວດສອບ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRate.Focus();
            }
            else
            {
                double bath, rate, kip;
                bath = double.Parse(txtbath.Text);
                rate = double.Parse(txtRate.Text);
                kip = double.Parse(txtKip.Text);
                kip = bath * rate;
                txtKip.Text = kip.ToString("#,### ກີບ");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtbath.Clear();
            txtRate.Clear();
            txtKip.Clear();
            txtbath.Focus();
        }

        private void txtbath_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool ch;
            if (txtbath.Text != "")
            {
                ch = int.TryParse(txtbath.Text, out number);
                if (ch == false)
                {
                    MessageBox.Show("ກະລຸນາແຄ່ໂຕເລກເທົ່ານັ້ນ", "ຜົນການກວດສອບ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbath.Clear();
                }
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            int number;
            bool ch;
            if (txtRate.Text != "")
            {
                ch = int.TryParse(txtRate.Text, out number);
                if (ch == false)
                {
                    MessageBox.Show("ກະລຸນາແຄ່ໂຕເລກເທົ່ານັ້ນ", "ຜົນການກວດສອບ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbath.Clear();
                }
            }
        }

        private void txtbath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRate.Focus();
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnExc.PerformClick();
            }
        }
    }
}
