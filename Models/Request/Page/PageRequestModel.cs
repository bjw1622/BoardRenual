using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models.Request.Page
{
    public class PageRequestModel
    {
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
    }
}