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
using ATM_System.Unblock;
using ATM_System.Block;
using ATM_System.Data_Grids;
using ATM_System.admin;
using ATM_System.admin.Data_Grids;

namespace ATM_System
{
    public partial class admin_panel : Form
    {
        public admin_panel()
        {
            InitializeComponent();
            panel2.Hide();
        }

        private void credits_Click(object sender, EventArgs e)
        {
            this.Close();
            locker_admin s = new locker_admin();
            s.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            registered_bank frm = new registered_bank() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            registered_card frm = new registered_card() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            all_transfer frm = new all_transfer() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            all_withdraws frm = new all_withdraws() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void ccc3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            new end().Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(panel2.Visible)
            {
                panel2.Hide();
            }
            else
            {
                panel2.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            block_card frm = new block_card() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            unblock_card frm = new unblock_card() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            Block_Bank_AC frm = new Block_Bank_AC() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            Unblock_Bank frm = new Unblock_Bank() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void PP_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            crypto_edit frm = new crypto_edit() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            bill_edit frm = new bill_edit() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            added_history frm = new added_history() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            donation_history frm = new donation_history() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            payment_history frm = new payment_history() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            wallet_history frm = new wallet_history() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            PP.Controls.Clear();
            crypto_send_history frm = new crypto_send_history() { TopLevel = false, TopMost = true };
            this.PP.Controls.Add(frm);
            frm.Show();
        }
    }
}
