using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortLink.Models
{
    public class User
    {
        public Int64 Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
