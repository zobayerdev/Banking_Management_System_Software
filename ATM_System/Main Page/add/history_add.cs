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
    public partial class history_add : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        public string cc = original_main.x;
        public history_add()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            datagrid.Show();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT transaction_id, number, amount, date FROM add_money WHERE username = '" + cc + "' AND wallet_type = 'bKash'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            datagrid.Show();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT transaction_id, amount, card_no, name_on_card, expiry, cvv_cvc, date FROM add_from_card WHERE username = '" + cc + "'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datagrid.Show();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT transaction_id, number, amount, date FROM add_money WHERE username = '" + cc + "' AND wallet_type = 'Rocket'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datagrid.Show();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT transaction_id, number, amount, date FROM add_money WHERE username = '" + cc + "' AND wallet_type = 'Nagad'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            datagrid.Show();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT transaction_id, number, amount, date FROM add_money WHERE username = '" + cc + "' AND wallet_type = 'Upay'";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }
    }
}
