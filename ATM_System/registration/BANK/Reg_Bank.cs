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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;

namespace ATM_System
{
    public partial class Reg_Bank : Form
    {
        private static int random;
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        int i, y;
        int vv;

        public Reg_Bank()
        {
            InitializeComponent();
            pp1.Hide();
            Random rnd = new Random();
            int account1 = rnd.Next(1000, 9999);
            int account2 = rnd.Next(1000, 9999);
            string x = "AC" + account1.ToString() + account2.ToString();
            SetValueForText2 = x;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reg registration = new Reg();
            registration.Show();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png;) |*.jpg; *.jpeg; *.png;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                imagetxt.Text = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        public void reciept()
        {
            bank_ac q = new bank_ac();
            q.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
            {
                vv = 0;
            }
            else
            {
                vv = 1;
            }

            if (nametxt.Text != string.Empty && phonetxt.Text != string.Empty && parmanenttxt.Text != string.Empty && presenttxt.Text != string.Empty && nidtxt.Text != string.Empty && ocu_combo.Text != string.Empty && incometxt.Text != string.Empty && usernametxt.Text != string.Empty && pintxt.Text != string.Empty && pintxt2.Text != string.Empty && imagetxt.Text != string.Empty && vv == 1 && email_box.Text != string.Empty)
            {
                SetValueForText1 = nametxt.Text;
                SetValueForText3 = pintxt.Text;
                i = 0;
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM reg_bank where username='" + usernametxt.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                MySqlCommand cmd4 = con.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "SELECT * FROM reg_card where username='" + usernametxt.Text + "'";
                cmd4.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd4);
                da2.Fill(dt2);
                y = Convert.ToInt32(dt2.Rows.Count.ToString());
                if (i != 0 || y != 0)
                {
                    MessageBox.Show("Username is already taken!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    usernametxt.Clear();
                }
                else
                {
                    pp1.Show();
                    String from, pass, messageBody;
                    Random rand = new Random();
                    int randomCode = rand.Next(999999);
                    random = randomCode;
                    MailMessage message = new MailMessage();
                    string to = (email_box.Text).ToString();
                    from = "syskabboatm@gmail.com";
                    pass = "qteofnvmuephldoh";
                    messageBody = "Dear " + usernametxt.Text + ", Your reset code is " + randomCode;
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

                if (pintxt2.Text != pintxt.Text)
                {
                    MessageBox.Show("Pin didn't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pintxt2.Clear();
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Please enter value in all field!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void imagetxt_TextChanged(object sender, EventArgs e)
        { }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string y = parmanenttxt.Text;
                presenttxt.Text = y;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        { }
        private void Reg_Bank_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToLongDateString();
            label15.Text = date;
            SetValueForText4 = date;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        { }
        private void label4_Click(object sender, EventArgs e)
        { }
        private void textBox2_TextChanged(object sender, EventArgs e)
        { }
        private void label5_Click(object sender, EventArgs e)
        { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void pintxt2_TextChanged(object sender, EventArgs e)
        { }
        public void ocu_combo_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void pictureBox1_Click(object sender, EventArgs e)
        { }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int x2 = int.Parse(textBox1.Text);
            if (random == x2)
            {
                string message1 = "OTP Verification Successful!";
                string title1 = "Success";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message1, title1, buttons);
                if (result == DialogResult.OK)
                {
                    pp1.Hide();
                    SetValueForText5 = usernametxt.Text;
                    string combobox = ocu_combo.SelectedItem.ToString();
                    con.Open();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO reg_bank (name, phone, permanent_ad, present_ad, gender, nid, occupation, monthly_income, email, username, pin, ac_no, date, balance) VALUES(@name, @phone, @permanent_ad, @present_ad, @gender, @nid, @occupation, @monthly_income, @email, @username, @pin, @ac_no, @date, @balance)";
                    cmd2.Parameters.AddWithValue("name", nametxt.Text);
                    cmd2.Parameters.AddWithValue("phone", phonetxt.Text);
                    cmd2.Parameters.AddWithValue("permanent_ad", parmanenttxt.Text);
                    cmd2.Parameters.AddWithValue("present_ad", presenttxt.Text);
                    if (checkBox2.Checked)
                    {
                        cmd2.Parameters.AddWithValue("gender", 1);
                    }
                    else if (checkBox3.Checked)
                    {
                        cmd2.Parameters.AddWithValue("gender", 2);
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("gender", 3);
                    }
                    cmd2.Parameters.AddWithValue("nid", nidtxt.Text);
                    cmd2.Parameters.AddWithValue("occupation", combobox);
                    cmd2.Parameters.AddWithValue("monthly_income", incometxt.Text);
                    cmd2.Parameters.AddWithValue("email", email_box.Text);
                    cmd2.Parameters.AddWithValue("username", usernametxt.Text);
                    cmd2.Parameters.AddWithValue("pin", pintxt.Text);
                    string d = SetValueForText2;
                    cmd2.Parameters.AddWithValue("ac_no", d);
                    string dj = SetValueForText4;
                    cmd2.Parameters.AddWithValue("date", dj);
                    cmd2.Parameters.AddWithValue("balance", 500);
                    cmd2.ExecuteNonQuery();
                    string extension = Path.GetExtension(imagetxt.Text);
                    string userfilename = usernametxt.Text;
                    File.Copy(imagetxt.Text, Path.Combine(@"D:\Varsity\Projects\ATM System C#\User Image (Bank)\", Path.GetFileName(userfilename + extension)), true);
                    string message3 = "Your account is created successfully!";
                    string title = "Account Created";
                    MessageBoxButtons buttons3 = MessageBoxButtons.OK;
                    DialogResult result3 = MessageBox.Show(message3, title, buttons3, MessageBoxIcon.Question);
                    if (result3 == DialogResult.OK)
                    {
                        reciept();
                        this.Close();
                    }
                }
                else
                {
                    pp1.Hide();
                    SetValueForText5 = usernametxt.Text;
                    string combobox = ocu_combo.SelectedItem.ToString();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO reg_bank (name, phone, permanent_ad, present_ad, gender, nid, occupation, monthly_income, email, username, pin, ac_no, date, balance) VALUES(@name, @phone, @permanent_ad, @present_ad, @gender, @nid, @occupation, @monthly_income, @email, @username, @pin, @ac_no, @date, @balance)";
                    cmd2.Parameters.AddWithValue("name", nametxt.Text);
                    cmd2.Parameters.AddWithValue("phone", phonetxt.Text);
                    cmd2.Parameters.AddWithValue("permanent_ad", parmanenttxt.Text);
                    cmd2.Parameters.AddWithValue("present_ad", presenttxt.Text);
                    if (checkBox2.Checked)
                    {
                        cmd2.Parameters.AddWithValue("gender", 1);
                    }
                    else if (checkBox3.Checked)
                    {
                        cmd2.Parameters.AddWithValue("gender", 2);
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("gender", 3);
                    }
                    cmd2.Parameters.AddWithValue("nid", nidtxt.Text);
                    cmd2.Parameters.AddWithValue("occupation", combobox);
                    cmd2.Parameters.AddWithValue("monthly_income", incometxt.Text);
                    cmd2.Parameters.AddWithValue("email", email_box.Text);
                    cmd2.Parameters.AddWithValue("username", usernametxt.Text);
                    cmd2.Parameters.AddWithValue("pin", pintxt.Text);
                    string d = SetValueForText2;
                    cmd2.Parameters.AddWithValue("ac_no", d);
                    string dj = SetValueForText4;
                    cmd2.Parameters.AddWithValue("date", dj);
                    cmd2.Parameters.AddWithValue("balance", 500);
                    cmd2.ExecuteNonQuery();
                    string extension = Path.GetExtension(imagetxt.Text);
                    string userfilename = usernametxt.Text;
                    File.Copy(imagetxt.Text, Path.Combine(@"D:\Varsity\Projects\ATM System C#\User Image (Bank)\", Path.GetFileName(userfilename + extension)), true);
                    this.Close();
                    string message4 = "Your account is created successfully!";
                    string title = "Account Created";
                    MessageBoxButtons buttons4 = MessageBoxButtons.OK;
                    DialogResult result4 = MessageBox.Show(message4, title, buttons4, MessageBoxIcon.Question);
                    if (result4 == DialogResult.OK)
                    {
                        reciept();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Email verification unsuccessful!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                pp1.Hide();
                Reg_Bank cv = new Reg_Bank();
                cv.Show();
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
