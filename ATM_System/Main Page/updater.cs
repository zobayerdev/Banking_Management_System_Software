using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_System.Main_Page
{
    public partial class updater : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;


        public static string name;
        public static string phone;
        public static string permanent_ad;
        public static string present_ad;
        public static int gender;
        public static int nid;
        public static string occupation;
        public static int monthly_income;
        public static string user;
        public static int pin;
        public static string sex;


        public updater()
        {
            InitializeComponent();
            getdata();
            loaddata();
        }

        public void getdata()
        {
            con.Open();
            if (cc2 == 1)
            {
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT * from reg_bank where username='" + cc + "'";
                cmd2.ExecuteNonQuery();
                rdr = cmd2.ExecuteReader();
                rdr.Read();
                name = rdr.GetString("name");
                phone = rdr.GetString("phone");
                permanent_ad = rdr.GetString("permanent_ad");
                present_ad = rdr.GetString("present_ad");
                gender = rdr.GetInt32("gender");
                nid = rdr.GetInt32("nid");
                occupation = rdr.GetString("occupation");
                monthly_income = rdr.GetInt32("monthly_income");
                user = rdr.GetString("username");
                pin = rdr.GetInt32("pin");
            }

            else if (cc2 == 2)
            {
                label1.Show();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "SELECT * from reg_card where username='" + cc + "'";
                cmd3.ExecuteNonQuery();
                rdr = cmd3.ExecuteReader();
                rdr.Read();
                name = rdr.GetString("name");
                phone = rdr.GetString("phone");
                permanent_ad = rdr.GetString("permanent_ad");
                present_ad = rdr.GetString("present_ad");
                gender = rdr.GetInt32("gender");
                nid = rdr.GetInt32("nid");
                occupation = rdr.GetString("occupation");
                monthly_income = rdr.GetInt32("monthly_income");
                user = rdr.GetString("username");
                pin = rdr.GetInt32("pin");
            }
            con.Close();
        }

        public void loaddata()
        {
            textBox1.Text = name;
            textBox2.Text = phone;
            textBox3.Text = permanent_ad;
            textBox4.Text = present_ad;
            if(gender == 1)
            {
                sex = "Male";
                comboBox1.SelectedIndex = comboBox1.FindStringExact(sex);
            }
            else if (gender == 2)
            {
                sex = "Female";
                comboBox1.SelectedIndex = comboBox1.FindStringExact(sex);
            }
            else if (gender == 3)
            {
                sex = "Others";
                comboBox1.SelectedIndex = comboBox1.FindStringExact(sex);
            }
            textBox5.Text = nid.ToString();
            textBox6.Text = occupation;
            textBox7.Text = monthly_income.ToString();
            textBox9.Text = user;
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty & textBox7.Text != string.Empty && textBox9.Text != string.Empty)
            {
                if(textBox8.Text != string.Empty)
                {
                    int pass = int.Parse(textBox8.Text);
                    if(pin == pass)
                    {
                        if(cc2 == 1)
                        {
                            string x = comboBox1.Text;
                            string male = "Male";
                            string female = "Female";
                            string others = "Others";
                            con.Open();
                            MySqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "UPDATE reg_bank SET name = @name, phone = @phone, permanent_ad = @permanent_ad, present_ad = @present_ad, gender = @gender, nid = @nid, occupation = @occupation, monthly_income = @monthly_income, username = @username WHERE username = '" + cc + "'";
                            cmd2.Parameters.AddWithValue("name", textBox1.Text);
                            cmd2.Parameters.AddWithValue("phone", textBox2.Text);
                            cmd2.Parameters.AddWithValue("permanent_ad", textBox3.Text);
                            cmd2.Parameters.AddWithValue("present_ad", textBox4.Text);
                            if (x == male)
                            {
                                cmd2.Parameters.AddWithValue("gender", 1);
                            }
                            else if (x == female)
                            {
                                cmd2.Parameters.AddWithValue("gender", 2);
                            }
                            else if (x == others)
                            {
                                cmd2.Parameters.AddWithValue("gender", 3);
                            }
                            cmd2.Parameters.AddWithValue("nid", textBox5.Text);
                            cmd2.Parameters.AddWithValue("occupation", textBox6.Text);
                            cmd2.Parameters.AddWithValue("monthly_income", textBox7.Text);
                            cmd2.Parameters.AddWithValue("username", textBox9.Text);
                            cmd2.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Update Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getdata();
                            loaddata();
                            shower();
                        }
                        else if (cc2 == 2)
                        {
                            string x = comboBox1.Text;
                            string male = "Male";
                            string female = "Female";
                            string others = "Others";
                            con.Open();
                            MySqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "UPDATE reg_card SET name = @name, phone = @phone, permanent_ad = @permanent_ad, present_ad = @present_ad, gender = @gender, nid = @nid, occupation = @occupation, monthly_income = @monthly_income, username = @username WHERE username = '" + cc + "'";
                            cmd2.Parameters.AddWithValue("name", textBox1.Text);
                            cmd2.Parameters.AddWithValue("phone", textBox2.Text);
                            cmd2.Parameters.AddWithValue("permanent_ad", textBox3.Text);
                            cmd2.Parameters.AddWithValue("present_ad", textBox4.Text);
                            if (x == male)
                            {
                                cmd2.Parameters.AddWithValue("gender", 1);
                            }
                            else if (x == female)
                            {
                                cmd2.Parameters.AddWithValue("gender", 2);
                            }
                            else if (x == others)
                            {
                                cmd2.Parameters.AddWithValue("gender", 3);
                            }
                            cmd2.Parameters.AddWithValue("nid", textBox5.Text);
                            cmd2.Parameters.AddWithValue("occupation", textBox6.Text);
                            cmd2.Parameters.AddWithValue("monthly_income", textBox7.Text);
                            cmd2.Parameters.AddWithValue("username", textBox9.Text);
                            cmd2.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Update Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getdata();
                            loaddata();
                            shower();
                        }
                    }
                    else
                    {
                        MessageBox.Show("PIN didn't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Enter PIN to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Insert in all the values!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void shower()
        {
            new details().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shower();
        }
    }
}
