using BoardRenual.Models;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Reply
{
    public class ReplyDeleteReplyBiz
    {
        public bool ReplyDeleteReply(int No)
        {
            ReplyModel replyModel = new ReplyModel();
            replyModel.No = No;
            Connection connection = new Connection();
            return (new BoardRepository().ReplyDeleteReply(replyModel, connection));
        }
    }
}