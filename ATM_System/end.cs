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
    public partial class end : Form
    {
        Timer tmr;

        public end()
        {
            InitializeComponent();
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            this.Close();
            System.Windows.Forms.Application.Exit();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void end_Shown_1(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = 3500;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
