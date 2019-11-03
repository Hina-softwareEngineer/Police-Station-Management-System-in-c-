using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Speech;
using System.Speech.Synthesis;

namespace login_page
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        string gender;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form6_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        SpeechSynthesizer sp = new SpeechSynthesizer();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please Fill the empty fields first.");
            }
            else{
            con.Open();
             

            OleDbCommand com1 = new OleDbCommand("Insert into POLICE(P_id,P_name,P_salary,P_design,P_task,P_taskplace,P_gender,JoiningDate,Picture) values(' " + textBox1.Text + " ',' " + textBox2.Text + " ',' " + textBox3.Text + " ',' " + textBox4.Text + " ',' " + textBox5.Text + " ','"+textBox6.Text+"','"+gender+"','"+dateTimePicker1.Text+"',@Picture)", con);
            if (pictureBox1.Image != null)
            {
                Bitmap bit = new Bitmap(pictureBox1.Image);
                byte[] pic = ImageToBytes
                (bit, System.Drawing.Imaging.ImageFormat.Png);
                com1.Parameters.AddWithValue("@Picture", pic);
            }
            else
            { com1.Parameters.AddWithValue("@Picture", OleDbType.Binary).Value= DBNull.Value;
           
}
            con.Open();
                com1.ExecuteNonQuery();
                sp.Dispose();
                sp = new SpeechSynthesizer();
                sp.SpeakAsync("One record has been added");
             MessageBox.Show("One record has been added");
             textBox1.Text = "";
             textBox2.Text = "";
             textBox3.Text = "";
             textBox4.Text = "";
             textBox5.Text = "";
             textBox6.Text = "";
             pictureBox1.Image = null;
            
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f2 = new Form9();
            f2.ShowDialog();
            this.Close();
                     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f2 = new Form10();
            f2.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f2 = new Form5();
            f2.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string Ppic = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //ofd.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)| BMP Files (*.bmp)|*.bmp";
            ofd.Filter="Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";  
            ofd.Title = "Choose and Image...";
            ofd.FilterIndex = 0;
            ofd.Multiselect = false;
            ofd.ValidateNames = true;
            ofd.InitialDirectory = Ppic;
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            else
                return;
        }

        private byte[] ImageToBytes(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            con.Close();
            MemoryStream memStream = new MemoryStream();
            image.Save(memStream, format);
            return memStream.ToArray();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }
       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            // Display the date as "Mon 27 Feb 2012".  
            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Red;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkTurquoise;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkTurquoise;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkTurquoise;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkTurquoise;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkTurquoise;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
   }
}
