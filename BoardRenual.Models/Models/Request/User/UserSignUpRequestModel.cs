using System;

namespace BoardRenual.Models.Models.Request.User
{
    public class UserSignUpRequestModel
    {
        public string Email { get; set; }
        public string Pw { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
    }
}