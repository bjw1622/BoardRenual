using BoardRenual.Models.Models;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Board
{
    public class BoardGetBoardEmailBiz
    {
        public BoardModel GetBoardEmail(int No)
        {
            return (new BoardRepository().GetBoardEmail(No));
        }
    }
}