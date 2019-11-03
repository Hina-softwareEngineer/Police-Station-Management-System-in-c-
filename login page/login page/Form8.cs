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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0; Data source=D:\\OOPS LABS\\Record.mdb");
        DataSet d1 = new DataSet("COMPLAINT");


        private void Form8_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        public static string set1;
        public static string set2;
        public static string set3;
        public static string set4;
        public static string set5;
        public static string set6;
        public static string set7;
        public static string set8;
        public static string set9;
        public static string set10;
        public static string set11;
        private void button1_Click(object sender, EventArgs e)
        {
           
            OleDbCommand cmd = new OleDbCommand("insert into COMPLAINT (Complain_no,c_name,father_name,CNIC,Crime,Crime_time,Crime_date,Relation_wd_Victim,Victim_name,Victim_Father_name,Police_Id,Picture) values('"+ textBox1.Text +"','"+ textBox2.Text +"','"+ textBox3.Text +"','"+ textBox4.Text +"','"+ textBox5.Text +"','"+ textBox6.Text +"','"+ textBox7.Text +"','"+ textBox8.Text +"','"+ textBox9.Text +"','"+ textBox10.Text +"','"+textBox11.Text+"', @Picture)", con);
            if (pictureBox1.Image != null)
            {
                Bitmap bit = new Bitmap(pictureBox1.Image);
                byte[] pic = ImageToBytes(bit, System.Drawing.Imaging.ImageFormat.Png);
                cmd.Parameters.AddWithValue("@Picture", pic);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Picture", OleDbType.Binary).Value = DBNull.Value;

            }
            con.Open();
            cmd.ExecuteNonQuery();
            set1 = textBox1.Text;
            set2 = textBox2.Text;
            set3 = textBox3.Text;
            set4 = textBox4.Text;
            set5 = textBox5.Text;
            set6 = textBox6.Text;
            set7 = textBox7.Text;
            set8= textBox8.Text;
            set9 = textBox9.Text;
            set10 = textBox10.Text;
            set11 = textBox11.Text;
          

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
           
            MessageBox.Show("One record has been added");
            Form13 form = new Form13();
            form.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();

           }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string Ppic = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //ofd.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)| BMP Files (*.bmp)|*.bmp";
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
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

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Red;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkTurquoise;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkTurquoise;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkTurquoise;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkTurquoise;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkTurquoise;

        }

       
    }
}
