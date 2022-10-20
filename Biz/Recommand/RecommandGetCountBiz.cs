using BoardRenual.Models;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Recommand
{
    public class RecommandGetCountBiz
    {
        public int GetRecommandCount(int Board_No)
        {
            BoardModel boardModel = new BoardModel();
            boardModel.No = Board_No;
            return (new BoardRepository().GetRecommandCount(boardModel));
        }
    }
}