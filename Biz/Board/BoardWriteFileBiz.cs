using BoardRenual.Models;
using BoardRenual.Models.RequestModel.Board;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardWriteFileBiz
    {
        public void WriteFileBoard(List<string> FileName)
        {
            BoardModel boardModel = new BoardModel();
            BoardRepository boardRepository = new BoardRepository();
            for (int i = 0; i < FileName.Count; i++)
            {
                if (!(string.IsNullOrEmpty(FileName[i])))
                {
                    boardModel.FileName[i] = FileName[i];
                }
            }
            Connection connection = new Connection();
            boardRepository.WriteFileBoard(boardModel, connection);
        }
    }
}