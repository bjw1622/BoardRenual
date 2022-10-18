using BoardRenual.Models.Request.Page;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Board
{
    public class BoardFindAndPageCountRequestBiz
    {
        public int PageAndFindBoardCount(FindAndPageRequestModel findAndPageRequestModel)
        {
            return (new BoardRepository().PageAndFindBoardCount(findAndPageRequestModel.Variable,findAndPageRequestModel.Input, new Connection()));
        }
    }
}