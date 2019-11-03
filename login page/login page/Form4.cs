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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }



        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");


        private void Form4_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            con.Open();
            OleDbCommand com = new OleDbCommand("select P_name from POLICE", con);
            OleDbDataReader d1 = com.ExecuteReader();
            while (d1.Read())
            {
                string a = d1["P_name"].ToString();
                comboBox1.Items.Add(a);
            }

            OleDbCommand com1 = new OleDbCommand("select CrimFirstName,CrimLastName from CRIMINAL", con);
            OleDbDataReader d2 = com1.ExecuteReader();
            while (d2.Read())
            {
                string a = d2["CrimFirstName"].ToString();
                comboBox2.Items.Add(a);
            }

        }  
      

        private void button1_Click(object sender, EventArgs e)
        {
            string b = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            OleDbDataAdapter adap = new OleDbDataAdapter("select P_name,P_design,P_taskplace from POLICE where P_name='" + b + "'", con);
            DataSet d = new DataSet();
            adap.Fill(d, "POLICE");
            dataGrid1.DataSource = d;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string b = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            OleDbDataAdapter adap = new OleDbDataAdapter("select CrimFirstName,CrimLastName,CrimAddress,CrimeDescription from CRIMINAL where CrimFirstName='" + b + "'", con);
            DataSet d = new DataSet();
            adap.Fill(d, "CRIMINAL");
            dataGrid1.DataSource = d;

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.RoyalBlue;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
       
    }
}
