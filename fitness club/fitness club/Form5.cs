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
    public partial class Form5 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Admin\Documents\gym_db.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int r1;
        string ff_Code_user;
        public Form5()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
        private void viewadjust()
        {
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            funshow_user();
        }

        private void clearing_user()
        {
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }
        private void funshow_user()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_User";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Visible = true;
            con.Close();
            totshow_user();
        }
        private void totshow_user()
        {
            int counting;
            int no1 = 0;
            counting = dataGridView2.Rows.Count;
            for (int k = 0; k < counting; k++)
            {
                no1 = no1 + 1;
            }

            label16.Text = "No. of Record :" + no1.ToString();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            insertin_user();
        }
        private void insertin_user()
        {
            if (button17.Text == "&Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update tbl_User set User_Name='" + textBox9.Text.ToUpper() + "',Password='" + textBox10.Text + "',Confirm='" + textBox11.Text + "' where ID=" + ff_Code_user + "";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update Successfully");
                button17.Text = "&Save";


            }
            else
            {

                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into tbl_User(User_Name,Password,Confirm) values('" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                con.Close();
            }
            clearing_user();
            funshow_user();
        }
      

        

       

        private void button16_Click(object sender, EventArgs e)
        {
              
       
            ff_Code_user = dataGridView2.Rows[r1].Cells[0].Value.ToString();
            textBox9.Text = dataGridView2.Rows[r1].Cells[1].Value.ToString();
            textBox10.Text = dataGridView2.Rows[r1].Cells[2].Value.ToString();
            textBox11.Text = dataGridView2.Rows[r1].Cells[3].Value.ToString();
            button17.Text = "&Update";
            textBox9.Focus();

        
        }

        private void button15_Click(object sender, EventArgs e)
        {
             
        
            int v2 = int.Parse(dataGridView2.Rows[r1].Cells[0].Value.ToString());
            string na1 = dataGridView2.Rows[r1].Cells[1].Value.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tbl_User where ID=" + v2 + "";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Has Been Deleted Successfully(" + na1.ToUpper() + ")");
            con.Close();
            clearing_user();
            funshow_user();

        
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            

            r1 = e.RowIndex;
        
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

       

        

             

    }
}
