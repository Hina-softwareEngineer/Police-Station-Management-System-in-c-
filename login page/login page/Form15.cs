using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace login_page
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");

        private void button2_Click(object sender, EventArgs e)
        {
                OleDbDataAdapter adap = new OleDbDataAdapter("Select * from CRIMINAL", con);
                DataSet d1 = new DataSet();
                adap.Fill(d1, "CRIMINAL");
                dataGridView1.DataSource = d1.Tables[0];

                DataGridViewImageColumn dgvImgCol = new DataGridViewImageColumn();
                dgvImgCol.HeaderText = "Photo";
                dgvImgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f2 = new Form7();
            f2.ShowDialog();
            this.Close();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkTurquoise;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkTurquoise;
        }

        private void Form15_Load_1(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
    }
}
