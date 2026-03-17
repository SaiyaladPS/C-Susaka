using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;

namespace Project
{
    public partial class frmVoice : Form
    {
        public frmVoice()
        {
            InitializeComponent();
        }
        void Speak(string msg)
        {
            SpVoice sv = new SpVoice();
            sv.Speak(msg, SpeechVoiceSpeakFlags.SVSFDefault);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Speak("Lumina");
        }
    }
}
