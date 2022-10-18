using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Board
{
    public class BoardDeleteBoardBiz
    {
        public bool DeleteBoard(int No)
        {
            return(new BoardRepository().DeleteBoard(new Connection(), No));
        }
    }
}