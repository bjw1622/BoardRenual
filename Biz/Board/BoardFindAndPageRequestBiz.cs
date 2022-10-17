using BoardRenual.Models;
using BoardRenual.Models.Request.Page;
using BoardRenual.Repositorys;
using System.Collections.Generic;

namespace BoardRenual.Biz.Board
{
    public class BoardFindAndPageRequestBiz
    {
        public List<BoardModel> PageAndFindBoard(FindAndPageRequestModel findAndPageRequestModel)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return (boardRepository.PageAndFindBoard(findAndPageRequestModel, connection));
        }
    }
}