using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Data.OleDb;

namespace login_page
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0; Data source=D:\\OOPS LABS\\Record.mdb");
        DataSet d1 = new DataSet("COMPLAINT");

        private void Form13_Load(object sender, EventArgs e)
        {
            
            label12.Text = Form8.set1;
            label13.Text = Form8.set11;
            label14.Text = Form8.set2;
            label15.Text = Form8.set4;
            label16.Text = Form8.set3;
            label17.Text = Form8.set8;
            label18.Text = Form8.set6;
            label19.Text = Form8.set7;
            label20.Text = Form8.set9;
            label21.Text = Form8.set10;
            label22.Text = Form8.set5;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bitmap = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics eg = Graphics.FromImage(bitmap);
            eg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }
        Bitmap bitmap;
        

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue;
        }
        
           
     
    }
}
