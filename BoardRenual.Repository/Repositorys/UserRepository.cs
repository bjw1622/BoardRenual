using BoardRenual.Models.Models.OrginalModel.User;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BoardRenual.Repository
{
    public class UserRepository
    {
        public bool SignUp(UserOriginalModel userModel)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            bool result = false;
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.InsertUser", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Email", userModel.Email);
                    com.Parameters.AddWithValue("@Pw", userModel.Pw);
                    com.Parameters.AddWithValue("@Name", userModel.Name);
                    com.Parameters.AddWithValue("@Birth", userModel.Birth);
                    if(com.ExecuteNonQuery() == 1)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.ConDispose(con);
            }
            return result;
        }
        public int EmailCheck(UserOriginalModel userEntity)
        {
            int result = -1;
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.EmailCheck", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Email", userEntity.Email);
                    result = (int)com.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.ConDispose(con);
            }
            return result;
        }
        public UserOriginalModel SignIn(UserOriginalModel userEntity)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            UserOriginalModel users = new UserOriginalModel();
            try {
                using (SqlCommand com = new SqlCommand("dbo.LogInUser", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Email", userEntity.Email);
                    com.Parameters.AddWithValue("@Pw", userEntity.Pw);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Email = Convert.ToString(reader["Email"]);
                        users.Name = Convert.ToString(reader["Name"]);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.ConDispose(con);
            }
            return users;
        }
    }
}