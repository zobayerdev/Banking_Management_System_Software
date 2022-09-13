using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_System.Data_Grids
{
    public partial class registered_card : Form
    {
        MySqlConnection con = new MySqlConnection(sql_connection.Connection());
        public registered_card()
        {
            InitializeComponent();
            datagrid.Show();
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT name, phone, permanent_ad, present_ad, nid, occupation, username, card_no, balance FROM reg_card";
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            con.Close();
            datagrid.DataSource = dt;
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
