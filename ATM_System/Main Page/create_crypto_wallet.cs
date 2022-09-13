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
    public partial class create_crypto_wallet : Form
    {
        const string walletFilePath = @"Wallets\";
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public create_crypto_wallet()
        {
            InitializeComponent();
            datagrid.Hide();
            label1.Hide();
            button2.Hide();
            guna2TextBox5.Hide();
            label5.Hide();
            label9.Hide();
            label4.Hide();
            txt3.Hide();
            guna2TextBox3.Hide();
            guna2TextBox2.Hide();
        }
        public void data()
        {
            label1.Hide();
            guna2TextBox5.Hide();
            button2.Hide();
            datagrid.Show();
            con.Open();
            MySqlCommand cmd4;
            cmd4 = con.CreateCommand();
            cmd4.CommandText = "SELECT * FROM wallet_history WHERE username = '" + cc + "'";
            MySqlDataReader sdr2 = cmd4.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(sdr2);
            con.Close();
            datagrid.DataSource = dt2;
        }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(guna2TextBox1.Text) && String.IsNullOrEmpty(guna2TextBox4.Text))
            {
                string message = "Please Input All The Required Values!";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            else
            {
                Network currentNetwork = Network.TestNet;
                string pw = guna2TextBox1.Text;
                bool failure = true;
                try
                {
                    string walletName = guna2TextBox4.Text;
                    Mnemonic mnemonic;
                    Safe safe = Safe.Create(out mnemonic, pw, walletFilePath + walletName + ".json", currentNetwork);
                    string wallet_address = safe.GetAddress(0).ToString();
                    label5.Show();
                    label9.Show();
                    label4.Show();
                    txt3.Show();
                    guna2TextBox3.Show();
                    guna2TextBox2.Show();
                    txt3.Text = wallet_address;
                    string private_key = safe.FindPrivateKey(safe.GetAddress(0)).ToString();
                    guna2TextBox2.Text = private_key;
                    guna2TextBox3.Text = mnemonic.ToString();

                    con.Open();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO wallet_history (username, account_type, wallet_name, wallet_address, wallet_pin, private_key, mnemonic) VALUES(@username, @account_type, @wallet_name, @wallet_address, @wallet_pin, @private_key, @mnemonic)";
                    cmd2.Parameters.AddWithValue("username", cc);
                    string type_of = "";
                    if(cc2==1)
                    {
                        type_of = "Bank";
                    }
                    else if(cc2==2)
                    {
                        type_of = "Card";
                    }
                    cmd2.Parameters.AddWithValue("account_type", type_of);
                    cmd2.Parameters.AddWithValue("wallet_name", walletName);
                    cmd2.Parameters.AddWithValue("wallet_address", wallet_address);
                    cmd2.Parameters.AddWithValue("wallet_pin", pw);
                    cmd2.Parameters.AddWithValue("private_key", private_key);
                    cmd2.Parameters.AddWithValue("mnemonic", mnemonic.ToString());
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    failure = false;
                    string message = "Wallet Created Successfully!";
                    string title = "Success";
                    data();
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                }
                catch
                {
                    string message = "Wallet Name Exist!";
                    string title = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void money_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (label1.Visible && guna2TextBox5.Visible && button2.Visible && datagrid.Visible)
            {
                label1.Hide();
                datagrid.Hide();
                guna2TextBox5.Hide();
                button2.Hide();
            }
            else
            {
                label1.Show();
                guna2TextBox5.Show();
                button2.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text != string.Empty)
            {
                if (cc2 == 1)
                {
                    con.Open();
                    label1.Show();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT pin from reg_bank where username='" + cc + "'";
                    cmd2.ExecuteNonQuery();
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();
                    string bal = rdr.GetString(0);
                    con.Close();
                    if (bal != guna2TextBox5.Text)
                    {
                        string message = "Password or Username didn't match!";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        guna2TextBox5.Clear();
                        if (datagrid.Visible)
                        {
                            datagrid.Hide();
                        }
                        else
                        {
                            data();
                        }
                    }
                }
                else if (cc2 == 2)
                {
                    con.Open();
                    label1.Show();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT pin from reg_card where username='" + cc + "'";
                    cmd2.ExecuteNonQuery();
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();
                    string bal = rdr.GetString(0);
                    con.Close();
                    if (bal != guna2TextBox5.Text)
                    {
                        string message = "Password or Username didn't match!";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        guna2TextBox5.Clear();
                        if (datagrid.Visible)
                        {
                            datagrid.Hide();
                        }
                        else
                        {
                            data();
                        }
                    }
                }
            }
            else
            {
                string message1 = "Please enter value in all field.";
                string title1 = "Error";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Warning);
            }
        }
    }
}