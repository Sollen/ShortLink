using System;

namespace ShortLink.Models
{
    public class Link
    {
        public Int64 Id { get; set; }
        public User User { get; set; }
        public string ShortUri { get; set; }
        public string Uri { get; set; }
        public DateTime CreateTime { get; set; }
        public int Follows { get; set; }
    }
}
