using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models.Request.Board
{
    public class BoardUpdateRequestModel
    {
        public int No { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}