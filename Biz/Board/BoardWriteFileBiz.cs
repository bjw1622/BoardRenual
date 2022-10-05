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
        public void WriteFileBoard(int BoardNo, List<string> FileName)
        {
            BoardModel boardModel = new BoardModel();
            BoardRepository boardRepository = new BoardRepository();
            List<string> FileNames = new List<string>();
            if(FileName != null)
            {
                for (int i = 0; i < FileName.Count; i++)
                {
                    if (!(string.IsNullOrEmpty(FileName[i])))
                    {
                        boardModel.FileNameInfo = FileName[i];
                        FileNames.Add(boardModel.FileNameInfo);
                    }

                }
                Connection connection = new Connection();
                boardRepository.WriteFileBoard(BoardNo, FileNames, connection);
            }
            
        }
    }
}