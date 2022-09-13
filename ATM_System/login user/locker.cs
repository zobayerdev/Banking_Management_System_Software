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
    public partial class locker : Form
    {
        public locker()
        {
            InitializeComponent();
        }
        Timer tmr;
        private void locker_Load(object sender, EventArgs e)
        {
               
        } 

        private void locker_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = 2500;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            Front_Page mf = new Front_Page();
            mf.Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
