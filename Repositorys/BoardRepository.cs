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

        public List<BoardModel> GetBoardList(SqlConnection con)
        {
            List<BoardModel> boardModelList = new List<BoardModel>();
            Connection connection = new Connection();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetBoardList", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        BoardModel boardModel = new BoardModel();
                        boardModel.No = Convert.ToInt32(reader["No"]);
                        boardModel.Title = Convert.ToString(reader["Title"]);
                        boardModel.Name = Convert.ToString(reader["Name"]);
                        boardModelList.Add(boardModel);
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
            return boardModelList;
        }

        public BoardModel GetBoardDetail(SqlConnection con,int No)
        {
            Connection connection = new Connection();
            BoardModel boardModel = new BoardModel();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetBoardDetail", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", No);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        boardModel.Title = Convert.ToString(reader["Title"]);
                        boardModel.Name = Convert.ToString(reader["Name"]);
                        boardModel.Content = Convert.ToString(reader["Content"]);
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
            return boardModel;
        }
    }
}
