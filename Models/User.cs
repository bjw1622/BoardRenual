using BoardRenual.Entitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoardRenual.Models
{
    public class User : Connection
    {
        public void SignUp(UserEntity userEntity)
        {
            SqlConnection con = ConOpen();
            using (SqlCommand com = new SqlCommand("dbo.InsertUser", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Email", userEntity.Email);
                com.Parameters.AddWithValue("@Pw", userEntity.Pw);
                com.Parameters.AddWithValue("@Name", userEntity.Name);
                com.Parameters.AddWithValue("@Birth", userEntity.Birth);
                com.ExecuteNonQuery();
            }
            ConDispose(con);
        }
    }
}