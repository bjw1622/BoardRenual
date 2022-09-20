using BoardRenual.Models;
using BoardRenual.Models.RequestModel.Board;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardWriteBiz
    {
        public int InsertBoard(BoardWriteRequestModel boardWriteModel)
        {
            BoardModel  boardModel = new BoardModel();
            BoardRepository boardRepository = new BoardRepository();
            boardModel.Title = boardWriteModel.Title;
            boardModel.Content = boardWriteModel.Content;
            boardModel.Email = boardWriteModel.Email;

            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            return(boardRepository.WriteBoard(boardModel, con));
        }
        public List<BoardModel> GetBoardList()
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            return (boardRepository.GetBoardList(con));
        }
        public BoardModel GetBoardDetail(int No)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            SqlConnection con = connection.ConOpen();
            return (boardRepository.GetBoardDetail(con,No));
        }
    }
}