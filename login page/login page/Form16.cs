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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");
        OleDbDataAdapter adap = new OleDbDataAdapter("Select * from CRIMINAL", "Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");
        DataSet ds = new DataSet("CRIMINAL");

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f2 = new Form7();
            f2.ShowDialog();
            this.Close();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string b = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from CRIMINAL where CrimFirstName+' '+CrimLastName='" + b + "'", con);
            DataSet d1 = new DataSet();
            adap.Fill(d1, "CRIMINAL");
            dataGridView1.DataSource = d1.Tables[0];
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

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkTurquoise;
        }

        private void Form16_Load_1(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            OleDbCommand com1 = new OleDbCommand("select CrimFirstName+' '+CrimLastName from CRIMINAL", con);
            OleDbDataAdapter adap = new OleDbDataAdapter(com1);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0]);
            }
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //        con.Open();
        //        OleDbCommand commUpd = new OleDbCommand("update criminal set CrimCNIC='" + dataGridView1.Rows[0].Cells["CrimCNIC"].Value.ToString() + "',CrimeType='" + dataGridView1.Rows[0].Cells["CrimeType"].Value.ToString() + "',CrimAge=" + dataGridView1.Rows[0].Cells["CrimAge"].Value.ToString() + ",CrimGender='" + dataGridView1.Rows[0].Cells["CrimGender"].Value.ToString() + "',CrimAddress='" + dataGridView1.Rows[0].Cells["CrimAddress"].Value.ToString() + "',CrimeDescription='" + dataGridView1.Rows[0].Cells["CrimeDescription"].Value.ToString() + "' where CrimFirstName+' '+CrimLastName'"=+dataGridView1.Rows[0].Cells["CrimFirstName"].Value + " " +dataGridView1.Rows[0].Cells["CrimLLastName"].Value + "' ", con);
        //        commUpd.ExecuteNonQuery();
        //        MessageBox.Show("Data Updated!!");
    
        //}
    }
}
