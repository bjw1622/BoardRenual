using BoardRenual.Models;
using BoardRenual.Models.Request.Page;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BoardRenual.Repositorys
{
    public class BoardRepository
    {
        public int WriteBoard(BoardModel boardmodel)
        {
            int boardNo = -1;
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.WriteBoard", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Title", boardmodel.Title);
                    com.Parameters.AddWithValue("@Content", boardmodel.Content);
                    com.Parameters.AddWithValue("@Email", boardmodel.Email);
                    boardNo = (int)com.ExecuteScalar();
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
            return boardNo;
        }

        public List<BoardModel> GetBoardList()
        {
            List<BoardModel> boardModelList = new List<BoardModel>();
            Connection connection = new Connection();
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
                        boardModel.ReplyCount = Convert.ToInt32(reader["ReplyCount"]);
                        boardModel.RecommandCount = Convert.ToInt32(reader["RecommandCount"]);
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

        public BoardModel GetBoardDetail(int No)
        {
            BoardModel boardModel = new BoardModel();
            Connection connection = new Connection();
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

        public BoardModel GetBoardEmail(int No)
        {
            Connection connection = new Connection();
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
        public bool DeleteBoard(int No)
        {
            bool flag = false;
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.DelteBoard", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", No);
                    if (com.ExecuteNonQuery() != -1)
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
        public bool UpdateBoard(BoardModel boardmodel)
        {
            bool result = false;
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.UpdateBoard", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", boardmodel.No);
                    com.Parameters.AddWithValue("@Title", boardmodel.Title);
                    com.Parameters.AddWithValue("@Content", boardmodel.Content);
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
        public List<BoardModel> IndexPagingBoard(PageRequestModel pageRequestModel)
        {
            List<BoardModel> boardModelList = new List<BoardModel>();
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.PagingBoard", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@PageCount", pageRequestModel.PageCount);
                    com.Parameters.AddWithValue("@PageNumber", pageRequestModel.PageNumber);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        BoardModel boardModel = new BoardModel();
                        boardModel.No = Convert.ToInt32(reader["No"]);
                        boardModel.Title = Convert.ToString(reader["Title"]);
                        boardModel.Name = Convert.ToString(reader["Name"]);
                        boardModel.RecommandCount = Convert.ToInt32(reader["RecommandCount"]);
                        boardModel.ReplyCount = Convert.ToInt32(reader["ReplyCount"]);
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
        public List<BoardModel> PageAndFindBoard(FindAndPageRequestModel findAndPageRequestModel)
        {
            List<BoardModel> boardModelList = new List<BoardModel>();
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.FindingAndPaging", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@PageCount", findAndPageRequestModel.PageCount);
                    com.Parameters.AddWithValue("@PageNumber", findAndPageRequestModel.PageNumber);
                    com.Parameters.AddWithValue("@Input", findAndPageRequestModel.Input);
                    com.Parameters.AddWithValue("@Variable", findAndPageRequestModel.Variable);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        BoardModel boardModel = new BoardModel();
                        boardModel.No = Convert.ToInt32(reader["No"]);
                        boardModel.Title = Convert.ToString(reader["Title"]);
                        boardModel.Name = Convert.ToString(reader["Name"]);
                        boardModel.RecommandCount = Convert.ToInt32(reader["RecommandCount"]);
                        boardModel.ReplyCount = Convert.ToInt32(reader["ReplyCount"]);
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
        public int PageAndFindBoardCount(string variable, string input)
        {
            int result = 0;
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.FindBoardListCount", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Input", input);
                    com.Parameters.AddWithValue("@Variable", variable);
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
        public int RecommandInfo(BoardModel boardModel)
        {
            int result = -1;
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetRecommandInfo", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@BoardNo", boardModel.No);
                    com.Parameters.AddWithValue("@Email", boardModel.Email);
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
        public void RecommandInsert(BoardModel boardModel)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.InsertRecommand", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@BoardNo", boardModel.No);
                    com.Parameters.AddWithValue("@Email", boardModel.Email);
                    com.ExecuteNonQuery();
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
        }
        public void RecommandDelete(BoardModel boardModeㅣ)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.DeleteRecommand", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@BoardNo", boardModel.No);
                    com.Parameters.AddWithValue("@Email", boardModel.Email);
                    com.ExecuteNonQuery();
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
        }
        public int GetRecommandCount(BoardModel boardModel)
        {
            int result = -1;
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetRecommandCount", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@BoardNo", boardModel.No);
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
        public void WriteFileBoard(int BoardNo, List<string> FileNames)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                for (int i = 0; i < FileNames.Count; i++)
                {
                    using (SqlCommand com = new SqlCommand("dbo.FileUpload", con))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@BoardNo", BoardNo);
                        com.Parameters.AddWithValue("@FileName", FileNames[i]);
                        com.ExecuteNonQuery();
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
        }
        public List<string> GetFileInfo(BoardModel boardModel)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            List<string> FileNameList = new List<string>();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetFileInfo", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", boardModel.No);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        boardModel.Title = Convert.ToString(reader["FileName"]);
                        FileNameList.Add(boardModel.Title);
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
            return FileNameList;
        }
        public bool ReplyWrite(ReplyModel replyModel)
        {
            bool result = false;
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.WriteReply", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@BoardNo", replyModel.BoardNo);
                    com.Parameters.AddWithValue("@ParentReplyNo", replyModel.@ParentReplyNo);
                    com.Parameters.AddWithValue("@Content", replyModel.@Content);
                    com.Parameters.AddWithValue("@Email", replyModel.@Email);
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
        public List<ReplyModel> GetReplyList(int BoardNo)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            List<ReplyModel> ReplyModelList = new List<ReplyModel>();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetReplyList", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@BoardNo", BoardNo);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        ReplyModel replyModel = new ReplyModel();
                        replyModel.No = Convert.ToInt32(reader["No"]);
                        replyModel.ParentReplyNo = Convert.ToInt32(reader["ParentReplyNo"]);
                        replyModel.Content = Convert.ToString(reader["Content"]);
                        replyModel.UserNo = Convert.ToInt32(reader["UserNo"]);
                        ReplyModelList.Add(replyModel);
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
            return ReplyModelList;
        }
        public List<ReplyModel> GetReReplyList(int ParentReplyNo)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            List<ReplyModel> ReplyModelList = new List<ReplyModel>();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.GetReReplyList", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ParentReplyNo", ParentReplyNo);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        ReplyModel replyModel = new ReplyModel();
                        replyModel.No = Convert.ToInt32(reader["No"]);
                        replyModel.Content = Convert.ToString(reader["Content"]);
                        replyModel.UserNo = Convert.ToInt32(reader["UserNo"]);
                        ReplyModelList.Add(replyModel);
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
            return ReplyModelList;
        }
        public string ReplyUerCheck(ReplyModel replyModel, Connection connection)
        {
            SqlConnection con = connection.ConOpen();
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.UserCheck", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", replyModel.UserNo);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        replyModel.Email = Convert.ToString(reader["Email"]);
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
            return replyModel.Email;
        }
        public bool ReplyDeleteReply(ReplyModel replyModel)
        {
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            bool flag = false;
            try
            {
                using (SqlCommand com = new SqlCommand("dbo.DeleteReply", con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@No", replyModel.No);
                    if(com.ExecuteNonQuery() != -1)
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
    }
}
