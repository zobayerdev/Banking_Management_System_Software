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
using System.Data.SqlClient;

namespace ATM_System
{
    public partial class Login : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        int i;
        public static string SetValueForText1 = "";
        public static string NAME = "";
        public static int gender;
        public static int n;
        private MySqlDataReader rdr;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Front_Page front = new Front_Page();
            front.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void ac_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void logged_in_Click(object sender, EventArgs e)
        {
           
        }

        private void pin_text_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (gunpass.PasswordChar == '*')
            {
                button3.BringToFront();
                gunpass.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gunpass.PasswordChar == '\0')
            {
                button1.BringToFront();
                gunpass.PasswordChar = '*';
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (gun.Text != string.Empty && gunpass.Text != string.Empty)
            {
                con.Open();
                if (bankcheckbox.Checked)
                {
                    i = 0;
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * from reg_bank where username='" + gun.Text + "' and pin='" + gunpass.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 0)
                    {
                        string message = "Password or Username didn't match!";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                        if (result == DialogResult.Retry)
                        {
                            gunpass.Clear();
                        }
                        else
                        {
                            this.Close();
                            Front_Page n = new Front_Page();
                            n.Show();
                        }
                    }
                    else
                    {
                        n = 1;
                        SetValueForText1 = gun.Text;
                        MySqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "SELECT name, gender from reg_bank where username='" + gun.Text + "'";
                        cmd2.ExecuteNonQuery();
                        rdr = cmd2.ExecuteReader();
                        rdr.Read();
                        NAME = rdr.GetString(0);
                        gender = rdr.GetInt32(1);
                        this.Close();
                        unlock_login mf = new unlock_login();
                        mf.Show();
                    }
                }

                if (cardcheckbox.Checked)
                {
                    i = 0;
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * from reg_card where username='" + gun.Text + "' and pin='" + gunpass.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    if (i == 0)
                    {
                        string message = "Password or Username didn't match!";
                        string title = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                        if (result == DialogResult.Retry)
                        {
                            gunpass.Clear();
                        }
                        else
                        {
                            this.Close();
                            Front_Page n = new Front_Page();
                            n.Show();
                        }
                    }
                    else
                    {
                        n = 2;
                        SetValueForText1 = gun.Text;
                        MySqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "SELECT name, gender from reg_card where username='" + gun.Text + "'";
                        cmd2.ExecuteNonQuery();
                        rdr = cmd2.ExecuteReader();
                        rdr.Read();
                        NAME = rdr.GetString(0);
                        gender = rdr.GetInt32(1);
                        this.Close();
                        unlock_login mf = new unlock_login();
                        mf.Show();
                    }
                }
                if (!bankcheckbox.Checked && !cardcheckbox.Checked)
                {
                    string message1 = "Please select your account type!";
                    string title1 = "Error";
                    MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Warning);
                    if (result1 == DialogResult.OK)
                    {
                    }
                }

                con.Close();
            }
            else
            {
                string message1 = "Please enter value in all field.";
                string title1 = "Error";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Warning);
                if (result1 == DialogResult.OK)
                {
                }
            }
        }
    }
}
