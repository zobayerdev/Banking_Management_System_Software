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
    public partial class donation : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public int bal, pass;
        public string name, phone;
        public donation()
        {
            InitializeComponent();
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
                bal = rdr.GetInt32(1);
                label6.Text = bal.ToString() + " TK";
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
                bal = rdr.GetInt32(1);
                label6.Text = bal.ToString() + " TK";
            }
            con.Close();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox1.Text = "Not interested";
                name = textBox1.Text;
                textBox4.Clear();
                textBox4.Text = "Not interested";
                phone = textBox4.Text;
            }
            else
            {
                name = textBox1.Text;
                phone = textBox4.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(combo.Text != string.Empty && textBox3.Text != string.Empty && textBox2.Text != string.Empty)
            {
                string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                int pin = int.Parse(textBox2.Text);
                int balance = int.Parse(textBox3.Text);
                if(pin == pass)
                {
                    if(bal >= balance)
                    {
                        if (cc2 == 1)
                        {
                            con.Open();
                            MySqlCommand cmd5 = con.CreateCommand();
                            cmd5.CommandType = CommandType.Text;
                            cmd5.CommandText = "INSERT INTO donation (username, donated_to, amount, name, phone_number, date) VALUES(@username, @donated_to, @amount, @name, @phone_number, @date)";
                            cmd5.Parameters.AddWithValue("@username", cc);
                            cmd5.Parameters.AddWithValue("@donated_to", combo.Text);
                            cmd5.Parameters.AddWithValue("@amount", balance);
                            cmd5.Parameters.AddWithValue("@name", name);
                            cmd5.Parameters.AddWithValue("@phone_number", phone);
                            cmd5.Parameters.AddWithValue("@date", date);
                            cmd5.ExecuteNonQuery();
                            int sum = bal - balance;
                            MySqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                            cmd4.Parameters.AddWithValue("@UserID", cc);
                            cmd4.Parameters.AddWithValue("@Balance", sum);
                            cmd4.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Donation Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cash();
                            textBox1.Clear();
                            textBox3.Clear();
                            textBox2.Clear();
                            textBox4.Clear();
                        }
                        else if (cc2 == 2)
                        {
                            con.Open();
                            MySqlCommand cmd5 = con.CreateCommand();
                            cmd5.CommandType = CommandType.Text;
                            cmd5.CommandText = "INSERT INTO donation (username, donated_to, amount, name, phone_number, date) VALUES(@username, @donated_to, @amount, @name, @phone_number, @date)";
                            cmd5.Parameters.AddWithValue("@username", cc);
                            cmd5.Parameters.AddWithValue("@donated_to", combo.Text);
                            cmd5.Parameters.AddWithValue("@amount", balance);
                            cmd5.Parameters.AddWithValue("@name", name);
                            cmd5.Parameters.AddWithValue("@phone_number", phone);
                            cmd5.Parameters.AddWithValue("@date", date);
                            cmd5.ExecuteNonQuery();
                            int sum = bal - balance;
                            MySqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                            cmd4.Parameters.AddWithValue("@UserID", cc);
                            cmd4.Parameters.AddWithValue("@Balance", sum);
                            cmd4.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Donation Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cash();
                            textBox1.Clear();
                            textBox3.Clear();
                            textBox2.Clear();
                            textBox4.Clear();
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
