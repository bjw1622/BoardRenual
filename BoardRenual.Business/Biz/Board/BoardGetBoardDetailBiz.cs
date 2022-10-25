using BoardRenual.Models.Models;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Board
{
    public class BoardGetBoardDetailBiz
    {
        public BoardModel GetBoardDetail(int No)
        {
            return (new BoardRepository().GetBoardDetail(No));
        }
    }
}