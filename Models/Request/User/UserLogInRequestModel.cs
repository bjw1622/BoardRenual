using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardRenual.Models.RequestModel.User
{
    public class UserLogInModel
    {
        public string Email { get; set; }
        public string Pw { get; set; }
    }
}