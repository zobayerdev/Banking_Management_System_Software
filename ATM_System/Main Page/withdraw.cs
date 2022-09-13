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

namespace ATM_System
{
    public partial class withdraw : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public withdraw()
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
                cmd2.CommandText = "SELECT balance from reg_bank where username='" + cc + "'";
                cmd2.ExecuteNonQuery();
                rdr = cmd2.ExecuteReader();
                rdr.Read();
                int bal = rdr.GetInt32(0);
                label1.Text = bal.ToString() + " TK";
            }

            else if (cc2 == 2)
            {
                label1.Show();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "SELECT balance from reg_card where username='" + cc + "'";
                cmd3.ExecuteNonQuery();
                rdr = cmd3.ExecuteReader();
                rdr.Read();
                int bal = rdr.GetInt32(0);
                label1.Text = bal.ToString() + " TK";
            }
            con.Close();
        }
        private void withdraw_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public int sum;
        private void button2_Click(object sender, EventArgs e)
        {
            string TransactionID = "TRAATM" + DateTime.Now.Ticks.ToString().Substring(0, 10);
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text))
            {
                string message = "Enter in all the fields!";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                }
            }
            else
            {
                con.Open();
                
                if (cc2 == 1)
                {
                    int bal3 = int.Parse(textBox2.Text);
                    int bal4 = int.Parse(textBox1.Text);
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT pin, balance from reg_bank where username='" + cc + "'";
                    cmd2.ExecuteNonQuery();
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();
                    int bal = rdr.GetInt32(0);
                    int bal2 = rdr.GetInt32(1);
                    con.Close();
                    if (bal == bal3)
                    {
                        if (bal2 >= bal4)
                        {
                            sum = bal2 - bal4;
                            con.Open();
                            MySqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                            cmd4.Parameters.AddWithValue("@UserID", cc);
                            cmd4.Parameters.AddWithValue("@Balance", sum);
                            cmd4.ExecuteNonQuery();
                            con.Close();
                            string message = "Cashout Successful! Cashout amount = " + bal4 + "TK";
                            string title = "Success";
                            cash();
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                con.Open();
                                MySqlCommand cmd5 = con.CreateCommand();
                                cmd5.CommandType = CommandType.Text;
                                cmd5.CommandText = "INSERT INTO withdraw_history (account_type, username, ammount, transaction_id, date) VALUES(@account_type, @username, @ammount, @transaction_id, @date)";
                                string acc = "bank";
                                cmd5.Parameters.AddWithValue("@account_type", acc);
                                cmd5.Parameters.AddWithValue("@username", cc);
                                cmd5.Parameters.AddWithValue("@ammount", textBox1.Text);
                                cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                cmd5.Parameters.AddWithValue("@date", date);
                                cmd5.ExecuteNonQuery();
                                con.Close();
                                textBox1.Clear();
                                textBox2.Clear();
                            }
                        }
                        else
                        {
                            string message = "Insufficent Fund";
                            string title = "Low Fund";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                textBox1.Clear();
                                textBox2.Clear();
                            }
                        }
                    }
                    else
                    {
                        string message = "Password did'nt match!";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.OK)
                        {
                            textBox2.Clear();
                        }
                    }
                }

                else if (cc2 == 2)
                {
                    int bal3 = int.Parse(textBox2.Text);
                    int bal4 = int.Parse(textBox1.Text);
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT pin, balance from reg_card where username='" + cc + "'";
                    cmd2.ExecuteNonQuery();
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();
                    int bal = rdr.GetInt32(0);
                    int bal2 = rdr.GetInt32(1);
                    con.Close();
                    if (bal == bal3)
                    {
                        if (bal2 >= bal4)
                        {
                            sum = bal2 - bal4;
                            con.Open();
                            MySqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                            cmd4.Parameters.AddWithValue("@UserID", cc);
                            cmd4.Parameters.AddWithValue("@Balance", sum);
                            cmd4.ExecuteNonQuery();
                            con.Close();
                            string message = "Cashout Successful! Cashout amount = " + bal4 + "TK";
                            string title = "Success";
                            cash();
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                con.Open();
                                MySqlCommand cmd5 = con.CreateCommand();
                                cmd5.CommandType = CommandType.Text;
                                cmd5.CommandText = "INSERT INTO withdraw_history (account_type, username, ammount, transaction_id, date) VALUES(@account_type, @username, @ammount, @transaction_id, @date)";
                                string acc = "card";
                                cmd5.Parameters.AddWithValue("@account_type", acc);
                                cmd5.Parameters.AddWithValue("@username", cc);
                                cmd5.Parameters.AddWithValue("@ammount", textBox1.Text);
                                cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                cmd5.Parameters.AddWithValue("@date", date);
                                cmd5.ExecuteNonQuery();
                                con.Close();
                                textBox1.Clear();
                                textBox2.Clear();
                            }
                        }
                        else
                        {
                            string message = "Insufficent Fund";
                            string title = "Low Fund";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                textBox1.Clear();
                                textBox2.Clear();
                            }
                        }
                    }
                    else
                    {
                        string message = "Password did'nt match!";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.OK)
                        {
                            textBox2.Clear();
                        }
                    }
                }
                con.Close();
            }
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
                cmd.CommandText = "SELECT ammount, transaction_id, date FROM withdraw_history WHERE username = '" + cc + "'";
                MySqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();
                datagrid.DataSource = dt;
            }
        }
    }
}
