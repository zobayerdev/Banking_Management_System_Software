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

namespace ATM_System.Main_Page
{
    public partial class payment : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public int bal, pass;
        public payment()
        {
            InitializeComponent();
            datagrid.Hide();
            cash();
        }

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
                bal = rdr.GetInt32(1);
                label1.Text = bal.ToString() + " TK";
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
                bal = rdr.GetInt32(1);
                label1.Text = bal.ToString() + " TK";
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (datagrid.Visible)
            {
                datagrid.Hide();
            }
            else
            {
                datagrid.Show();
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT transaction_id, payment_id, amount, date FROM payment_history WHERE username = '" + cc + "'";
                MySqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();
                datagrid.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != String.Empty && textBox2.Text != String.Empty && textBox3.Text != String.Empty)
            {
                string TransactionID = "PYMNTAT" + DateTime.Now.Ticks.ToString().Substring(0, 10);
                string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                int pin = int.Parse(textBox2.Text);
                int bal2 = int.Parse(textBox3.Text);
                if(pin == pass)
                {
                    if (bal >= bal2)
                    {
                        if(cc2 == 1)
                        {
                            string acc = "Bank";
                            con.Open();
                            MySqlCommand cmd5 = con.CreateCommand();
                            cmd5.CommandType = CommandType.Text;
                            cmd5.CommandText = "INSERT INTO payment_history (account_type, username, payment_id, amount, transaction_id, date) VALUES(@account_type, @username, @payment_id, @amount, @transaction_id, @date)";
                            cmd5.Parameters.AddWithValue("@account_type", acc);
                            cmd5.Parameters.AddWithValue("@username", cc);
                            cmd5.Parameters.AddWithValue("@payment_id", textBox1.Text);
                            cmd5.Parameters.AddWithValue("@amount", bal2);
                            cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                            cmd5.Parameters.AddWithValue("@date", date);
                            cmd5.ExecuteNonQuery();
                            int sum = bal - bal2;
                            MySqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                            cmd4.Parameters.AddWithValue("@UserID", cc);
                            cmd4.Parameters.AddWithValue("@Balance", sum);
                            cmd4.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Payment Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cash();
                            textBox1.Clear();
                            textBox3.Clear();
                            textBox2.Clear();
                        }
                        else if(cc2 == 2)
                        {
                            string acc = "Card";
                            con.Open();
                            MySqlCommand cmd5 = con.CreateCommand();
                            cmd5.CommandType = CommandType.Text;
                            cmd5.CommandText = "INSERT INTO payment_history (account_type, username, payment_id, amount, transaction_id, date) VALUES(@account_type, @username, @payment_id, @amount, @transaction_id, @date)";
                            cmd5.Parameters.AddWithValue("@account_type", acc);
                            cmd5.Parameters.AddWithValue("@username", cc);
                            cmd5.Parameters.AddWithValue("@payment_id", textBox1.Text);
                            cmd5.Parameters.AddWithValue("@amount", bal2);
                            cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                            cmd5.Parameters.AddWithValue("@date", date);
                            cmd5.ExecuteNonQuery();
                            int sum = bal - bal2;
                            MySqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                            cmd4.Parameters.AddWithValue("@UserID", cc);
                            cmd4.Parameters.AddWithValue("@Balance", sum);
                            cmd4.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Payment Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cash();
                            textBox1.Clear();
                            textBox3.Clear();
                            textBox2.Clear();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Insufficient Balance!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("PIN didn't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter in all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
