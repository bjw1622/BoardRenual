using BoardRenual.Models;
using BoardRenual.Models.Request.Board;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardUpdateBiz
    {
        public bool UpdateBoard(BoardUpdateRequestModel boardUpdateRequestModel)
        {
            BoardModel boardModel = new BoardModel();
            boardModel.No = boardUpdateRequestModel.No;
            boardModel.Title = boardUpdateRequestModel.Title;
            boardModel.Content = boardUpdateRequestModel.Content;

            return (new BoardRepository().UpdateBoard(boardModel));
        }
    }
}