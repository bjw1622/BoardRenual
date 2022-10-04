using BoardRenual.Models;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Reply
{
    public class ReplyGetReReplyListBiz
    {
        public List<ReplyModel> ReplyGetReReplyList(int ParentReplyNo)
        {
            ReplyModel replyModel = new ReplyModel();
            BoardRepository boardRepository = new BoardRepository();
            replyModel.ParentReplyNo = ParentReplyNo;
            Connection connection = new Connection();
            return(boardRepository.GetReReplyList(ParentReplyNo, connection));
        }
    }
}