using BoardRenual.Models;
using BoardRenual.Models.Request.Recommand;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Recommand
{
    public class RecommandInfoBiz
    {
        public int GetRecommandInfo(RecommandInfoRequestModel recommandInfoRequestModel)
        {
            BoardModel boardModel = new BoardModel();
            boardModel.No = recommandInfoRequestModel.BoardNo;
            boardModel.Email = recommandInfoRequestModel.Email;
            return (new BoardRepository().RecommandInfo(boardModel, new Connection()));
        }
    }
}