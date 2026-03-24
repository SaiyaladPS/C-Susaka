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
    public partial class frmCheckNumber : Form
    {
        public frmCheckNumber()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = int.Parse(textBox1.Text);

            if (number % 2 == 0)
            {
                MessageBox.Show(textBox1.Text + " ແມ່ນເລກຄູ່", "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(textBox1.Text + " ແມ່ນເລກຄີ", "ແຈ້ງເຕືອນ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
