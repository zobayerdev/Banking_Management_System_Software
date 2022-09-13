using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ATM_System.admin
{
    public partial class bill_edit : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        public string TransactionID;
        public bill_edit()
        {
            InitializeComponent();
            datagrid.Hide();
            TransactionID = "BILL" + DateTime.Now.Ticks.ToString().Substring(0, 10);
            label1.Text = TransactionID;
        }

        public void data()
        {
            datagrid.Show();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM demand_bill";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int i, y;
        public string username;
        public string amount;

        private void button1_Click(object sender, EventArgs e)
        {
            if(datagrid.Visible)
            {
                datagrid.Hide();
            }
            else
            {
                data();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != string.Empty && textBox3.Text != string.Empty)
            {
                i = 0;
                y = 0;
                username = textBox3.Text;
                amount = textBox2.Text;
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT username FROM reg_bank where username='" + username + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "SELECT username FROM reg_card where username='" + username + "'";
                cmd4.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd4);
                da2.Fill(dt2);
                y = Convert.ToInt32(dt2.Rows.Count.ToString());
                con.Close();
                if (i != 0 || y != 0)
                {
                    string stat = "Unpaid";
                    con.Open();
                    MySqlCommand cmd2;
                    cmd2 = con.CreateCommand();
                    cmd2.CommandText = "INSERT INTO demand_bill (username, bill_id, amount, status) VALUES(@username, @bill_id, @amount, @status)";
                    cmd2.Parameters.AddWithValue("username", username);
                    cmd2.Parameters.AddWithValue("bill_id", TransactionID);
                    cmd2.Parameters.AddWithValue("amount", amount);
                    cmd2.Parameters.AddWithValue("status", stat);
                    cmd2.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Bill Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    data();
                }
                else
                {
                    MessageBox.Show("Username doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter in all the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
