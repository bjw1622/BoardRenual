using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models.OrginalModel.Board
{
    public class BoardModel
    {
        public int No { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UserNo { get; set; }
    }
}