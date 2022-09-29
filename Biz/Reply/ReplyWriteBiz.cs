using BoardRenual.Models;
using BoardRenual.Models.Request.Reply;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Reply
{
    public class ReplyWriteBiz
    {
        public void ReplyWrite(ReplyWriteRequestModel replyWriteRequestModel)
        {
            ReplyModel replyModel = new ReplyModel();
            BoardRepository boardRepository = new BoardRepository();
            replyModel.BoardNo = replyWriteRequestModel.BoardNo;
            replyModel.ParentReplyNo = replyWriteRequestModel.ParentReplyNo;
            replyModel.Content = replyWriteRequestModel.Content;
            replyModel.Email = replyWriteRequestModel.Email;
            Connection connection = new Connection();
            boardRepository.ReplyWrite(replyModel, connection);
        }
    }
}