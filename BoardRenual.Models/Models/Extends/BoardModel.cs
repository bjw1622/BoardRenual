using System.Collections.Generic;

namespace BoardRenual.Models.Models
{
    public partial class BoardModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int RecommandCount { get; set; }
        public int ReplyCount { get; set; }
        public List<string> FileName { get; set; }
        public string FileNameInfo { get; set; }
    }
}