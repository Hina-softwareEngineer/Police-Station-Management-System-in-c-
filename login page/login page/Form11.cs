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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0; Data source=D:\\OOPS LABS\\Record.mdb");
            DataSet d1 = new DataSet("COMPLAINT");
            con.Open();
            string strsql = "select * from COMPLAINT";
            OleDbDataAdapter adap = new OleDbDataAdapter(strsql, con);
            adap.Fill(d1, "COMPLAINT");
            dataGrid1.DataSource = d1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkTurquoise;
        }

       
    }
}
