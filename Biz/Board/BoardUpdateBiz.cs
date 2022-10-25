using BoardRenual.Models.Models;
using BoardRenual.Models.Models.Request.Board;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Board
{
    public class BoardUpdateBiz
    {
        public bool UpdateBoard(BoardUpdateRequestModel boardUpdateRequestModel)
        {
            BoardModel boardModel = new BoardModel();
            boardModel.No = boardUpdateRequestModel.No;
            boardModel.Title = boardUpdateRequestModel.Title;
            boardModel.Content = boardUpdateRequestModel.Content;

            return (new BoardRepository().UpdateBoard(boardModel));
        }
    }
}