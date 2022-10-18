using BoardRenual.Models;
using BoardRenual.Models.Request.Reply;
using BoardRenual.Repositorys;

namespace BoardRenual.Biz.Reply
{
    public class ReplyWriteBiz
    {
        public bool ReplyWrite(ReplyWriteRequestModel replyWriteRequestModel)
        {
            ReplyModel replyModel = new ReplyModel();
            replyModel.BoardNo = replyWriteRequestModel.BoardNo;
            replyModel.ParentReplyNo = replyWriteRequestModel.ParentReplyNo;
            replyModel.Content = replyWriteRequestModel.Content;
            replyModel.Email = replyWriteRequestModel.Email;
            return(new BoardRepository().ReplyWrite(replyModel, new Connection()));
        }
    }
}