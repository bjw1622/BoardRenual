using BoardRenual.Models;
using BoardRenual.Models.Request.Recommand;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Recommand
{
    public class RecommandGetCountBiz
    {
        public int GetRecommandCount(int Board_No)
        {
            BoardModel boardModel = new BoardModel();
            BoardRepository boardRepository = new BoardRepository();
            boardModel.No = Board_No;

            Connection connection = new Connection();
            return (boardRepository.GetRecommandCount(boardModel, connection));
        }
    }
}