using iTextSharp.text.pdf;
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
using static System.Net.Mime.MediaTypeNames;

namespace ATM_System
{
    public partial class card_show : Form
    {
        public card_show()
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

            var pos3 = this.PointToScreen(label4.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            label4.Parent = pictureBox1;
            label4.Location = pos3;
            label4.BackColor = Color.Transparent;

            var pos4 = this.PointToScreen(label3.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            label3.Parent = pictureBox1;
            label3.Location = pos4;
            label3.BackColor = Color.Transparent;

            var pos5 = this.PointToScreen(label5.Location);
            pos5 = pictureBox1.PointToClient(pos5);
            label5.Parent = pictureBox1;
            label5.Location = pos5;
            label5.BackColor = Color.Transparent;

            var pos6 = this.PointToScreen(label6.Location);
            pos6 = pictureBox2.PointToClient(pos6);
            label6.Parent = pictureBox2;
            label6.Location = pos6;
            label6.BackColor = Color.Transparent;

            var pos7 = this.PointToScreen(label7.Location);
            pos7 = pictureBox1.PointToClient(pos7);
            label7.Parent = pictureBox1;
            label7.Location = pos7;
            label7.BackColor = Color.Transparent;

            var pos8 = this.PointToScreen(label8.Location);
            pos8 = pictureBox2.PointToClient(pos8);
            label8.Parent = pictureBox2;
            label8.Location = pos8;
            label8.BackColor = Color.Transparent;

            var pos9 = this.PointToScreen(label9.Location);
            pos9 = pictureBox2.PointToClient(pos9);
            label9.Parent = pictureBox2;
            label9.Location = pos9;
            label9.BackColor = Color.Transparent;

            var pos10 = this.PointToScreen(label10.Location);
            pos10 = pictureBox2.PointToClient(pos10);
            label10.Parent = pictureBox2;
            label10.Location = pos10;
            label10.BackColor = Color.Transparent;

            var pos11 = this.PointToScreen(label11.Location);
            pos11 = pictureBox2.PointToClient(pos11);
            label11.Parent = pictureBox2;
            label11.Location = pos11;
            label11.BackColor = Color.Transparent;

            var pos12 = this.PointToScreen(label12.Location);
            pos12 = pictureBox2.PointToClient(pos12);
            label12.Parent = pictureBox2;
            label12.Location = pos12;
            label12.BackColor = Color.Transparent;

        }

        private void card_show_Load(object sender, EventArgs e)
        {
            label2.Text = Reg_Card.SetValueForText2;
            label11.Text = Reg_Card.SetValueForText2;

            label3.Text = Reg_Card.SetValueForText3;
            label10.Text = Reg_Card.SetValueForText3;

            label1.Text = Reg_Card.SetValueForText1;
            label12.Text = Reg_Card.SetValueForText1;

            label4.Text = Reg_Card.SetValueForText4;
            label9.Text = Reg_Card.SetValueForText4;

            label5.Text = Reg_Card.SetValueForText5;
            label8.Text = Reg_Card.SetValueForText5;
        }
        string cv = Reg_Card.SetValueForText6;
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            bmp.Save("D:/Varsity/Projects/ATM System C#/Saved Card//" + cv + ".jpeg", ImageFormat.Jpeg);
           
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
            bmp.Save("D:/Varsity/Projects/ATM System C#/Saved Card//" + cv + ".jpeg", ImageFormat.Jpeg);
            
            Login login = new Login();
            login.Show();
            this.Close();
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
