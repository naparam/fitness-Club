using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging; 
namespace fitness_club
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Admin\Documents\gym_db.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int r;
        string ff_Code;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            
        }
        private void clearing()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text="";
            textBox5.Text="";
            comboBox2.Text="";
            comboBox3.Text="";
            comboBox4.Text="";
            comboBox5.Text="";
            textBox6.Text="";
            textBox8.Text = "";
            //pictureBox1.Image = Image.FromFile(textBox8.Text);
        }
       
        
        private void inserting()
        {
           
            string stdate = DateTime.Today.ToShortTimeString();
            string stday = DateTime.Today.Day.ToString();
            string stmonth = DateTime.Today.Month.ToString();
            string styear = DateTime.Today.Year.ToString();
            
            if(button12.Text=="&Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update tbl_member set Name='" + textBox1.Text.ToUpper() + "',Gender='" + comboBox1.Text + "',Height='" + textBox2.Text + "',Weight='" + textBox3.Text + "',Contact='" + textBox4.Text + "',Alt_no='" + textBox5.Text + "',Batch='" + comboBox2.Text + "',Member='" + comboBox3.Text + "',Workout='" + comboBox4.Text + "',Fees_Mode='" + comboBox5.Text + "',Date='" + dateTimePicker1.Text + "',Fees='" + textBox6.Text + "',Day=" + stday + ",Month=" + stmonth + ",Year=" + styear + " where ID=" + ff_Code + "";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update Successfully");
                total();
                button12.Text = "&Save";
                

            }    
            else
            {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tbl_member(Name,Gender,Height,Weight,Contact,Alt_no,Batch,Member,Workout,Fees_Mode,Date,Fees,Day,Month,Year) values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + stday + "','" + stmonth + "','" + styear + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            con.Close();
           }
            clearing();
            funshow();
        }
        private void deleting()
        {
        }

        private void button12_Click(object sender, EventArgs e)
        {
            inserting();
            total();
        }

        private void button13_Click(object sender, EventArgs e)
        {
           panel3.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            funshow();
            total();
            
        }
        private void funshow()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_member";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;
            con.Close();
            totshow();
        }
        private void totshow()
        {
            int counting;
            int no1 = 0;
            counting = dataGridView1.Rows.Count;
            for (int k = 0; k < counting; k++)
            {
                no1 = no1 + 1;
            }
            
            label15.Text = "No. of Record :" + no1.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
                      
                int v1 = int.Parse(dataGridView1.Rows[r].Cells[0].Value.ToString());
                string na = dataGridView1.Rows[r].Cells[1].Value.ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from tbl_member where ID=" + v1 + "";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Has Been Deleted Successfully(" + na.ToUpper() + ")");
                con.Close();
                clearing();
                funshow();
                total();
            
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            r = e.RowIndex;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ff_Code = dataGridView1.Rows[r].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
            comboBox2.Text= dataGridView1.Rows[r].Cells[7].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[r].Cells[8].Value.ToString();
            comboBox4.Text= dataGridView1.Rows[r].Cells[9].Value.ToString();
            comboBox5.Text= dataGridView1.Rows[r].Cells[10].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[r].Cells[11].Value.ToString();
            textBox6.Text = dataGridView1.Rows[r].Cells[12].Value.ToString();
            textBox8.Text = dataGridView1.Rows[r].Cells[16].Value.ToString();
            button12.Text = "&Update";
            textBox1.Focus();
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }



       
        
       
        

        

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
        }
        private void total()
        {
            int sum = 0;
            for (int k = 0; k < dataGridView1.Rows.Count; ++k)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[k].Cells[12].Value);
            }

            label16.Text = "Total Amount :" + sum.ToString();
            //textBox7.Text = sum.ToString();
        }
       
        private void button13_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
  
                           
           
        }

        

       


        


       
        


       
       

       

    }
}
