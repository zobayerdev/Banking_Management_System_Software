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
    public partial class unlock_login : Form
    {
        public unlock_login()
        {
            InitializeComponent();
        }
        Timer tmr;
        private void unlock_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Interval = 2500;
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            original_main mf = new original_main();
            mf.Show();
            this.Hide();

        }

        private void unlock_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
