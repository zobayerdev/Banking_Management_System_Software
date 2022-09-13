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

namespace ATM_System.Unblock
{
    public partial class block_card : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;

        public string name = "";
        public string phone = "";
        public string permanent_ad = "";
        public string present_ad = "";
        public int gender;
        public int nid;
        public string occupation = "";
        public int monthly_income;
        public string user = "";
        public int pin;
        public string card_no = "";
        public string date = "";
        public int balance;

        public block_card()
        {
            InitializeComponent();
            datagrid.Hide();
        }

        private void block_card_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
                cmd.CommandText = "SELECT * from blocked_card";
                MySqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                datagrid.DataSource = dt;
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            user = textBox1.Text;
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from reg_card where username='" + user + "'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                datagrid.Show();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                datagrid.DataSource = dt;

                MySqlCommand cmd2;
                cmd2 = con.CreateCommand();
                cmd2.CommandText = "SELECT * from reg_card where username='" + user + "'";
                cmd2.ExecuteNonQuery();
                rdr = cmd2.ExecuteReader();
                rdr.Read();
                name = rdr.GetString(0);
                phone = rdr.GetString(1);
                permanent_ad = rdr.GetString(2);
                present_ad = rdr.GetString(3);
                gender = rdr.GetInt32(4);
                nid = rdr.GetInt32(5);
                occupation = rdr.GetString(6);
                monthly_income = rdr.GetInt32(7);
                user = rdr.GetString(8);
                pin = rdr.GetInt32(9);
                card_no = rdr.GetString(10);
                date = rdr.GetString(11);
                balance = rdr.GetInt32(12);
                rdr.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("No Records Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                string message = "Are you sure?";
                string title = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM reg_card WHERE username='" + user + "'";
                    cmd.ExecuteReader();
                    con.Close();
                    con.Open();
                    MySqlCommand cmd2;
                    cmd2 = con.CreateCommand();
                    cmd2.CommandText = "INSERT INTO blocked_card (name, phone, permanent_ad, present_ad, gender, nid, occupation, monthly_income, username, pin, card_no, date, balance) VALUES(@name, @phone, @permanent_ad, @present_ad, @gender, @nid, @occupation, @monthly_income, @username, @pin, @card_no, @date, @balance)";
                    cmd2.Parameters.AddWithValue("name", name);
                    cmd2.Parameters.AddWithValue("phone", phone);
                    cmd2.Parameters.AddWithValue("permanent_ad", permanent_ad);
                    cmd2.Parameters.AddWithValue("present_ad", present_ad);
                    cmd2.Parameters.AddWithValue("gender", gender);
                    cmd2.Parameters.AddWithValue("nid", nid);
                    cmd2.Parameters.AddWithValue("occupation", occupation);
                    cmd2.Parameters.AddWithValue("monthly_income", monthly_income);
                    cmd2.Parameters.AddWithValue("username", user);
                    cmd2.Parameters.AddWithValue("pin", pin);
                    cmd2.Parameters.AddWithValue("card_no", card_no);
                    cmd2.Parameters.AddWithValue("date", date);
                    cmd2.Parameters.AddWithValue("balance", balance);
                    cmd2.ExecuteReader();
                    con.Close();
                    datagrid.Hide();
                    MessageBox.Show("User Blocked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Select a user first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
