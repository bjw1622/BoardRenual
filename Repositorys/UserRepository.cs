using BoardRenual.Models.OrginalModel.User;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BoardRenual.Repository
{
    public class UserRepository
    {
        public bool SignUp(UserModel userEntity,SqlConnection con)
        {
            Connection connection = new Connection();
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
                    // sp에서 true false 값 받기
                    signUp = true;
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
            return signUp;
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
            connection.ConDispose(con);
            return users;
        }
    }
}