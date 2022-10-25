using BoardRenual.Models.Models;
using BoardRenual.Repositorys;
using System.Collections.Generic;

namespace BoardRenual.Biz.Board
{
    public class BoardGetBoardListBiz
    {
        public List<BoardModel> GetBoardList()
        {
            return (new BoardRepository().GetBoardList());
        }
    }
}