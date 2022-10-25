using System.Collections.Generic;

namespace BoardRenual.Models.Models.Request.Board
{
    public class BoardWriteRequestModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public List<string> FileName { get; set; }
        public List<object> FormData { get; set; }
    }
}