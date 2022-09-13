using MySql.Data.MySqlClient;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using HBitcoin.FullBlockSpv;
using HBitcoin.KeyManagement;
using HBitcoin.Models;
using QBitNinja.Client;
using QBitNinja.Client.Models;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_System.Main_Page
{
    public partial class crypto_send : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public Double btc;
        public Double eth;
        public Double ada;
        public Double sol;
        public int balance;
        public int pass;
        public crypto_send()
        {
            InitializeComponent();
            panel1.Hide();
            con.Open();
            MySqlCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "SELECT wallet_address from wallet_history where username='" + cc + "'";
            cmd3.ExecuteNonQuery();
            rdr = cmd3.ExecuteReader();
            while (rdr.Read())
            {
                combob.Items.Add(rdr[0]);
            }
            con.Close();
            datagrid.Hide();
            cash();
            rates();
            data();
        }

        public void data()
        {
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT sender_address, reciever_ad, amount_bought, currency, transaction_id, date FROM crypto_history WHERE username = '" + cc + "'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }
        public void rates()
        {
            con.Open();
            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT * from crypto_price";
            cmd2.ExecuteNonQuery();
            rdr = cmd2.ExecuteReader();
            rdr.Read();

            String btc1 = rdr.GetString(0);
            String eth1 = rdr.GetString(1);
            String ada1 = rdr.GetString(2);
            String sol1 = rdr.GetString(3);

            btc = Double.Parse(btc1);
            eth = Double.Parse(eth1);
            ada = Double.Parse(ada1);
            sol = Double.Parse(sol1);

            rate.Text = btc.ToString() + " BDT";
            rate2.Text = eth.ToString() + " BDT";
            rate3.Text = ada.ToString() + " BDT";
            rate4.Text = sol.ToString() + " BDT";
            con.Close();
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
                money.Text = balance.ToString() + " TK";
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
                money.Text = balance.ToString() + " TK";
            }
            con.Close();
        }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {

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
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (datagrid.Visible)
            {
                datagrid.Hide();
            }
            else
            {
                panel1.Hide();
                datagrid.Show();
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            string selected = combob.Text;
            string TransactionID = "CRYATM" + DateTime.Now.Ticks.ToString().Substring(0, 10);
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");

            if (String.IsNullOrEmpty(txt1.Text) && String.IsNullOrEmpty(txt2.Text) && String.IsNullOrEmpty(txt3.Text) && String.IsNullOrEmpty(combo.Text))
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
                int amount = int.Parse(txt1.Text);
                String m = combo.Text;
                int pass2 = int.Parse(txt2.Text);
                if (pass == pass2)
                {
                    if (cc2 == 1)
                    {
                        if (m == "Bitcoin")
                        {
                            if (balance < amount)
                            {
                                string message = "Balance is low!";
                                string title = "Error";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                }
                            }
                            else
                            {
                                double x = (amount / btc);
                                int sum = balance - amount;
                                con.Open();
                                MySqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                                cmd4.Parameters.AddWithValue("@UserID", cc);
                                cmd4.Parameters.AddWithValue("@Balance", sum);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                string message = "Bitcoin bought = " + x + "BTC";
                                string title = "Success";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    string acc = "Bank";
                                    string qq = "Bitcoin";
                                    con.Open();
                                    MySqlCommand cmd5 = con.CreateCommand();
                                    cmd5.CommandType = CommandType.Text;
                                    cmd5.CommandText = "INSERT INTO crypto_history (username, account_type, sender_address, reciever_ad, amount_bought, currency, transaction_id, date) VALUES(@username, @account_type, @sender_address, @wallet_ad, @amount_bought, @currency, @transaction_id, @date)";
                                    cmd5.Parameters.AddWithValue("@username", cc);
                                    cmd5.Parameters.AddWithValue("@account_type", acc);
                                    cmd5.Parameters.AddWithValue("@sender_address", selected);
                                    cmd5.Parameters.AddWithValue("@wallet_ad", txt3.Text);
                                    cmd5.Parameters.AddWithValue("@amount_bought", x);
                                    cmd5.Parameters.AddWithValue("@currency", qq);
                                    cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                    cmd5.Parameters.AddWithValue("@date", date);
                                    cmd5.ExecuteNonQuery();
                                    con.Close();
                                    panel1.Hide();
                                    data();
                                    cash();
                                    datagrid.Show();
                                    txt1.Clear();
                                    txt2.Clear();
                                    txt3.Clear();
                                }
                            }
                        }
                        else if (m == "Ethereum")
                        {
                            if (balance < amount)
                            {
                                string message = "Balance is low!";
                                string title = "Error";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                }
                            }
                            else
                            {
                                double x = amount / eth;
                                int sum = balance - amount;
                                con.Open();
                                MySqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                                cmd4.Parameters.AddWithValue("@UserID", cc);
                                cmd4.Parameters.AddWithValue("@Balance", sum);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                string message = "Ethereum bought = " + x + "ETH";
                                string title = "Success";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    string acc = "Bank";
                                    string qq = "Ethereum";
                                    con.Open();
                                    MySqlCommand cmd5 = con.CreateCommand();
                                    cmd5.CommandType = CommandType.Text;
                                    cmd5.CommandText = "INSERT INTO crypto_history (username, account_type, sender_address, reciever_ad, amount_bought, currency, transaction_id, date) VALUES(@username, @account_type, @sender_address, @wallet_ad, @amount_bought, @currency, @transaction_id, @date)";
                                    cmd5.Parameters.AddWithValue("@username", cc);
                                    cmd5.Parameters.AddWithValue("@account_type", acc);
                                    cmd5.Parameters.AddWithValue("@sender_address", selected);
                                    cmd5.Parameters.AddWithValue("@wallet_ad", txt3.Text);
                                    cmd5.Parameters.AddWithValue("@amount_bought", x);
                                    cmd5.Parameters.AddWithValue("@currency", qq);
                                    cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                    cmd5.Parameters.AddWithValue("@date", date);
                                    cmd5.ExecuteNonQuery();
                                    con.Close();
                                    panel1.Hide();
                                    data();
                                    cash();
                                    datagrid.Show();
                                    txt1.Clear();
                                    txt2.Clear();
                                    txt3.Clear();
                                }
                            }
                        }
                        else if (m == "Cardano")
                        {
                            if (balance < amount)
                            {
                                string message = "Balance is low!";
                                string title = "Error";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                }
                            }
                            else
                            {
                                double x = amount / ada;
                                int sum = balance - amount;
                                con.Open();
                                MySqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                                cmd4.Parameters.AddWithValue("@UserID", cc);
                                cmd4.Parameters.AddWithValue("@Balance", sum);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                string message = "Cardano bought = " + x + "ADA";
                                string title = "Success";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    string acc = "Bank";
                                    string qq = "Cardano";
                                    con.Open();
                                    MySqlCommand cmd5 = con.CreateCommand();
                                    cmd5.CommandType = CommandType.Text;
                                    cmd5.CommandText = "INSERT INTO crypto_history (username, account_type, sender_address, reciever_ad, amount_bought, currency, transaction_id, date) VALUES(@username, @account_type, @sender_address, @wallet_ad, @amount_bought, @currency, @transaction_id, @date)";
                                    cmd5.Parameters.AddWithValue("@username", cc);
                                    cmd5.Parameters.AddWithValue("@account_type", acc);
                                    cmd5.Parameters.AddWithValue("@sender_address", selected);
                                    cmd5.Parameters.AddWithValue("@wallet_ad", txt3.Text);
                                    cmd5.Parameters.AddWithValue("@amount_bought", x);
                                    cmd5.Parameters.AddWithValue("@currency", qq);
                                    cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                    cmd5.Parameters.AddWithValue("@date", date);
                                    cmd5.ExecuteNonQuery();
                                    con.Close();
                                    panel1.Hide();
                                    data();
                                    cash();
                                    datagrid.Show();
                                    txt1.Clear();
                                    txt2.Clear();
                                    txt3.Clear();
                                }
                            }
                        }
                        else if (m == "Solana")
                        {
                            if (balance < amount)
                            {
                                string message = "Balance is low!";
                                string title = "Error";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                }
                            }
                            else
                            {
                                double x = amount / sol;
                                int sum = balance - amount;
                                con.Open();
                                MySqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                                cmd4.Parameters.AddWithValue("@UserID", cc);
                                cmd4.Parameters.AddWithValue("@Balance", sum);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                string message = "Solana bought = " + x + "SOL";
                                string title = "Success";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    string acc = "Bank";
                                    string qq = "Solana";
                                    con.Open();
                                    MySqlCommand cmd5 = con.CreateCommand();
                                    cmd5.CommandType = CommandType.Text;
                                    cmd5.CommandText = "INSERT INTO crypto_history (username, account_type, sender_address, reciever_ad, amount_bought, currency, transaction_id, date) VALUES(@username, @account_type, @sender_address, @wallet_ad, @amount_bought, @currency, @transaction_id, @date)";
                                    cmd5.Parameters.AddWithValue("@username", cc);
                                    cmd5.Parameters.AddWithValue("@account_type", acc);
                                    cmd5.Parameters.AddWithValue("@sender_address", selected);
                                    cmd5.Parameters.AddWithValue("@wallet_ad", txt3.Text);
                                    cmd5.Parameters.AddWithValue("@amount_bought", x);
                                    cmd5.Parameters.AddWithValue("@currency", qq);
                                    cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                    cmd5.Parameters.AddWithValue("@date", date);
                                    cmd5.ExecuteNonQuery();
                                    con.Close();
                                    panel1.Hide();
                                    data();
                                    cash();
                                    datagrid.Show();
                                    txt1.Clear();
                                    txt2.Clear();
                                    txt3.Clear();
                                }
                            }
                        }
                    }
                    else if (cc2 == 2)
                    {
                        if (m == "Bitcoin")
                        {
                            if (balance < amount)
                            {
                                string message = "Balance is low!";
                                string title = "Error";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                }
                            }
                            else
                            {
                                double x = amount / btc;
                                int sum = balance - amount;
                                con.Open();
                                MySqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                                cmd4.Parameters.AddWithValue("@UserID", cc);
                                cmd4.Parameters.AddWithValue("@Balance", sum);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                string message = "Bitcoin bought = " + x + "BTC";
                                string title = "Success";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    string acc = "Card";
                                    string qq = "Bitcoin";
                                    con.Open();
                                    MySqlCommand cmd5 = con.CreateCommand();
                                    cmd5.CommandType = CommandType.Text;
                                    cmd5.CommandText = "INSERT INTO crypto_history (username, account_type, sender_address, reciever_ad, amount_bought, currency, transaction_id, date) VALUES(@username, @account_type, @sender_address, @wallet_ad, @amount_bought, @currency, @transaction_id, @date)";
                                    cmd5.Parameters.AddWithValue("@username", cc);
                                    cmd5.Parameters.AddWithValue("@account_type", acc);
                                    cmd5.Parameters.AddWithValue("@sender_address", selected);
                                    cmd5.Parameters.AddWithValue("@wallet_ad", txt3.Text);
                                    cmd5.Parameters.AddWithValue("@amount_bought", x);
                                    cmd5.Parameters.AddWithValue("@currency", qq);
                                    cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                    cmd5.Parameters.AddWithValue("@date", date);
                                    cmd5.ExecuteNonQuery();
                                    con.Close();
                                    panel1.Hide();
                                    data();
                                    cash();
                                    datagrid.Show();
                                    txt1.Clear();
                                    txt2.Clear();
                                    txt3.Clear();
                                }
                            }
                        }
                        else if (m == "Ethereum")
                        {
                            if (balance < amount)
                            {
                                string message = "Balance is low!";
                                string title = "Error";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                }
                            }
                            else
                            {
                                double x = amount / eth;
                                int sum = balance - amount;
                                con.Open();
                                MySqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                                cmd4.Parameters.AddWithValue("@UserID", cc);
                                cmd4.Parameters.AddWithValue("@Balance", sum);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                string message = "Ethereum bought = " + x + "ETH";
                                string title = "Success";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    string acc = "Card";
                                    string qq = "Ethereum";
                                    con.Open();
                                    MySqlCommand cmd5 = con.CreateCommand();
                                    cmd5.CommandType = CommandType.Text;
                                    cmd5.CommandText = "INSERT INTO crypto_history (username, account_type, sender_address, reciever_ad, amount_bought, currency, transaction_id, date) VALUES(@username, @account_type, @sender_address, @wallet_ad, @amount_bought, @currency, @transaction_id, @date)";
                                    cmd5.Parameters.AddWithValue("@username", cc);
                                    cmd5.Parameters.AddWithValue("@account_type", acc);
                                    cmd5.Parameters.AddWithValue("@sender_address", selected);
                                    cmd5.Parameters.AddWithValue("@wallet_ad", txt3.Text);
                                    cmd5.Parameters.AddWithValue("@amount_bought", x);
                                    cmd5.Parameters.AddWithValue("@currency", qq);
                                    cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                    cmd5.Parameters.AddWithValue("@date", date);
                                    cmd5.ExecuteNonQuery();
                                    con.Close();
                                    panel1.Hide();
                                    data();
                                    cash();
                                    datagrid.Show();
                                    txt1.Clear();
                                    txt2.Clear();
                                    txt3.Clear();
                                }
                            }
                        }
                        else if (m == "Cardano")
                        {
                            if (balance < amount)
                            {
                                string message = "Balance is low!";
                                string title = "Error";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                }
                            }
                            else
                            {
                                double x = amount / ada;
                                int sum = balance - amount;
                                con.Open();
                                MySqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                                cmd4.Parameters.AddWithValue("@UserID", cc);
                                cmd4.Parameters.AddWithValue("@Balance", sum);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                string message = "Cardano bought = " + x + "ADA";
                                string title = "Success";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    string acc = "Card";
                                    string qq = "Cardano";
                                    con.Open();
                                    MySqlCommand cmd5 = con.CreateCommand();
                                    cmd5.CommandType = CommandType.Text;
                                    cmd5.CommandText = "INSERT INTO crypto_history (username, account_type, sender_address, reciever_ad, amount_bought, currency, transaction_id, date) VALUES(@username, @account_type, @sender_address, @wallet_ad, @amount_bought, @currency, @transaction_id, @date)";
                                    cmd5.Parameters.AddWithValue("@username", cc);
                                    cmd5.Parameters.AddWithValue("@account_type", acc);
                                    cmd5.Parameters.AddWithValue("@sender_address", selected);
                                    cmd5.Parameters.AddWithValue("@wallet_ad", txt3.Text);
                                    cmd5.Parameters.AddWithValue("@amount_bought", x);
                                    cmd5.Parameters.AddWithValue("@currency", qq);
                                    cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                    cmd5.Parameters.AddWithValue("@date", date);
                                    cmd5.ExecuteNonQuery();
                                    con.Close();
                                    panel1.Hide();
                                    data();
                                    cash();
                                    datagrid.Show();
                                    txt1.Clear();
                                    txt2.Clear();
                                    txt3.Clear();
                                }
                            }
                        }
                        else if (m == "Solana")
                        {
                            if (balance < amount)
                            {
                                string message = "Balance is low!";
                                string title = "Error";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                }
                            }
                            else
                            {
                                double x = amount / sol;
                                int sum = balance - amount;
                                con.Open();
                                MySqlCommand cmd4 = con.CreateCommand();
                                cmd4.CommandType = CommandType.Text;
                                cmd4.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                                cmd4.Parameters.AddWithValue("@UserID", cc);
                                cmd4.Parameters.AddWithValue("@Balance", sum);
                                cmd4.ExecuteNonQuery();
                                con.Close();
                                string message = "Solana bought = " + x + "SOL";
                                string title = "Success";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    string acc = "Card";
                                    string qq = "Solana";
                                    con.Open();
                                    MySqlCommand cmd5 = con.CreateCommand();
                                    cmd5.CommandType = CommandType.Text;
                                    cmd5.CommandText = "INSERT INTO crypto_history (username, account_type, sender_address, reciever_ad, amount_bought, currency, transaction_id, date) VALUES(@username, @account_type, @sender_address, @wallet_ad, @amount_bought, @currency, @transaction_id, @date)";
                                    cmd5.Parameters.AddWithValue("@username", cc);
                                    cmd5.Parameters.AddWithValue("@account_type", acc);
                                    cmd5.Parameters.AddWithValue("@sender_address", selected);
                                    cmd5.Parameters.AddWithValue("@wallet_ad", txt3.Text);
                                    cmd5.Parameters.AddWithValue("@amount_bought", x);
                                    cmd5.Parameters.AddWithValue("@currency", qq);
                                    cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                                    cmd5.Parameters.AddWithValue("@date", date);
                                    cmd5.ExecuteNonQuery();
                                    con.Close();
                                    panel1.Hide();
                                    data();
                                    cash();
                                    datagrid.Show();
                                    txt1.Clear();
                                    txt2.Clear();
                                    txt3.Clear();
                                }
                            }
                        }
                    }
                }
                else
                {
                    string message = "PIN didn't match!";
                    string title = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.OK)
                    {
                    }

                }
            }
        }
    }
}