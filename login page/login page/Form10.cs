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

namespace login_page
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");
        OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * from POLICE", "Provider=Microsoft.jet.OLEDB.4.0;Data Source=D:\\OOPS LABS\\Record.mdb");
        DataSet ds = new DataSet("POLICE");
        private void Form10_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                       
              
            string strsql = "select * from POLICE";
            OleDbDataAdapter adap = new OleDbDataAdapter(strsql, con);
            DataSet d1 = new DataSet("POLICE");
            adap.Fill(d1, "POLICE");
            comboBox1.DataSource = d1.Tables[0];
            comboBox1.DisplayMember = "P_name";
        }
    
        private byte[] ImageToBytes(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            con.Close();
            MemoryStream memStream = new MemoryStream();
            image.Save(memStream, format);
            return memStream.ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adap1 = new OleDbDataAdapter("Select * from POLICE where P_name='"+comboBox1.Text+"'",con);
            DataSet d2 = new DataSet();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.AllowUserToAddRows = false;

            adap1.Fill(d2, "POLICE");
            dataGridView1.DataSource = d2.Tables[0];

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns["Picture"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            
            //DataGridViewImageColumn dgvimgcol = new DataGridViewImageColumn();
            //dgvimgcol.HeaderText = "Picture";
            //dgvimgcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            
        }

        private void button2_Click(object sender, EventArgs e)
            
        {
            con.Open();
            OleDbCommand com = new OleDbCommand("DELETE FROM POLICE where P_name='" + comboBox1.Text + "' ", con);
            com.ExecuteNonQuery();
            MessageBox.Show("One record has been deleted.");
        }

        OleDbCommandBuilder builder = new OleDbCommandBuilder();
        
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand com2 = new OleDbCommand("update POLICE set P_salary='" + dataGridView1.Rows[0].Cells["P_salary"].Value.ToString() + "',P_design='" + dataGridView1.Rows[0].Cells["P_design"].Value.ToString() + "',P_task='" + dataGridView1.Rows[0].Cells["P_task"].Value.ToString() + "',P_taskplace='" + dataGridView1.Rows[0].Cells["P_taskplace"].Value.ToString() + "',P_gender='" + dataGridView1.Rows[0].Cells["P_gender"].Value.ToString() + "',JoiningDate='" + dataGridView1.Rows[0].Cells["JoiningDate"].Value.ToString() + "' where P_name='" + dataGridView1.Rows[0].Cells["P_name"].Value + "' ", con);
            com2.ExecuteNonQuery();
            MessageBox.Show("Data Updated!!");
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f2 = new Form6();
            f2.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkTurquoise;
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

       
      }
}
