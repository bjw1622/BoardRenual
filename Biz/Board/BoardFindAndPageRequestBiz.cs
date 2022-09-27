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
    public class BoardFindAndPageRequestBiz
    {
        public List<BoardModel> PageAndFindBoard(FindAndPageRequestModel findAndPageRequestModel)
        {
            BoardRepository boardRepository = new BoardRepository();
            PageOriginalModel pageOriginalModel = new PageOriginalModel();
            pageOriginalModel.PageNumber = findAndPageRequestModel.PageNumber;
            pageOriginalModel.PageCount = findAndPageRequestModel.PageCount;
            pageOriginalModel.Variable = findAndPageRequestModel.Variable;
            pageOriginalModel.Input = findAndPageRequestModel.Input;
            Connection connection = new Connection();
            return (boardRepository.PageAndFindBoard(pageOriginalModel, connection));
        }
    }
}