using BoardRenual.Models;
using BoardRenual.Repositorys;
using System.Collections.Generic;

namespace BoardRenual.Biz.Reply
{
    public class ReplyGetReReplyListBiz
    {
        public List<ReplyModel> ReplyGetReReplyList(int ParentReplyNo)
        {
            ReplyModel replyModel = new ReplyModel();
            replyModel.ParentReplyNo = ParentReplyNo;
            Connection connection = new Connection();
            return(new BoardRepository().GetReReplyList(ParentReplyNo, connection));
        }
    }
}