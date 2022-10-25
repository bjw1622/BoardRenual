using BoardRenual.Models.Models;
using BoardRenual.Models.Models.Request.Board;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Board
{
    public class BoardWriteBiz
    {
        public int WriteBoard(BoardWriteRequestModel boardWriteModel)
        {
            BoardModel  boardModel = new BoardModel();
            boardModel.Title = boardWriteModel.Title;
            boardModel.Content = boardWriteModel.Content;
            boardModel.Email = boardWriteModel.Email;

            return(new BoardRepository().WriteBoard(boardModel));
        }
    }
}