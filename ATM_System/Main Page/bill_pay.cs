using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ATM_System.Main_Page
{
    public partial class bill_pay : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public bill_pay()
        {
            InitializeComponent();
            bill();
            cash();
            datagrid2.Hide();
        }
        public int pass, balance;
        public void cash()
        {
            con.Open();
            if (cc2 == 1)
            {
                label1.Show();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT pin, balance from reg_bank where username='" + cc + "'";
                cmd2.ExecuteNonQuery();
                rdr = cmd2.ExecuteReader();
                rdr.Read();
                pass = rdr.GetInt32(0);
                balance = rdr.GetInt32(1);
                label1.Text = balance.ToString() + " TK";
            }

            else if (cc2 == 2)
            {
                label1.Show();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "SELECT pin, balance from reg_card where username='" + cc + "'";
                cmd3.ExecuteNonQuery();
                rdr = cmd3.ExecuteReader();
                rdr.Read();
                pass = rdr.GetInt32(0);
                balance = rdr.GetInt32(1);
                label1.Text = balance.ToString() + " TK";
            }
            con.Close();
        }
        public void bill()
        {
            string x3 = "Unpaid";
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT bill_id, amount, status FROM demand_bill WHERE username = '" + cc + "' AND status = '" + x3 + "'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }

        public void history()
        {
            datagrid2.Show();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT bill_id, amount, date FROM bill_history WHERE username = '" + cc + "'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid2.DataSource = dt;
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(datagrid2.Visible)
            {
                datagrid2.Hide();
            }
            else
            {
                history();
            }
        }

        public string id, id2;

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        int amount, amount2, pass2;
        private void button2_Click(object sender, EventArgs e)
        {
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            con.Open();
            string x3 = "Unpaid";
            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT bill_id, amount from demand_bill where username='" + cc + "' AND status = '" + x3 + "'";
            cmd2.ExecuteNonQuery();
            rdr = cmd2.ExecuteReader();
            rdr.Read();
            id  = rdr.GetString(0);
            amount = int.Parse(rdr.GetString(1));
            con.Close();
            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
            {
                id2 = textBox1.Text;
                amount2 = int.Parse(textBox2.Text);
                pass2 = int.Parse(textBox3.Text);
                if (balance > amount)
                {
                    if (id2 == id)
                    {
                        if (amount == amount2)
                        {
                            if (pass == pass2)
                            {
                                string stat = "Paid";
                                con.Open();
                                MySqlCommand cmd;
                                cmd = con.CreateCommand();
                                cmd.CommandText = "INSERT INTO bill_history (username, bill_id, amount, date) VALUES(@username, @bill_id, @amount, @date)";
                                cmd.Parameters.AddWithValue("username", cc);
                                cmd.Parameters.AddWithValue("bill_id", id);
                                cmd.Parameters.AddWithValue("amount", amount);
                                cmd.Parameters.AddWithValue("date", date);
                                cmd.ExecuteReader();
                                con.Close();
                                con.Open();
                                MySqlCommand cmd4;
                                cmd4 = con.CreateCommand();
                                cmd4.CommandText = "UPDATE demand_bill SET status = '" + stat + "' WHERE username = '" + cc + "'";
                                cmd4.ExecuteReader();
                                con.Close();
                                MessageBox.Show("Bill Paid", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                history();
                                bill();
                                int x = balance - amount;
                                if (cc2 == 1)
                                {
                                    con.Open();
                                    MySqlCommand cmd5;
                                    cmd5 = con.CreateCommand();
                                    cmd5.CommandText = "UPDATE reg_bank SET balance = '" + x + "' WHERE username = '" + cc + "'";
                                    cmd5.ExecuteReader();
                                    con.Close();
                                    cash();
                                }
                                else if (cc2 == 2)
                                {
                                    con.Open();
                                    MySqlCommand cmd5;
                                    cmd5 = con.CreateCommand();
                                    cmd5.CommandText = "UPDATE reg_card SET balance = '" + x + "' WHERE username = '" + cc + "'";
                                    cmd5.ExecuteReader();
                                    con.Close();
                                    cash();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Pin didn't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Amount didn't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bill ID didn't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You can't pay. Your balance is low!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Insert in all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
