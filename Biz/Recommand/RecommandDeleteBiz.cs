using BoardRenual.Models;
using BoardRenual.Models.Request.Recommand;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Recommand
{
    public class RecommandDeleteBiz
    {
        public void RecommandDelete(RecommandInfoRequestModel recommandInfoRequestModel)
        {
            BoardModel boardModel = new BoardModel();
            boardModel.No = recommandInfoRequestModel.BoardNo;
            boardModel.Email = recommandInfoRequestModel.Email;
            Connection connection = new Connection();
            new BoardRepository().RecommandDelete(boardModel, connection);
        }
    }
}