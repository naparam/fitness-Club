using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fitness_club
{
    public partial class Form1 : Form
    {
        bool flag;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flag = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 99)
            {
                if (flag)
                {
                    flag = false;
                    label1.Text = "Loading.";
                }
                else
                {
                    flag = true;
                    label1.Text = "Loading..";
                }
                progressBar1.Value += 10;
                if (progressBar1.Value > 50)
                {
                    timer2.Enabled = true;
                    timer2.Start();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.03;

            // MessageBox.Show(this.Opacity+"");
            if (this.Opacity <= 0)
            {
                timer2.Enabled = false;
                this.Visible = false;
                new Form2().Show();
            }   
        }
    }
}

