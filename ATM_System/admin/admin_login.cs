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
    public partial class admin_login : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        int i;
        public admin_login()
        {
            InitializeComponent();
        }

        private void credits_Click(object sender, EventArgs e)
        {
            this.Close();
            Front_Page fp = new Front_Page();
            fp.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logged_in_Click(object sender, EventArgs e)
        {
            if (admin_id.Text != string.Empty && pin_text.Text != string.Empty)
            {
                i = 0;
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * from admin where admin_id='" + admin_id.Text + "' and pin='" + pin_text.Text + "'";
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
                        admin_id.Clear();
                        pin_text.Clear();
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
                    this.Close();
                    unlock_admin fp = new unlock_admin();
                    fp.Show();
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

        private void admin_login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pin_text.PasswordChar == '*')
            {
                button3.BringToFront();
                pin_text.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pin_text.PasswordChar == '\0')
            {
                button1.BringToFront();
                pin_text.PasswordChar = '*';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            new end().Show();
        }

        private void ccc3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
