using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using ATM_System.Main_Page;
using ATM_System.Main_Page.add;

namespace ATM_System
{
    public partial class original_main : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public static string x = Login.SetValueForText1;
        public static string y = Login.NAME;
        public static int gen = Login.gender;
        public static int qwe = Login.n;
        int panelWidth;
        int panelWidth2;
        bool Hidden;
        bool Hidden2;
        
        public original_main()
        {
            InitializeComponent();
            panel6.Hide();
            panelWidth = slide1.Width;
            panelWidth2 = slide2.Width;
            Hidden = false;
            Hidden2 = false;
            panel4.Hide();
            panel7.Hide();
            dp();
            dot();
            if (qwe == 1)
            {
                PBOX.Image = new Bitmap(@"D:\Varsity\Projects\ATM System C#\Saved AC\" + x + ".jpeg");
            }
            else if (qwe == 2)
            {
                PBOX.Image = new Bitmap(@"D:\Varsity\Projects\ATM System C#\Saved Card\" + x + ".jpeg");
            }
        }

        public void dot()
        {
            con.Open();
            string x3 = "Unpaid";
            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * from demand_bill where username='" + x + "' AND status = '" + x3 + "'";
            cmd2.ExecuteNonQuery();
            rdr = cmd2.ExecuteReader();
            rdr.Read();
            
            if(rdr.HasRows)
            {
                pictureBox3.Show();
                con.Close();
            }
            else
            {
                pictureBox3.Hide();
                con.Close();
            }
        }

        public void dp()
        {
            label2.Text = y;
            label3.Text = "@" + x;
            if (gen == 1)
            {
                pictureBox2.Image = new Bitmap(@"D:\Varsity\Projects\ATM System C#\Avatar\1.gif");
            }
            else if (gen == 2)
            {
                pictureBox2.Image = new Bitmap(@"D:\Varsity\Projects\ATM System C#\Avatar\2.gif");
            }
            else if (gen == 3)
            {
                pictureBox2.Image = new Bitmap(@"D:\Varsity\Projects\ATM System C#\Avatar\3.gif");
            }
            string x1 = @"D:\Varsity\Projects\ATM System C#\User Image (Bank)\" + x + ".jpg";
            string x2 = @"D:\Varsity\Projects\ATM System C#\User Image (Bank)\" + x + ".jpeg";
            string x3 = @"D:\Varsity\Projects\ATM System C#\User Image (Bank)\" + x + ".png";
            string x4 = @"D:\Varsity\Projects\ATM System C#\User Image (Card)\" + x + ".jpg";
            string x5 = @"D:\Varsity\Projects\ATM System C#\User Image (Card)\" + x + ".jpeg";
            string x6 = @"D:\Varsity\Projects\ATM System C#\User Image (Card)\" + x + ".png";
            FileInfo fileInfo1 = new FileInfo(x1);
            FileInfo fileInfo2 = new FileInfo(x2);
            FileInfo fileInfo3 = new FileInfo(x3);
            FileInfo fileInfo4 = new FileInfo(x4);
            FileInfo fileInfo5 = new FileInfo(x5);
            FileInfo fileInfo6 = new FileInfo(x6);

            if (fileInfo1.Exists)
            {
                pictureBox1.Image = new Bitmap(x1);
            }
            else if (fileInfo2.Exists)
            {
                pictureBox1.Image = new Bitmap(x2);
            }
            else if (fileInfo3.Exists)
            {
                pictureBox1.Image = new Bitmap(x3);
            }
            else if (fileInfo4.Exists)
            {
                pictureBox1.Image = new Bitmap(x4);
            }
            else if (fileInfo5.Exists)
            {
                pictureBox1.Image = new Bitmap(x5);
            }
            else if (fileInfo6.Exists)
            {
                pictureBox1.Image = new Bitmap(x6);
            }

        }

        
        private void original_main_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.Open();
            string x3 = "Unpaid";
            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * from demand_bill where username='" + x + "' AND status = '" + x3 + "'";
            cmd2.ExecuteNonQuery();
            rdr = cmd2.ExecuteReader();
            rdr.Read();
            
            if (rdr.HasRows)
            {
                pictureBox3.Show();
                con.Close();
            }
            else
            {
                pictureBox3.Hide();
                con.Close();
            }
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dp();
            timer2.Start();
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (Hidden)
            {
                slide1.Width = (slide1.Width + 10);
                if (slide1.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                slide1.Width = slide1.Width - 10;
                if (slide1.Width <= 0)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (Hidden2)
            {
                slide2.Width = slide2.Width + 10;
                if (slide2.Width >= panelWidth2)
                {
                    timer2.Stop();
                    Hidden2 = false;
                    this.Refresh();
                }
            }
            else
            {
                slide2.Width = slide2.Width - 10;
                if (slide2.Width <= 0)
                {
                    timer2.Stop();
                    Hidden2 = true;
                    this.Refresh();
                }
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            new end().Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (qwe == 1)
            {
                label4.Show();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT balance from reg_bank where username='" + x + "'";
                cmd2.ExecuteNonQuery();
                rdr = cmd2.ExecuteReader();
                rdr.Read();
                int bal = rdr.GetInt32(0);
                label4.Text = bal.ToString() + " TK";
                var t = new Timer();
                t.Interval = 2000;
                t.Tick += (s, en) =>
                {
                    label4.Hide();
                    t.Stop();
                };

                t.Start();
            }

            else if (qwe == 2)
            {
                label4.Show();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "SELECT balance from reg_card where username='" + x + "'";
                cmd3.ExecuteNonQuery();
                rdr = cmd3.ExecuteReader();
                rdr.Read();
                int bal = rdr.GetInt32(0);
                label4.Text = bal.ToString() + " TK";
                var t = new Timer();
                t.Interval = 2000;
                t.Tick += (s, en) =>
                {
                    label4.Hide();
                    t.Stop();
                };

                t.Start();
            }
            con.Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void b10_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            withdraw frm = new withdraw() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm);
            frm.Show();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            trasnfer frm2 = new trasnfer() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm2);
            frm2.Show();
        }

        private void b7_Click(object sender, EventArgs e)
        {
            
        }

        private void slide1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b10_1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b10_2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void b4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            bill_pay frm3 = new bill_pay() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm3);
            frm3.Show();
        }

        private void b5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            payment frm3 = new payment() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm3);
            frm3.Show();
        }

        private void b6_Click(object sender, EventArgs e)
        {
            if (panel4.Visible)
            {
                panel4.Hide();
            }
            else
            {
                panel4.Show();
            }
        }

        private void b8_Click(object sender, EventArgs e)
        {

        }

        private void b9_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new locker().Show();
        }

        private void slide2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(panel6.Visible)
            {
                panel6.Hide();
            }
            else
            {
                panel2.Controls.Clear();
                this.panel2.Controls.Add(panel6);
                panel6.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            contact.user = x;
            contact.name = y;
            contact.connector = 2;
            panel2.Controls.Clear();
            contact frm3 = new contact() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm3);
            frm3.Show();
        }

        private void b10_Click_1(object sender, EventArgs e)
        {
            if (panel7.Visible)
            {
                panel7.Hide();
            }
            else
            {
                panel7.Show();
            }
        }

        private void b10_1_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            update_pin frm3 = new update_pin() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm3);
            frm3.Show();
        }

        private void b10_2_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            updater frm3 = new updater() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm3);
            frm3.Show();
        }

        private void b9_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            donation frm3 = new donation() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm3);
            frm3.Show();
        }

        private void b7_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            add_money frm2 = new add_money() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm2);
            frm2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            create_crypto_wallet frm3 = new create_crypto_wallet() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm3);
            frm3.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            crypto_send frm3 = new crypto_send() { TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(frm3);
            frm3.Show();
        }
    }
}
