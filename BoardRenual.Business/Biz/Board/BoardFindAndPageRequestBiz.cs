using BoardRenual.Models.Models;
using BoardRenual.Models.Models.Request.Page;
using BoardRenual.Repositorys;
using System.Collections.Generic;

namespace BoardRenual.Biz.Board
{
    public class BoardFindAndPageRequestBiz
    {
        public List<BoardModel> PageAndFindBoard(FindAndPageRequestModel findAndPageRequestModel)
        {
            return (new BoardRepository().PageAndFindBoard(findAndPageRequestModel));
        }
    }
}