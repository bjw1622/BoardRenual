using BoardRenual.Models;
using BoardRenual.Models.Orginal.Page;
using BoardRenual.Models.Request.Page;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardFindAndPageCountRequestBiz
    {
        public int PageAndFindBoardCount(FindAndPageRequestModel findAndPageRequestModel)
        {
            BoardRepository boardRepository = new BoardRepository();
            PageOriginalModel pageOriginalModel = new PageOriginalModel();
            pageOriginalModel.Variable = findAndPageRequestModel.Variable;
            pageOriginalModel.Input = findAndPageRequestModel.Input;
            Connection connection = new Connection();
            return (boardRepository.PageAndFindBoardCount(pageOriginalModel, connection));
        }
    }
}