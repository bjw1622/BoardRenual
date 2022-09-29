using BoardRenual.Models;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardGetFileInfoBiz
    {
        public List<string> BoardGetFileInfo(int BoardNo)
        {
            BoardModel boardModel = new BoardModel();
            BoardRepository boardRepository = new BoardRepository();
            boardModel.No = BoardNo;
            Connection connection = new Connection();
            return(boardRepository.GetFileInfo(boardModel, connection));
        }
    }
}