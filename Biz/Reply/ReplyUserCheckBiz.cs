using BoardRenual.Models.Models;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Reply
{
    public class ReplyUserCheckBiz
    {
        public string ReplyUerCheck(int No)
        {
            ReplyModel replyModel = new ReplyModel();
            replyModel.UserNo = No;
            return (new BoardRepository().ReplyUerCheck(replyModel, new Connection()));
        }
    }
}