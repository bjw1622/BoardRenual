using BoardRenual.Models;
using BoardRenual.Repositorys;
using System.Collections.Generic;

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