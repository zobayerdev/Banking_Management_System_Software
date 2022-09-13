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
    public partial class captcha : Form
    {
        public captcha()
        {
            InitializeComponent();
            loadCaptchaImage();
        }
        string s;
        private void loadCaptchaImage()
        {
            var chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }
            var str = new String(stringChars1);
            s = str;
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("Microsoft Sans Serif", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(str.ToString(), font, Brushes.Green, new Point(0, 0));
            pictureBox1.Image = image;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == s)
            {
                this.Hide();
                admin_login n2 = new admin_login();
                n2.Show();

            }
            else
            {
                string message = "Didn't Match!" +
                    "Try again";
                string title = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Retry)
                {
                    loadCaptchaImage();
                }
                else
                {
                    this.Hide();
                    Front_Page n = new Front_Page();
                    n.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadCaptchaImage();
        }

        private void captcha_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
