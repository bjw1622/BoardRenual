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
            // 객체를 넘기기
            return(boardRepository.WriteBoard(boardModel, connection));
        }
        public List<BoardModel> GetBoardList()
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return (boardRepository.GetBoardList(connection));
        }
        public BoardModel GetBoardDetail(int No)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return (boardRepository.GetBoardDetail(connection, No));
        }
        public BoardModel GetBoardEmail(int No)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return (boardRepository.GetBoardEmail(connection, No));
        }
        public void DeleteBoard(int No)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            boardRepository.DeleteBoard(connection, No);
        }
    }
}