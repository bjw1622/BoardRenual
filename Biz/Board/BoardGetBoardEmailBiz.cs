using BoardRenual.Models;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Board
{
    public class BoardGetBoardEmailBiz
    {
        public BoardModel GetBoardEmail(int No)
        {
            return (new BoardRepository().GetBoardEmail(new Connection(), No));
        }
    }
}