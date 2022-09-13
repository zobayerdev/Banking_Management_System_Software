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

namespace ATM_System.admin
{
    public partial class crypto_edit : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        public double x5;
        public crypto_edit()
        {
            InitializeComponent();
            datagrid.Hide();
            panel2.Hide();
        }





        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text == String.Empty)
            {
                string message = "Enter the BDT value first!";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {

                }
            }
            else
            {
                x5 = double.Parse(textBox5.Text);
                panel1.Hide();
                panel2.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double x1 = double.Parse(textBox1.Text);
            double x2 = double.Parse(textBox2.Text);
            double x3 = double.Parse(textBox3.Text);
            double x4 = double.Parse(textBox4.Text);

            if (textBox1 == null && textBox2 == null && textBox3 == null && textBox4 == null)
            {
                string message = "Enter in all the fields!";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {

                }
            }
            else
            {
                con.Open();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "TRUNCATE TABLE crypto_price";
                cmd3.ExecuteNonQuery();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "INSERT INTO crypto_price (btc, eth, ada, sol) VALUES(@btc, @eth, @ada, @sol)";
                cmd2.Parameters.AddWithValue("btc", x1 * x5);
                cmd2.Parameters.AddWithValue("eth", x2 * x5);
                cmd2.Parameters.AddWithValue("ada", x3 * x5);
                cmd2.Parameters.AddWithValue("sol", x4 * x5);
                cmd2.ExecuteNonQuery();
                con.Close();
                string message = "Updated successfully!";
                string title = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    datagrid.Show();
                    con.Open();
                    MySqlCommand cmd;
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT * FROM crypto_price";
                    MySqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(sdr);
                    con.Close();
                    datagrid.DataSource = dt;
                }
            }
        }
    }
}
