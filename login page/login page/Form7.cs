using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace login_page
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");

        string gender;

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private byte[] ImageToBytes(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            MemoryStream memStream = new MemoryStream();
            image.Save(memStream, format);
            return memStream.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string crimPic = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "PNG File (*.png)|*.png|JPEG File (*.jpeg)|*.jpeg|JPG File (*.jpg)|*.jpg|BMP File (*.bmp)|*.bmp";
            ofd.Title = "Choose an Image...";
            ofd.FilterIndex = 0;
            ofd.Multiselect = false;
            ofd.ValidateNames = true;
            ofd.InitialDirectory = crimPic;

            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            else
                return;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd-MMM-yy";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Please fill the empty fields first.");
            }
            else
            {
                con.Open();
                OleDbCommand commIns = new OleDbCommand("Insert into CRIMINAL(CrimNo,CrimCNIC,CrimFirstName,CrimLastName,CrimAge,CrimGender,CrimAddress,CrimeType,CrimeDescription,ArrestDate,Photo) values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ",'" + gender + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Text + "', @Photo)", con);
                if (pictureBox1.Image != null)
                {
                    Bitmap bitmap = new Bitmap(pictureBox1.Image);
                    byte[] pic = ImageToBytes(bitmap, System.Drawing.Imaging.ImageFormat.Png);
                    commIns.Parameters.AddWithValue("@Photo", pic);
                }
                else
                    commIns.Parameters.AddWithValue("@Photo", OleDbType.Binary).Value = DBNull.Value;

                commIns.ExecuteNonQuery();
                MessageBox.Show("One record has been added");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                dateTimePicker1.CustomFormat = " ";
                pictureBox1.Image = null;
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 crimDisp = new Form15();
            crimDisp.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 crimDisp = new Form16();
            crimDisp.ShowDialog();
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

            button1.BackColor = Color.DarkTurquoise;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {

            button2.BackColor = Color.DarkTurquoise;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {

            button3.BackColor = Color.DarkTurquoise;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {

            button4.BackColor = Color.DarkTurquoise;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Red;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
             button5.BackColor = Color.DarkTurquoise;
        }

    }
}
