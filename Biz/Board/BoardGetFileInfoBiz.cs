using BoardRenual.Models.Models;
using BoardRenual.Repositorys;
using System.Collections.Generic;

namespace BoardRenual.Biz.Board
{
    public class BoardGetFileInfoBiz
    {
        public List<string> BoardGetFileInfo(int BoardNo)
        {
            BoardModel boardModel = new BoardModel();
            boardModel.No = BoardNo;
            return(new BoardRepository().GetFileInfo(boardModel));
        }
    }
}