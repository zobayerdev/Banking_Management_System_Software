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
using System.IO;
using System.Net.Mail;
using System.Net;

namespace ATM_System
{
    public partial class trasnfer : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        private MySqlDataReader rdr;
        public string cc = original_main.x;
        public int cc2 = original_main.qwe;
        public trasnfer()
        {
            InitializeComponent();
            pp1.Hide();
            datagrid.Hide();
            cash();
        }

        public void cash()
        {
            con.Open();
            if (cc2 == 1)
            {
                label1.Show();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "SELECT balance from reg_bank where username='" + cc + "'";
                cmd2.ExecuteNonQuery();
                rdr = cmd2.ExecuteReader();
                rdr.Read();
                int bal = rdr.GetInt32(0);
                label1.Text = bal.ToString() + " TK";
            }

            else if (cc2 == 2)
            {
                label1.Show();
                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "SELECT balance from reg_card where username='" + cc + "'";
                cmd3.ExecuteNonQuery();
                rdr = cmd3.ExecuteReader();
                rdr.Read();
                int bal = rdr.GetInt32(0);
                label1.Text = bal.ToString() + " TK";
            }
            con.Close();
        }

        private void deposit_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public int sum, random;
        public String checker = "";
        public string bal5 = "";
        public int ok, z1, z2;
        string TransactionID = "TRASFATM" + DateTime.Now.Ticks.ToString().Substring(0, 10);
        string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text) && String.IsNullOrEmpty(textBox3.Text))
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
                int bal3 = int.Parse(textBox2.Text);
                int bal4 = int.Parse(textBox1.Text);
                z1 = bal4;
                if (checkBox1.Checked || checkBox2.Checked)
                {
                    if (checkBox1.Checked)
                    {
                        checker = "Bank";
                    }
                    else if (checkBox2.Checked)
                    {
                        checker = "Card";
                    }

                    if (cc2 == 1)
                    {
                        con.Open();
                        MySqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "SELECT pin, balance, email from reg_bank where username='" + cc + "'";
                        cmd2.ExecuteNonQuery();
                        rdr = cmd2.ExecuteReader();
                        rdr.Read();
                        int bal = rdr.GetInt32(0);
                        int bal2 = rdr.GetInt32(1);
                        bal5 = rdr.GetString(2);
                        con.Close();
                        if (bal == bal3)
                        {
                            if (bal2 >= bal4)
                            {
                                pp1.Show();
                                ok = 1;
                                sum = bal2 - bal4;
                                String from, pass, messageBody;
                                Random rand = new Random();
                                int randomCode = rand.Next(999999);
                                random = randomCode;
                                MailMessage message = new MailMessage();
                                string to = bal5;
                                from = "syskabboatm@gmail.com";
                                pass = "qteofnvmuephldoh";
                                messageBody = "Dear " + cc + ", Your reset code is " + randomCode;
                                message.To.Add(to);
                                message.From = new MailAddress(from);
                                message.Body = messageBody;
                                message.Subject = "OTP";
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                smtp.EnableSsl = true;
                                smtp.Port = 587;
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtp.Credentials = new NetworkCredential(from, pass);
                                try
                                {
                                    smtp.Send(message);
                                    l1.Text = "A 6-digit OTP is sent to your email!";
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                string message = "Insufficent Fund";
                                string title = "Low Fund";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    textBox1.Clear();
                                    textBox2.Clear();
                                }
                            }
                        }
                        else
                        {
                            string message = "Password did'nt match!";
                            string title = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                textBox2.Clear();
                            }
                        }
                    }

                    else if (cc2 == 2)
                    {
                        con.Open();
                        MySqlCommand cmd2 = con.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "SELECT pin, balance, email from reg_card where username='" + cc + "'";
                        cmd2.ExecuteNonQuery();
                        rdr = cmd2.ExecuteReader();
                        rdr.Read();
                        int bal = rdr.GetInt32(0);
                        int bal2 = rdr.GetInt32(1);
                        bal5 = rdr.GetString(2);
                        con.Close();
                        if (bal == bal3)
                        {
                            if (bal2 >= bal4)
                            {
                                pp1.Show();
                                ok = 2;
                                sum = bal2 - bal4;
                                String from, pass, messageBody;
                                Random rand = new Random();
                                int randomCode = rand.Next(999999);
                                random = randomCode;
                                MailMessage message = new MailMessage();
                                string to = bal5;
                                from = "syskabboatm@gmail.com";
                                pass = "qteofnvmuephldoh";
                                messageBody = "Dear " + cc + ", Your reset code is " + randomCode;
                                message.To.Add(to);
                                message.From = new MailAddress(from);
                                message.Body = messageBody;
                                message.Subject = "OTP";
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                smtp.EnableSsl = true;
                                smtp.Port = 587;
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtp.Credentials = new NetworkCredential(from, pass);
                                try
                                {
                                    smtp.Send(message);
                                    l1.Text = "A 6-digit OTP is sent to your email!";
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                string message = "Insufficent Fund";
                                string title = "Low Fund";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.OK)
                                {
                                    textBox1.Clear();
                                    textBox2.Clear();
                                }
                            }
                        }
                        else
                        {
                            string message = "Password did'nt match!";
                            string title = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                textBox2.Clear();
                            }
                        }
                    }
                    con.Close();
                }
                else
                {
                    string message = "Select the account type of the reciever!";
                    string title = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.OK)
                    {
                    }
                }
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void QR_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                cmd.CommandText = "SELECT transaction_id, transfer_to, ammount, transfer_type, date FROM transfer_history WHERE username = '" + cc + "'";
                MySqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                con.Close();
                datagrid.DataSource = dt;
            }
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x2 = int.Parse(textBox4.Text);
            if (random == x2)
            {
                pp1.Hide();
                string message1 = "OTP Verification Successful!";
                string title1 = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message1, title1, buttons);
                if (ok == 1)
                {
                    con.Open();
                    MySqlCommand cmd4 = con.CreateCommand();
                    cmd4.CommandType = CommandType.Text;
                    cmd4.CommandText = "UPDATE reg_bank SET balance = @Balance WHERE username = @UserID";
                    cmd4.Parameters.AddWithValue("@UserID", cc);
                    cmd4.Parameters.AddWithValue("@Balance", sum);
                    cmd4.ExecuteNonQuery();
                    con.Close();
                    string message9 = "Transfer Successful! Transfer amount = " + z1 + "TK";
                    string title9 = "Success";
                    cash();
                    MessageBoxButtons buttons9 = MessageBoxButtons.OK;
                    DialogResult result9 = MessageBox.Show(message9, title9, buttons9, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (result9 == DialogResult.OK)
                    {
                        string acc = "Bank";
                        String details = "Sender Username: " + cc + "\nSender Account Type: " + acc + "\nTransaction ID: " + TransactionID + "\nReciever Account: " + textBox3.Text + "\nTransfered To: " + checker + " Account\nTransfered Ammount: " + z1;
                        QRCoder.QRCodeGenerator qRCoder = new QRCoder.QRCodeGenerator();
                        var MyData = qRCoder.CreateQrCode(details, QRCoder.QRCodeGenerator.ECCLevel.H);
                        var code = new QRCoder.QRCode(MyData);
                        QR.Image = code.GetGraphic(50);
                        label6.Text = "QR Code Generated and Saved";
                        QR.Image.Save(@"D:\Varsity\Projects\ATM System C#\Transaction\" + TransactionID + ".jpg");
                        con.Open();
                        MySqlCommand cmd5 = con.CreateCommand();
                        cmd5.CommandType = CommandType.Text;
                        cmd5.CommandText = "INSERT INTO transfer_history (transferer_account_type, username, ammount, transaction_id, transfer_to, transfer_type, date) VALUES(@transferer_account_type, @username, @ammount, @transaction_id, @transfer_to, @transfer_type, @date)";
                        cmd5.Parameters.AddWithValue("@transferer_account_type", acc);
                        cmd5.Parameters.AddWithValue("@username", cc);
                        cmd5.Parameters.AddWithValue("@ammount", textBox1.Text);
                        cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                        cmd5.Parameters.AddWithValue("@transfer_to", textBox3.Text);
                        cmd5.Parameters.AddWithValue("@transfer_type", checker);
                        cmd5.Parameters.AddWithValue("@date", date);
                        cmd5.ExecuteNonQuery();
                        con.Close();
                        textBox1.Clear();
                        textBox3.Clear();
                        textBox2.Clear();
                    }
                    else if (ok == 2)
                    {
                        con.Open();
                        MySqlCommand cmd6 = con.CreateCommand();
                        cmd6.CommandType = CommandType.Text;
                        cmd6.CommandText = "UPDATE reg_card SET balance = @Balance WHERE username = @UserID";
                        cmd6.Parameters.AddWithValue("@UserID", cc);
                        cmd6.Parameters.AddWithValue("@Balance", sum);
                        cmd6.ExecuteNonQuery();
                        con.Close();
                        string message2 = "Cashout Successful! Cashout amount = " + z1 + "TK";
                        string title2 = "Success";
                        cash();
                        MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message2, title2, buttons1, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.OK)
                        {
                            string acc = "Card";
                            String details = "Sender Username: " + cc + "\nSender Account Type: " + acc + "\nTransaction ID: " + TransactionID + "\nReciever Account: " + textBox3.Text + "\nTransfered To: " + checker + " Account\nTransfered Ammount: " + z1;
                            QRCoder.QRCodeGenerator qRCoder = new QRCoder.QRCodeGenerator();
                            var MyData = qRCoder.CreateQrCode(details, QRCoder.QRCodeGenerator.ECCLevel.H);
                            var code = new QRCoder.QRCode(MyData);
                            QR.Image = code.GetGraphic(50);
                            label6.Text = "QR Code Generated and Saved";
                            QR.Image.Save(@"D:\Varsity\Projects\ATM System C#\Transaction\" + TransactionID + ".jpg");
                            con.Open();
                            MySqlCommand cmd5 = con.CreateCommand();
                            cmd5.CommandType = CommandType.Text;
                            cmd5.CommandText = "INSERT INTO transfer_history (transferer_account_type, username, ammount, transaction_id, transfer_to, transfer_type, date) VALUES(@transferer_account_type, @username, @ammount, @transaction_id, @transfer_to, @transfer_type, @date)";
                            cmd5.Parameters.AddWithValue("@transferer_account_type", acc);
                            cmd5.Parameters.AddWithValue("@username", cc);
                            cmd5.Parameters.AddWithValue("@ammount", textBox1.Text);
                            cmd5.Parameters.AddWithValue("@transaction_id", TransactionID);
                            cmd5.Parameters.AddWithValue("@transfer_to", textBox3.Text);
                            cmd5.Parameters.AddWithValue("@transfer_type", checker);
                            cmd5.Parameters.AddWithValue("@date", date);
                            cmd5.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Email verification unsuccessful!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}