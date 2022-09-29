using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models.Request.Reply
{
    public class ReplyWriteRequestModel
    {
        public int BoardNo { get; set; }
        public int ParentReplyNo { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
    }
}