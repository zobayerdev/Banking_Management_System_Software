using ATM_System.Main_Page.add_money;
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
    public partial class otp : Form
    {
        public static int g;
        public otp()
        {
            InitializeComponent();
            string numbers = "0123456789";
            Random random = new Random();
            string otp = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                int tempval = random.Next(0, numbers.Length);
                otp += tempval;
            }
            label2.Text = otp;
        }

        private void otp_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bkash.a = int.Parse(label2.Text);
            rocket.a = int.Parse(label2.Text);
            nagad.a = int.Parse(label2.Text);
            upay.a = int.Parse(label2.Text);
            Clipboard.SetText(label2.Text);
            this.Close();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
