using BoardRenual.Models.OrginalModel.Board;
using BoardRenual.Models.RequestModel.Board;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardWriteBiz
    {
        public void InsertBoard(BoardWriteModel boardWriteModel)
        {
            BoardModel boardEntity = new BoardModel();
            BoardRepository boardRepository = new BoardRepository();
            boardEntity.Title = boardWriteModel.Title;
            boardEntity.Content = boardWriteModel.Content;
            // join으로 가져와야 하는 테이블의 정보 같은 경우는 어떻게 처리?
        }
    }
}