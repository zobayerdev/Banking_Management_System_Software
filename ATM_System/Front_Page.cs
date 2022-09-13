using ATM_System.Main_Page;
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
    public partial class Front_Page : Form
    {
        public Front_Page()
        {
            InitializeComponent();
            var pos = this.PointToScreen(label1.Location);
            pos = pictureBox2.PointToClient(pos);
            label1.Parent = pictureBox2;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;

            var pos2 = this.PointToScreen(label2.Location);
            pos2 = pictureBox2.PointToClient(pos2);
            label2.Parent = pictureBox2;
            label2.Location = pos2;
            label2.BackColor = Color.Transparent;

            var pos3 = this.PointToScreen(credits.Location);
            pos3 = pictureBox2.PointToClient(pos3);
            credits.Parent = pictureBox2;
            credits.Location = pos3;
            credits.BackColor = Color.Transparent;

            var pos4 = this.PointToScreen(reg_button.Location);
            pos4 = pictureBox2.PointToClient(pos4);
            reg_button.Parent = pictureBox2;
            reg_button.Location = pos4;
            reg_button.BackColor = Color.Transparent;

            var pos5 = this.PointToScreen(login_button.Location);
            pos5 = pictureBox2.PointToClient(pos5);
            login_button.Parent = pictureBox2;
            login_button.Location = pos5;
            login_button.BackColor = Color.Transparent;

            var pos6 = this.PointToScreen(guna2CircleButton1.Location);
            pos6 = pictureBox2.PointToClient(pos6);
            guna2CircleButton1.Parent = pictureBox2;
            guna2CircleButton1.Location = pos6;
            guna2CircleButton1.BackColor = Color.Transparent;

            var pos7 = this.PointToScreen(button1.Location);
            pos7 = pictureBox2.PointToClient(pos7);
            button1.Parent = pictureBox2;
            button1.Location = pos7;
            button1.BackColor = Color.Transparent;

            var pos8 = this.PointToScreen(ccc3.Location);
            pos8 = pictureBox2.PointToClient(pos8);
            ccc3.Parent = pictureBox2;
            ccc3.Location = pos8;
            ccc3.BackColor = Color.Transparent;

            var pos9 = this.PointToScreen(button2.Location);
            pos9 = pictureBox2.PointToClient(pos9);
            button2.Parent = pictureBox2;
            button2.Location = pos9;
            button2.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reg registration = new Reg();
            registration.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            credits crdt = new credits();
            crdt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();

            
        }

        private void Front_Page_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            captcha login = new captcha();
            login.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            new end().Show();
            this.Close();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            contact.connector = 1;
            this.Hide();
            contact jj = new contact();
            jj.Show();
        }
    }
}
