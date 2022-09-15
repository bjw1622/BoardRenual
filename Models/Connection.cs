using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoardRenual.Models
{
    public class Connection
    {
        protected SqlConnection con;
        public void Conn()
        {
            string constr = ConfigurationManager.ConnectionStrings["BoardRenual"].ToString();
            con = new SqlConnection(constr);
        }
        public void ConOpen()
        {
            con.Open();

        }
        public void ConClose()
        {
            con.Dispose();
        }
    }
}