﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models
{
    public partial class ReplyModel
    {
        public int No { get; set; }
        public int BoardNo { get; set; }
        public int ParentReplyNo { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Content { get; set; }
        public int UserNo { get; set; }
    }
}