using BoardRenual.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoardRenual.Repositorys
{
    public class BoardRepository
    {
        public int WriteBoard(BoardModel boardmodel, SqlConnection con)
        {
            int result = -1;
            Connection connection = new Connection();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.WriteBoard", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Title", boardmodel.Title);
                    com.Parameters.AddWithValue("@Content", boardmodel.Content);
                    com.Parameters.AddWithValue("@Email", boardmodel.Email);
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
    }
}