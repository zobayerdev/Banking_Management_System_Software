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
    public partial class Reg_Card : Form
    {
        private static int random;
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        public static string SetValueForText6 = "";
        public static string SetValueForText7 = "";

        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        int i, y;
        int vv;
        
        public Reg_Card()
        {
            InitializeComponent();
            pp1.Hide();
            Random rnd = new Random();
            int card1 = rnd.Next(6332, 6999);
            int card2 = rnd.Next(1000, 9999);
            int card3 = rnd.Next(1000, 9999);
            int card4 = rnd.Next(1000, 9999);
            int cvv = rnd.Next(100, 999);
            int expDay = rnd.Next(1, 30);
            int expYear = rnd.Next(2026, 2030);
            SetValueForText3 = cvv.ToString();
            string c = cvv.ToString();
            string e = expDay.ToString() + "/" + expYear.ToString();
            string x = card1.ToString() + " " + card2.ToString() + " " + card3.ToString() + " " + card4.ToString();
            SetValueForText2 = x;
            SetValueForText3 = c;
            SetValueForText4 = e;
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
        public void card()
        {
            card_show y = new card_show();
            y.Show();
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
        private void imagetxt_TextChanged(object sender, EventArgs e)
        { }
        private void Reg_Bank_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToLongDateString();
            SetValueForText7 = date;
            label15.Text = date;
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

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pp1_Paint(object sender, PaintEventArgs e)
        {

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
                    SetValueForText5 = pintxt.Text;
                    SetValueForText6 = usernametxt.Text;
                    pp1.Hide();
                    
                    string combobox = ocu_combo.SelectedItem.ToString();
                    con.Open();
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "INSERT INTO reg_card (name, phone, permanent_ad, present_ad, gender, nid, occupation, monthly_income, email, username, pin, card_no, date, balance) VALUES(@name, @phone, @permanent_ad, @present_ad, @gender, @nid, @occupation, @monthly_income, @email, @username, @pin, @card_no, @date, @balance)";
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
                    cmd2.Parameters.AddWithValue("card_no", d);
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
                        card();
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
                    cmd2.CommandText = "INSERT INTO reg_card (name, phone, permanent_ad, present_ad, gender, nid, occupation, monthly_income, email, username, pin, card_no, date, balance) VALUES(@name, @phone, @permanent_ad, @present_ad, @gender, @nid, @occupation, @monthly_income, @email, @username, @pin, @card_no, @date, @balance)";
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
                    cmd2.Parameters.AddWithValue("card_no", d);
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
                        card();
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

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pintxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void incometxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void nidtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void phonetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { }
    }
}
