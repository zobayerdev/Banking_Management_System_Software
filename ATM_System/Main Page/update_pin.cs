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
    public partial class update_pin : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string username = original_main.x;
        public int check_account = original_main.qwe;
        public update_pin()
        {
            InitializeComponent();
        }

        private void update_pin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox3.Text))
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
                if(check_account == 1)
                {
                    con.Open();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT pin from reg_bank where username='" + username + "'";
                    cmd2.ExecuteNonQuery();
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();
                    int orpin = rdr.GetInt32(0);
                    con.Close();
                    int bal = int.Parse(textBox1.Text);
                    if (bal == orpin)
                    {
                        if (int.Parse(textBox2.Text) == int.Parse(textBox3.Text))
                        {
                            con.Open();
                            MySqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "UPDATE reg_bank SET pin = @update_pin WHERE username = @UserID";
                            cmd4.Parameters.AddWithValue("@UserID", username);
                            cmd4.Parameters.AddWithValue("@update_pin", int.Parse(textBox3.Text));
                            cmd4.ExecuteNonQuery();
                            con.Close();
                            string message = "Pin Updated!";
                            string title = "Success";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                this.Hide();
                            }
                        }
                        else if(int.Parse(textBox2.Text) != int.Parse(textBox3.Text))
                        {
                            string message = "Pin didn't match!";
                            string title = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                    }

                    else
                    {
                        string message = "Pin doesn't exist";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.OK)
                        {

                        }
                    }
                }
                else if(check_account == 2)
                {
                    con.Open();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT pin from reg_card where username='" + username + "'";
                    cmd2.ExecuteNonQuery();
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();
                    int orpin = rdr.GetInt32(0);
                    con.Close();
                    int bal = int.Parse(textBox1.Text);
                    if (bal == orpin)
                    {
                        if (int.Parse(textBox2.Text) == int.Parse(textBox3.Text))
                        {
                            con.Open();
                            MySqlCommand cmd4 = con.CreateCommand();
                            cmd4.CommandType = CommandType.Text;
                            cmd4.CommandText = "UPDATE reg_card SET pin = @update_pin WHERE username = @UserID";
                            cmd4.Parameters.AddWithValue("@UserID", username);
                            cmd4.Parameters.AddWithValue("@update_pin", int.Parse(textBox3.Text));
                            cmd4.ExecuteNonQuery();
                            con.Close();
                            string message = "Pin Updated!";
                            string title = "Success";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                this.Hide();
                            }
                        }
                        else if (int.Parse(textBox2.Text) != int.Parse(textBox3.Text))
                        {
                            string message = "Pin didn't match!";
                            string title = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                textBox3.Clear();
                            }
                        }
                    }
                    else
                    {
                        string message = "Pin doesn't exist";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.OK)
                        {
                            textBox1.Clear();
                        }
                    }
                }
               
            }

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
