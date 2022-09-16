using BoardRenual.Models;
using BoardRenual.Repository;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BoardRenual.Biz
{
    public class User : Connection
    {
        public bool SignUp(UserEntity userEntity)
        {
            SqlConnection con = ConOpen();
            bool signUp = false;
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.InsertUser", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Email", userEntity.Email);
                    com.Parameters.AddWithValue("@Pw", userEntity.Pw);
                    com.Parameters.AddWithValue("@Name", userEntity.Name);
                    com.Parameters.AddWithValue("@Birth", userEntity.Birth);
                    com.ExecuteNonQuery();
                    signUp = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                ConDispose(con);
            }
            return signUp;
        }
        public int EmailCheck(string email)
        {
            int result = -1;
            SqlConnection con = ConOpen();
            using(SqlCommand com = new SqlCommand("dbo.EmailCheck", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Email", email);
                result = (int)com.ExecuteScalar();
            }
            ConDispose(con);
            return result;
        }
    }
}