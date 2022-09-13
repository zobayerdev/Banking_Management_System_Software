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
    public partial class contact : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public static int connector;
        public int cc2 = original_main.qwe;
        public static string user = "";
        public static string name = "";
        public string email = "";
        public contact()
        {
            InitializeComponent();
            button1.Hide();
            guna2CircleButton1.Hide();
            if (connector == 1)
            {
                textBox2.Text = "Guest";
                textBox2.ReadOnly = true;
                button1.Show();
                guna2CircleButton1.Show();
            }
            else if (connector == 2)
            {
                con.Open();
                if (cc2 == 1)
                {
                    label4.Show();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT email from reg_bank where username='" + user + "'";
                    cmd2.ExecuteNonQuery();
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();
                    email = rdr.GetString(0);
                }

                else if (cc2 == 2)
                {
                    label4.Show();
                    MySqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "SELECT email from reg_card where username='" + user + "'";
                    cmd3.ExecuteNonQuery();
                    rdr = cmd3.ExecuteReader();
                    rdr.Read();
                    email = rdr.GetString(0);
                }
                con.Close();
                textBox3.Text = email;
                nametxt.Text = name;
                textBox2.Text = user;
                button1.Hide();
                guna2CircleButton1.Hide();
            }
        }

        private void PBOX_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Front_Page().Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            new end().Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(connector == 1)
            {
                if (nametxt.Text != string.Empty && textBox1.Text != string.Empty && textBox3.Text != string.Empty)
                {
                    con.Open();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO ratings (name, email, username, queries) VALUES(@name, @email, @username, @queries)";
                    cmd2.Parameters.AddWithValue("name", nametxt.Text);
                    cmd2.Parameters.AddWithValue("email", textBox3.Text);
                    string c = "Guest";
                    cmd2.Parameters.AddWithValue("username", c);
                    cmd2.Parameters.AddWithValue("queries", textBox1.Text);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thanks for your query. Our admin will contact you ASAP!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter values in all field!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (connector == 2)
            {
                if (nametxt.Text != string.Empty && textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty)
                {
                    con.Open();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO ratings (name, email, username, queries) VALUES(@name, @email, @username, @queries)";
                    cmd2.Parameters.AddWithValue("name", nametxt.Text);
                    cmd2.Parameters.AddWithValue("email", textBox3.Text);
                    cmd2.Parameters.AddWithValue("username", textBox2.Text);
                    cmd2.Parameters.AddWithValue("queries", textBox1.Text);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thanks for your query. Our admin will contact you ASAP!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter values in all field!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void guna2RatingStar1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
