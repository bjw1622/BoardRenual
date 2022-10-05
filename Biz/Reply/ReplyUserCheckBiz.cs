using BoardRenual.Models;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Reply
{
    public class ReplyUserCheckBiz
    {
        public string ReplyUerCheck(int No)
        {
            ReplyModel replyModel = new ReplyModel();
            BoardRepository boardRepository = new BoardRepository();
            replyModel.UserNo = No;
            Connection connection = new Connection();
            return (boardRepository.ReplyUerCheck(replyModel, connection));
        }
    }
}