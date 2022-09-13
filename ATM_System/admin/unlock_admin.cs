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
    public partial class unlock_admin : Form
    {
        public unlock_admin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        Timer tmr;
        private void unlock_admin_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = 2500;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            this.Close();
            admin_panel mf = new admin_panel();
            mf.Show();
        }

        private void unlock_admin_Load(object sender, EventArgs e)
        {

        }
    }
}
