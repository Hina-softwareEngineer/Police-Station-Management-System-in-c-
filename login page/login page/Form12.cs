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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0; Data source=D:\\OOPS LABS\\Record.mdb");
        DataSet d1 = new DataSet("COMPLAINT");

        private void Form12_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
           /* OleDbCommand com = new OleDbCommand("select Complain_no from complain1", con);
            OleDbDataReader d1 = com.ExecuteReader();
            while (d1.Read())
            {
                string a = d1["Complain_no"].ToString();
                comboBox1.Items.Add(a);
            }*/
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from COMPLAINT where Complain_no ='" + textBox1.Text + " ' ", con);
            DataSet d = new DataSet();
            adap.Fill(d, "COMPLAINT");
            dataGrid1.DataSource = d;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkTurquoise;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkTurquoise;
        }
    }
}
