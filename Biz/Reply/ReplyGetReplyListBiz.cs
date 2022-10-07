using BoardRenual.Models;
using BoardRenual.Repositorys;
using System.Collections.Generic;

namespace BoardRenual.Biz.Reply
{
    public class ReplyGetReplyListBiz
    {
        public List<ReplyModel> GetReplyList(int BoardNo)
        {
            Connection connection = new Connection();
            return(new BoardRepository().GetReplyList(BoardNo,connection));
        }
    }
}