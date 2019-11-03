using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace login_page
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");

        private byte[] ImageToBytes(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            con.Close();
            MemoryStream memStream = new MemoryStream();
            image.Save(memStream, format);
            return memStream.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            OleDbDataAdapter adap = new OleDbDataAdapter(" Select * from POLICE", con);
            DataSet d1 = new DataSet();
                 
           // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 200;
            dataGridView1.AllowUserToAddRows = false;
            adap.Fill(d1, "POLICE");
            dataGridView1.DataSource = d1.Tables[0];
           
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns["Picture"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f2 = new Form6();
            f2.ShowDialog();
            this.Close();
        }
        
       

        private void Form9_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
