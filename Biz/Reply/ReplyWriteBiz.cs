using BoardRenual.Models.Orginal.Reply;
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
            replyModel.BoardNo = replyWriteRequestModel.BoardNo;
            BoardRepository boardRepository = new BoardRepository();
        }
    }
}