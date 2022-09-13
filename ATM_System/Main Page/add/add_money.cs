using ATM_System.Main_Page.add_money;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_System.Main_Page.add
{
    public partial class add_money : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public static int balance;
        public static int pass;
        public add_money()
        {
            InitializeComponent();
            panel1.Hide();
            cash();
        }

        public void cash()
        {
            con.Open();
            if (cc2 == 1)
            {
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT pin, balance from reg_bank where username='" + cc + "'";
                cmd2.ExecuteNonQuery();
                rdr = cmd2.ExecuteReader();
                rdr.Read();
                pass = rdr.GetInt32(0);
                balance = rdr.GetInt32(1);
            }

            else if (cc2 == 2)
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "SELECT pin, balance from reg_card where username='" + cc + "'";
                cmd3.ExecuteNonQuery();
                rdr = cmd3.ExecuteReader();
                rdr.Read();
                pass = rdr.GetInt32(0);
                balance = rdr.GetInt32(1);
            }
            con.Close();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if(panel1.Visible)
            {
                panel1.Hide();
            }
            else
            {
                panel1.Show();
                panel1.Controls.Clear();
                bkash frm2 = new bkash() { TopLevel = false, TopMost = true };
                this.panel1.Controls.Add(frm2);
                frm2.Show();
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Hide();
            }
            else
            {
                panel1.Show();
                panel1.Controls.Clear();
                rocket frm2 = new rocket() { TopLevel = false, TopMost = true };
                this.panel1.Controls.Add(frm2);
                frm2.Show();
            }
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Hide();
            }
            else
            {
                panel1.Show();
                panel1.Controls.Clear();
                nagad frm2 = new nagad() { TopLevel = false, TopMost = true };
                this.panel1.Controls.Add(frm2);
                frm2.Show();
            }
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Hide();
            }
            else
            {
                panel1.Show();
                panel1.Controls.Clear();
                upay frm2 = new upay() { TopLevel = false, TopMost = true };
                this.panel1.Controls.Add(frm2);
                frm2.Show();
            }
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Hide();
            }
            else
            {
                panel1.Show();
                panel1.Controls.Clear();
                card_use frm2 = new card_use() { TopLevel = false, TopMost = true };
                this.panel1.Controls.Add(frm2);
                frm2.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Hide();
            }
            else
            {
                panel1.Show();
                panel1.Controls.Clear();
                history_add frm2 = new history_add() { TopLevel = false, TopMost = true };
                this.panel1.Controls.Add(frm2);
                frm2.Show();
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
