using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace fitness_club
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Admin\Documents\gym_db.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public Form2()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select User_Name from tbl_User where User_Name='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
            cmd.Connection = con;
            SqlDataReader dr= cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            if (dr.Read())
            {
                timer2.Enabled = true;
                timer2.Start();
            }
            else
            {
                MessageBox.Show("      Incorrect Login Id or Password      ");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            con.Close();
           /* if (textBox1.Text.Equals("admin") && textBox2.Text.Equals("admin"))
            {
                timer2.Enabled = true;
                timer2.Start();
            }
            else
            {
                MessageBox.Show("      Incorrect Login Id or Password      ");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;
            if (this.Opacity >= 0.98)
            {
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01;
            if (this.Opacity <= 0)
            {
                this.Visible = false;
                timer2.Enabled = false;
                new Form3().Show();
            }

        }
    }
}
