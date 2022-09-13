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
    public partial class unblock_card : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        public string name;
        public string phone;
        public string permanent_ad;
        public string present_ad;
        public int gender;
        public int nid;
        public string occupation;
        public int monthly_income;
        public string user;
        public int pin;
        public string card_no;
        public string date;
        public int balance;
        public unblock_card()
        {
            InitializeComponent();
            data();
        }

        public void data()
        {
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from blocked_card";
            MySqlDataReader sdr = cmd.ExecuteReader();
            datagrid.Show();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            datagrid.DataSource = dt;
            con.Close();
        }

            private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in datagrid.SelectedRows)
            {
                name = row.Cells[0].Value.ToString();
                phone = row.Cells[1].Value.ToString();
                permanent_ad = row.Cells[2].Value.ToString();
                present_ad = row.Cells[3].Value.ToString();
                gender = int.Parse(row.Cells[4].Value.ToString());
                nid = int.Parse(row.Cells[5].Value.ToString());
                occupation = row.Cells[6].Value.ToString();
                monthly_income = int.Parse(row.Cells[7].Value.ToString());
                user = row.Cells[8].Value.ToString();
                pin = int.Parse(row.Cells[9].Value.ToString());
                card_no = row.Cells[10].Value.ToString();
                date = row.Cells[11].Value.ToString();
                balance = int.Parse(row.Cells[12].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Select a user first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string message = "Are you sure?";
                string title = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    MySqlCommand cmd2;
                    cmd2 = con.CreateCommand();
                    cmd2.CommandText = "INSERT INTO reg_card (name, phone, permanent_ad, present_ad, gender, nid, occupation, monthly_income, username, pin, card_no, date, balance) VALUES(@name, @phone, @permanent_ad, @present_ad, @gender, @nid, @occupation, @monthly_income, @username, @pin, @card_no, @date, @balance)";
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
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM blocked_card WHERE username='" + user + "'";
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("User Unblocked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    data();
                }
                else
                {

                }
            }
        }

        private void unblock_card_Load(object sender, EventArgs e)
        {

        }
    }
}
