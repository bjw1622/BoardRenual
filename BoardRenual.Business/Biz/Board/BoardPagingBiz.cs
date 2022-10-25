using BoardRenual.Models.Models;
using BoardRenual.Models.Models.Request.Page;
using BoardRenual.Repositorys;
using System.Collections.Generic;

namespace BoardRenual.Biz.Board
{
    public class BoardPagingBiz
    {
        public List<BoardModel> IndexPagingBoard(PageRequestModel pageRequestModel)
        {
            return (new BoardRepository().IndexPagingBoard(pageRequestModel));
        }
    }
}