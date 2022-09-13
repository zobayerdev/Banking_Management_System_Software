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
    public partial class locker_admin : Form
    {
        public locker_admin()
        {
            InitializeComponent();
        }
        Timer tmr;
        private void locker_admin_Shown(object sender, EventArgs e)
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
            admin_login mf = new admin_login();
            mf.Show();
        }

    }
}
