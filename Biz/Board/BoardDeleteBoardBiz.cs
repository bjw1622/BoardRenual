using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Board
{
    public class BoardDeleteBoardBiz
    {
        public bool DeleteBoard(int No)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return(boardRepository.DeleteBoard(connection, No));
        }
    }
}