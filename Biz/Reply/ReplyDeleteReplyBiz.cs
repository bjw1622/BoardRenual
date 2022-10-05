using BoardRenual.Models;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Reply
{
    public class ReplyDeleteReplyBiz
    {
        public bool ReplyDeleteReply(int No)
        {
            ReplyModel replyModel = new ReplyModel();
            BoardRepository boardRepository = new BoardRepository();
            replyModel.No = No;
            Connection connection = new Connection();
            return (boardRepository.ReplyDeleteReply(replyModel, connection));
        }
    }
}