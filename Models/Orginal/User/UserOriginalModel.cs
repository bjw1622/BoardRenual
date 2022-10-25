using System;

namespace BoardRenual.Models.OrginalModel.User
{
    public class UserOriginalModel
    {
        public int No { get; set; }
        public string Email { get; set; }
        public string Pw { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public DateTime CreateDate { get; set; }
    }
}