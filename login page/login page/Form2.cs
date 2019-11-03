using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace login_page
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  this.Close();
            //exit button k click pe main page pe jane ka krlenge?//
        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "pass123")
            {
               textBox1.Text = "";
               textBox2.Text = "";
                MessageBox.Show("You loged in succesfully.");

                Form5 f5 = new Form5();
                f5.Show();
            }
            else
                MessageBox.Show("Sorry, Incorrect Username And Password.");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
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
            button2.BackColor = Color.RoyalBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue;
        }

       
    }

        }
    

