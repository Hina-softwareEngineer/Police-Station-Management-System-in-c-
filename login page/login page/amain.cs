using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace login_page
{
    public partial class amain : Form
    {
        public amain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            sp.Dispose();
            sp = new SpeechSynthesizer();
            sp.SelectVoiceByHints(VoiceGender.Female,VoiceAge.Senior);
            sp.SpeakAsync("You are going to home page...");
            Form1 f2 = new Form1();
            f2.ShowDialog();
            this.Close();
        }
        SpeechSynthesizer sp = new SpeechSynthesizer();
     private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Cyan;
        }

        private void amain_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }
    }
}
