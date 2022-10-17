using BoardRenual.Models.Request.Page;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Board
{
    public class BoardFindAndPageCountRequestBiz
    {
        public int PageAndFindBoardCount(FindAndPageRequestModel findAndPageRequestModel)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return (boardRepository.PageAndFindBoardCount(findAndPageRequestModel.Variable,findAndPageRequestModel.Input,connection));
        }
    }
}