using System;

namespace ShortLink.Models
{
    public class User
    {
        public Int64 Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            User user = (User) obj;
            return this.Login == user.Login;
        }
    }
}
