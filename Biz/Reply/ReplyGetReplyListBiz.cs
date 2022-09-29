using BoardRenual.Models;
using BoardRenual.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Biz.Reply
{
    public class ReplyGetReplyListBiz
    {
        public List<ReplyModel> GetReplyList(int BoardNo)
        {
            BoardRepository boardRepository = new BoardRepository();
            Connection connection = new Connection();
            return(boardRepository.GetReplyList(BoardNo,connection));
        }
    }
}