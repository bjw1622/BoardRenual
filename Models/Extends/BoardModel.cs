using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models
{
    public partial class BoardModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int RecommandCount { get; set; }
        public List<string> FileName { get; set; }
    }
}