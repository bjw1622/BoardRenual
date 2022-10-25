namespace BoardRenual.Models.Models.Request.Page
{
    public class FindAndPageRequestModel
    {
            public int PageNumber { get; set; }
            public int PageCount { get; set; }
            public string Variable { get; set; }
            public string Input { get; set; }
    }
}