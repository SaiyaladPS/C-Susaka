using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Project
{
    public partial class frmConvertNumberToWord : Form
    {
        SpeechSynthesizer speaker = new SpeechSynthesizer();
        public frmConvertNumberToWord()
        {
            InitializeComponent();
        }

        string NumberToWord(int number)
        {
            if (number == 0)
                return "ສູນ";

            string[] Unit = { "", "ໜຶ່ງ", "ສອງ", "ສາມ", "ສີ່", "ຫ້າ", "ຫົກ", "ເຈັດ", "ແປດ", "ເກົ້າ" };
            string[] Level = { "", "ສິບ", "ຮ້ອຍ", "ພັນ", "ໝື່ນ", "ແສນ", "ລ້ານ" };

            string word = "";
            int i = 0;

            while (number > 0)
            {
                int digit = number % 10;

                if (digit != 0)
                {
                    word = Unit[digit] + Level[i] + word;
                }

                number /= 10;
                i++;
            }

            return word;
        }

        string NumberToWordEN(int number)
        {
            if (number == 0) return "Zero";

            string[] units = {
        "", "One", "Two", "Three", "Four", "Five",
        "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
        "Twelve", "Thirteen", "Fourteen", "Fifteen",
        "Sixteen", "Seventeen", "Eighteen", "Nineteen"
    };

            string[] tens = {
        "", "", "Twenty", "Thirty", "Forty",
        "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
    };

            if (number < 20)
                return units[number];

            if (number < 100)
                return tens[number / 10] +
                       ((number % 10 > 0) ? " " + units[number % 10] : "");

            if (number < 1000)
                return units[number / 100] + " Hundred" +
                       ((number % 100 > 0) ? " " + NumberToWordEN(number % 100) : "");

            if (number < 1000000)
                return NumberToWordEN(number / 1000) + " Thousand" +
                       ((number % 1000 > 0) ? " " + NumberToWordEN(number % 1000) : "");

            if (number < 1000000000)
                return NumberToWordEN(number / 1000000) + " Million" +
                       ((number % 1000000 > 0) ? " " + NumberToWordEN(number % 1000000) : "");

            return NumberToWordEN(number / 1000000000) + " Billion" +
                   ((number % 1000000000 > 0) ? " " + NumberToWordEN(number % 1000000000) : "");
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int number;

            if (int.TryParse(txtNumber.Text, out number))
            {
                lbResult.Text = NumberToWord(number);
            }
            else
            {
                MessageBox.Show("ກະລຸນາປ້ອນຕົວເລກ");
            }
        }

        private void btnConverten_Click(object sender, EventArgs e)
        {
            int number;

            if (int.TryParse(txtNumber.Text, out number))
            {
                lbResult.Text = NumberToWordEN(number);
                speaker.SpeakAsyncCancelAll();
                speaker.SpeakAsync(number.ToString());
            }
            else
            {
                MessageBox.Show("Please enter a valid number");
            }
        }
    }
}
