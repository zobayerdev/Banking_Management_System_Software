using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATM_System
{
    public partial class bank_ac : Form
    {
        public bank_ac()
        {
            InitializeComponent();
            var pos = this.PointToScreen(label1.Location);
            pos = pictureBox1.PointToClient(pos);
            label1.Parent = pictureBox1;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;

            var pos2 = this.PointToScreen(label2.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            label2.Parent = pictureBox1;
            label2.Location = pos2;
            label2.BackColor = Color.Transparent;

            var pos4 = this.PointToScreen(label3.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            label3.Parent = pictureBox1;
            label3.Location = pos4;
            label3.BackColor = Color.Transparent;

            var pos3 = this.PointToScreen(label4.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            label4.Parent = pictureBox1;
            label4.Location = pos3;
            label4.BackColor = Color.Transparent;
        }

        private void bank_ac_Load(object sender, EventArgs e)
        {
            label1.Text = Reg_Bank.SetValueForText1;
            label2.Text = Reg_Bank.SetValueForText2;
            label3.Text = Reg_Bank.SetValueForText3;
            label4.Text = Reg_Bank.SetValueForText4;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string cv = Reg_Bank.SetValueForText5;
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            bmp.Save("D:/Varsity/Projects/ATM System C#/Saved AC//" + cv + ".jpeg", ImageFormat.Jpeg);
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Login a = new Login();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Front_Page a = new Front_Page();
            a.Show();
        }
    }
}
