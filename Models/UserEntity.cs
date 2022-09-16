using System;

namespace BoardRenual.Models
{
    public class UserEntity
    {
        public string Email { get; set; }
        public string Pw { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
    }
}