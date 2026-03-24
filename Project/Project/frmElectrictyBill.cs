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
    public partial class frmElectrictyBill : Form
    {
        public frmElectrictyBill()
        {
            InitializeComponent();
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCaloun_Click(object sender, EventArgs e)
        {
            int power;
            int T1, T2, T3, T4, T5, T6, T7, T8;

            power = int.Parse(txtNow.Text) - int.Parse(txtBefore.Text);

            txtPower.Text = power.ToString("#,###");

            if (power <= 25)
            {
                T1 = power * int.Parse(txtR1.Text);
                txtP1.Text = power.ToString("#,###");
                power = 0;

            } else
            {
                T1 = 25 * int.Parse(txtR1.Text);
                txtP1.Text = "25";
                power = power - 25;
            }
            if (T1 == 0)
            {
                txtT1.Text = T1.ToString();
            }
            else
            {
                txtT1.Text = T1.ToString("#,###");
            }

            if (power <= 125)
            {
                T2 = power * int.Parse(txtR2.Text);
                txtP2.Text = power.ToString("#,###");
                power = 0;

            }
            else
            {
                T2 = 125 * int.Parse(txtR2.Text);
                txtP2.Text = "125";
                power = power - 125;
            }
            if (T2 == 0)
            {
                txtT2.Text = T2.ToString();
            }
            else
            {
                txtT2.Text = T2.ToString("#,###");
            }

            if (power <= 150)
            {
                T3 = power * int.Parse(txtR3.Text);
                txtP3.Text = power.ToString("#,###");
                power = 0;

            }
            else
            {
                T3 = 150 * int.Parse(txtR3.Text);
                txtP3.Text = "150";
                power = power - 150;
            }
            if (T3 == 0)
            {
                txtT3.Text = T3.ToString();
            }
            else
            {
                txtT3.Text = T3.ToString("#,###");
            }

            if (power <= 100)
            {
                T4 = power * int.Parse(txtR4.Text);
                txtP4.Text = power.ToString("#,###");
                power = 0;

            }
            else
            {
                T4 = 100 * int.Parse(txtR4.Text);
                txtP4.Text = "100";
                power = power - 100;
            }
            if (T4 == 0)
            {
                txtT4.Text = T4.ToString();
            }
            else
            {
                txtT4.Text = T4.ToString("#,###");
            }

            if (power <= 100)
            {
                T5 = power * int.Parse(txtR5.Text);
                txtP5.Text = power.ToString("#,###");
                power = 0;

            }
            else
            {
                T5 = 500 * int.Parse(txtR5.Text);
                txtP5.Text = "500";
                power = power - 500;
            }
            if (T5 == 0)
            {
                txtT5.Text = T5.ToString();
            }
            else
            {
                txtT5.Text = T5.ToString("#,###");
            }

            if (power <= 500)
            {
                T6 = power * int.Parse(txtR6.Text);
                txtP6.Text = power.ToString("#,###");
                power = 0;

            }
            else
            {
                T6 = 500 * int.Parse(txtR6.Text);
                txtP6.Text = "500";
                power = power - 500;
            }
            if (T6 == 0)
            {
                txtT6.Text = T6.ToString();
            }
            else
            {
                txtT6.Text = T6.ToString("#,###");
            }

            if (power <= 500)
            {
                T7 = power * int.Parse(txtR7.Text);
                txtP7.Text = power.ToString("#,###");
                power = 0;

            }
            else
            {
                T7 = 500 * int.Parse(txtR7.Text);
                txtP7.Text = "500";
                power = power - 500;
            }
            if (T7 == 0)
            {
                txtT7.Text = T7.ToString();
            }
            else
            {
                txtT7.Text = T7.ToString("#,###");
            }

            T8 = power * int.Parse(txtR8.Text);
            txtP8.Text = power.ToString();
            if (T8 == 0)
            {
                txtT8.Text = T8.ToString();
            }
            else
            {
                txtT8.Text = T8.ToString("#,###");
            }

            int total = T1 + T2 + T3 + T4 + T5 + T6 + T7 + T8;
            txtTotal.Text = total.ToString("#,###");
            string maintain;
            maintain = txtMaintain.Text;
            maintain = maintain.Replace(",", "");
            double tax = (total + int.Parse(maintain)) * 0.1;
            txtTax.Text = tax.ToString("#,###");
            txtAmount.Text = (total + int.Parse(maintain) + tax).ToString("#,###");
        }

        private void cbface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbface.SelectedIndex == 0)
            {
                txtMaintain.Text = "21,300";
            } else if (cbface.SelectedIndex == 1)
            {
                txtMaintain.Text = "46,600";
            } else if (cbface.SelectedIndex == 2)
            {
                txtMaintain.Text = "6,000";
            } else if (cbface.SelectedIndex == 3)
            {
                txtMaintain.Text = "12,600";
            }
        }
    }
}
