using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    internal class sql_connection
    {
        public static string Connection()
        {
            string constring = "Server = localhost; database = atm_system; Uid = root; Pwd = ''; SslMode = none";
            return constring;
        }
        
    }
}
