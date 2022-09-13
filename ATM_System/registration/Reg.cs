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
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Reg_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Front_Page front = new Front_Page();
            front.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void forbank_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reg_Bank regbank = new Reg_Bank();
            regbank.Show();
        }

        private void forcard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reg_Card regcard = new Reg_Card();
            regcard.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
