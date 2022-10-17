using BoardRenual.Models;
using BoardRenual.Models.Request.Page;
using BoardRenual.Repositorys;
using System.Collections.Generic;

namespace BoardRenual.Biz.Board
{
    public class BoardPagingBiz
    {
        public List<BoardModel> IndexPagingBoard(PageRequestModel pageRequestModel)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return (boardRepository.IndexPagingBoard(pageRequestModel, connection));
        }
    }
}