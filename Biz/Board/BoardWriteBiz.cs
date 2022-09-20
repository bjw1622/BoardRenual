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
        public int WriteBoard(BoardWriteRequestModel boardWriteModel)
        {
            BoardModel  boardModel = new BoardModel();
            BoardRepository boardRepository = new BoardRepository();
            boardModel.Title = boardWriteModel.Title;
            boardModel.Content = boardWriteModel.Content;
            boardModel.Email = boardWriteModel.Email;

            Connection connection = new Connection();
            return(boardRepository.WriteBoard(boardModel, connection));
        }
    }
}