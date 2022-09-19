using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models.OrginalModel.User
{
    public class UserModel
    {
        public int No { get; set; }
        public string Email { get; set; }
        public string Pw { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public DateTime CreateDate { get; set; }
        //Email 확장 (extends,partialclass)
    }
}