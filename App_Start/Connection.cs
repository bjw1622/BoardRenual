using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoardRenual
{
    public class Connection
    {
        public SqlConnection ConOpen()
        {
            string constr = ConfigurationManager.ConnectionStrings["BoardRenual"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            return con;
        }
        public void ConDispose(SqlConnection con)
        {
            con.Dispose();
        }
    }
}