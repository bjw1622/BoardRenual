using BoardRenual.Models.OrginalModel.User;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BoardRenual.Repository
{
    public class UserRepository
    {
        public int SignUp(UserModel userModel, Connection connection)
        {
            SqlConnection con = connection.ConOpen();
            int signUpResult = -1;
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.InsertUser", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Email", userModel.Email);
                    com.Parameters.AddWithValue("@Pw", userModel.Pw);
                    com.Parameters.AddWithValue("@Name", userModel.Name);
                    com.Parameters.AddWithValue("@Birth", userModel.Birth);
                    if((string)com.ExecuteScalar() == userModel.Email)
                    {
                        signUpResult = 0;
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
            return signUpResult;
        }


        public int EmailCheck(UserModel userEntity, Connection connection)
        {
            int result = -1;
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

        public UserModel SignIn(UserModel userEntity, Connection connection)
        {
            SqlConnection con = connection.ConOpen();
            UserModel users = new UserModel();
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