using BoardRenual.Models.OrginalModel.User;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BoardRenual.Repository
{
    public class UserRepository
    {
        public int SignUp(UserModel userEntity,SqlConnection con)
        {
            Connection connection = new Connection();
            int signUpResult = -1;
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.InsertUser", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Email", userEntity.Email);
                    com.Parameters.AddWithValue("@Pw", userEntity.Pw);
                    com.Parameters.AddWithValue("@Name", userEntity.Name);
                    com.Parameters.AddWithValue("@Birth", userEntity.Birth);
                    if((string)com.ExecuteScalar() == userEntity.Email)
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


        public int EmailCheck(UserModel userEntity, SqlConnection con)
        {
            int result = -1;
            Connection connection = new Connection();
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

        public UserModel SignIn(UserModel userEntity, SqlConnection con)
        {
            Connection connection = new Connection();
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