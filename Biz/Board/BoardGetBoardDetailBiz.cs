using BoardRenual.Models;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardGetBoardDetailBiz
    {
        public BoardModel GetBoardDetail(int No)
        {
            return (new BoardRepository().GetBoardDetail(new Connection(), No));
        }
    }
}