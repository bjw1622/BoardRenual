using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models.Orginal.Page
{
    public class PageOriginalModel
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public string Variable { get; set; }
        public string Input { get; set; }
    }
}