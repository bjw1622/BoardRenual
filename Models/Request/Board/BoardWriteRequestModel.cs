using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models.RequestModel.Board
{
    public class BoardWriteModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
    }
}