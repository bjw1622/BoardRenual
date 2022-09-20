using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardDeleteBoardBiz
    {
        public void DeleteBoard(int No)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            boardRepository.DeleteBoard(connection, No);
        }
    }
}