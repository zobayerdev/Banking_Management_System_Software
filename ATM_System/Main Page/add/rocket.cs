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
    public partial class rocket : Form
    {
        public static int a;
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public int balan;
        public rocket()
        {
            InitializeComponent();
            balance();
        }

        public void balance()
        {
            con.Open();
            if (cc2 == 1)
            {
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT balance from reg_bank where username='" + cc + "'";
                cmd2.ExecuteNonQuery();
                rdr = cmd2.ExecuteReader();
                rdr.Read();
                balan = rdr.GetInt32(0);
            }

            else if (cc2 == 2)
            {
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "SELECT balance from reg_card where username='" + cc + "'";
                cmd3.ExecuteNonQuery();
                rdr = cmd3.ExecuteReader();
                rdr.Read();
                balan = rdr.GetInt32(0);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new otp().Show();
        }

        private void addb_Click(object sender, EventArgs e)
        {
            string TransactionID = "RKT" + DateTime.Now.Ticks.ToString().Substring(0, 10);
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            if (b1.Text != String.Empty && b2.Text != String.Empty && b3.Text != String.Empty && b4.Text != String.Empty)
            {
                string number = b1.Text;
                int amount = int.Parse(b2.Text);
                int otp = int.Parse(b3.Text);
                int pin = int.Parse(b4.Text);
                string type;
                string wallet = "Rocket";
                if (otp == a)
                {
                    if (cc2 == 1)
                    {
                        type = "Bank";
                        con.Open();
                        MySqlCommand cmd5 = con.CreateCommand();
                        cmd5.CommandType = CommandType.Text;
                        cmd5.CommandText = "INSERT INTO add_money (account_type, username, number, amount, wallet_type, transaction_id, date) VALUES(@account_type, @username, @number, @amount, @wallet_type, @transaction_id, @date)";
                        cmd5.Parameters.AddWithValue("@account_type", type);
                        cmd5.Parameters.AddWithValue("@username", cc);
                        cmd5.Parameters.AddWithValue("@number", number);
                        cmd5.Parameters.AddWithValue("@amount", amount);
                        cmd5.Parameters.AddWithValue("@wallet_type", wallet);
                        cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                        cmd5.Parameters.AddWithValue("@date", date);
                        cmd5.ExecuteNonQuery();
                        int sum = balan + amount;
                        MySqlCommand cmd4 = con.CreateCommand();
                        cmd4.CommandType = CommandType.Text;
                        cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                        cmd4.Parameters.AddWithValue("@UserID", cc);
                        cmd4.Parameters.AddWithValue("@Balance", sum);
                        cmd4.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Money added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else if (cc2 == 2)
                    {
                        type = "Card";
                        con.Open();
                        MySqlCommand cmd5 = con.CreateCommand();
                        cmd5.CommandType = CommandType.Text;
                        cmd5.CommandText = "INSERT INTO add_money (account_type, username, number, amount, wallet_type, transaction_id, date) VALUES(@account_type, @username, @number, @amount, @wallet_type, @transaction_id, @date)";
                        cmd5.Parameters.AddWithValue("@account_type", type);
                        cmd5.Parameters.AddWithValue("@username", cc);
                        cmd5.Parameters.AddWithValue("@number", number);
                        cmd5.Parameters.AddWithValue("@amount", amount);
                        cmd5.Parameters.AddWithValue("@wallet_type", wallet);
                        cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                        cmd5.Parameters.AddWithValue("@date", date);
                        cmd5.ExecuteNonQuery();
                        int sum = balan + amount;
                        MySqlCommand cmd4 = con.CreateCommand();
                        cmd4.CommandType = CommandType.Text;
                        cmd4.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                        cmd4.Parameters.AddWithValue("@UserID", cc);
                        cmd4.Parameters.AddWithValue("@Balance", sum);
                        cmd4.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Money added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("OTP didn't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter in all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
