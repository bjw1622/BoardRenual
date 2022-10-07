using BoardRenual.Models;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Reply
{
    public class ReplyUserCheckBiz
    {
        public string ReplyUerCheck(int No)
        {
            ReplyModel replyModel = new ReplyModel();
            replyModel.UserNo = No;
            Connection connection = new Connection();
            return (new BoardRepository().ReplyUerCheck(replyModel, connection));
        }
    }
}