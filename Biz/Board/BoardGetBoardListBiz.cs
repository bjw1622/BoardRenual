using BoardRenual.Models;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardGetBoardListBiz
    {
        public List<BoardModel> GetBoardList()
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return (boardRepository.GetBoardList(connection));
        }
    }
}