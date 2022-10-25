using BoardRenual.Models.Models;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Reply
{
    public class ReplyDeleteReplyBiz
    {
        public bool ReplyDeleteReply(int No)
        {
            ReplyModel replyModel = new ReplyModel();
            replyModel.No = No;
            return (new BoardRepository().ReplyDeleteReply(replyModel));
        }
    }
}