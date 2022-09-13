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
    public partial class card_use : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public int bal = add_money.balance;
        public int pass = add_money.pass;
        public card_use()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addb_Click(object sender, EventArgs e)
        {
            string TransactionID = "ADDCAR" + DateTime.Now.Ticks.ToString().Substring(0, 10);
            string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
            if (b1.Text != String.Empty && b2.Text != String.Empty && b3.Text != String.Empty && b4.Text != String.Empty && b5.Text != String.Empty)
            {
                string card_no = b1.Text;
                string valid = datepick.Text;
                string cvv = b2.Text;
                string name = b3.Text;
                int amount = int.Parse(b4.Text);
                int pin = int.Parse(b5.Text);
                string type;

                if (pass == pin)
                {
                    if(cc2 == 1)
                    {
                        type = "Bank";
                        con.Open();
                        MySqlCommand cmd5 = con.CreateCommand();
                        cmd5.CommandType = CommandType.Text;
                        cmd5.CommandText = "INSERT INTO add_from_card (account_type, username, transaction_id, amount, card_no, name_on_card, expiry, cvv_cvc, date) VALUES(@account_type, @username, @transaction_id, @amount, @card_no, @name_on_card, @expiry, @cvv_cvc, @date)";
                        cmd5.Parameters.AddWithValue("@account_type", type);
                        cmd5.Parameters.AddWithValue("@username", cc);
                        cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                        cmd5.Parameters.AddWithValue("@amount", amount);
                        cmd5.Parameters.AddWithValue("@card_no", card_no);
                        cmd5.Parameters.AddWithValue("@name_on_card", name);
                        cmd5.Parameters.AddWithValue("@expiry", valid);
                        cmd5.Parameters.AddWithValue("@cvv_cvc", cvv);
                        cmd5.Parameters.AddWithValue("@date", date);
                        cmd5.ExecuteNonQuery();
                        int sum = bal + amount;
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
                        cmd5.CommandText = "INSERT INTO add_from_card (account_type, username, transaction_id, amount, card_no, name_on_card, expiry, cvv_cvc, date) VALUES(@account_type, @username, @transaction_id, @amount, @card_no, @name_on_card, @expiry, @cvv_cvc, @date)";
                        cmd5.Parameters.AddWithValue("@account_type", type);
                        cmd5.Parameters.AddWithValue("@username", cc);
                        cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                        cmd5.Parameters.AddWithValue("@amount", amount);
                        cmd5.Parameters.AddWithValue("@card_no", card_no);
                        cmd5.Parameters.AddWithValue("@name_on_card", name);
                        cmd5.Parameters.AddWithValue("@expiry", valid);
                        cmd5.Parameters.AddWithValue("@cvv_cvc", cvv);
                        cmd5.Parameters.AddWithValue("@date", date);
                        cmd5.ExecuteNonQuery();
                        int sum = bal + amount;
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
                    MessageBox.Show("PIN didn't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    b5.Clear();
                }
            }
            else
            {
                MessageBox.Show("Insert in all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bl4_Click(object sender, EventArgs e)
        {

        }

        private void b4_TextChanged(object sender, EventArgs e)
        {

        }

        private void b3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bl2_Click(object sender, EventArgs e)
        {

        }

        private void bl1_Click(object sender, EventArgs e)
        {

        }

        private void bl3_Click(object sender, EventArgs e)
        {

        }

        private void b1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
