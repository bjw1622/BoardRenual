﻿using BoardRenual.Models;
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
        public int WriteBoard(BoardModel boardmodel, Connection connection)
        {
            int result = -1;
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.WriteBoard", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Title", boardmodel.Title);
                    com.Parameters.AddWithValue("@Content", boardmodel.Content);
                    com.Parameters.AddWithValue("@Email", boardmodel.Email);
                    //ExecuteNonQuery로 true false => parsing
                    // 이 경우는 true false
                    // 다른 경우는 여러가지 case
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

        public List<BoardModel> GetBoardList(Connection connection)
        {
            List<BoardModel> boardModelList = new List<BoardModel>();
            SqlConnection con = connection.ConOpen();
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

        public BoardModel GetBoardDetail(Connection connection, int No)
        {
            BoardModel boardModel = new BoardModel();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetBoardDetail", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", No);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        boardModel.No = No;
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

        public BoardModel GetBoardEmail(Connection connection, int No)
        {
            SqlConnection con = connection.ConOpen();
            BoardModel boardModel = new BoardModel();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetBoardEmail", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", No);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        boardModel.Email = Convert.ToString(reader["Email"]);
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
        public bool DeleteBoard(Connection connection, int No)
        {
            bool flag = false;
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.DelteBoard", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", No);
                    int obj = (int)com.ExecuteScalar();
                    if (obj == No)
                    {
                        flag = true;
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
            return flag;
        }
        public int UpdateBoard(BoardModel boardmodel, Connection connection)
        {
            int result = -1;
            SqlConnection con = connection.ConOpen();
                using (SqlCommand com = new SqlCommand("dbo.UpdateBoard", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", boardmodel.No);
                    com.Parameters.AddWithValue("@Title", boardmodel.Title);
                    com.Parameters.AddWithValue("@Content", boardmodel.Content);
                    result = (int)com.ExecuteScalar();
                }
            return result;
        }
    }
}
