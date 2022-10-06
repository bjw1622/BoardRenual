using BoardRenual.Models;
using BoardRenual.Models.Request.Recommand;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Recommand
{
    public class RecommandDeleteBiz
    {
        public void RecommandDelete(RecommandInfoRequestModel recommandInfoRequestModel)
        {
            BoardModel boardModel = new BoardModel();
            BoardRepository boardRepository = new BoardRepository();
            boardModel.No = recommandInfoRequestModel.BoardNo;
            boardModel.Email = recommandInfoRequestModel.Email;

            Connection connection = new Connection();
            boardRepository.RecommandDelete(boardModel, connection);
        }
    }
}