using System;

namespace ShortLink.Helpers
{
    
    public class LinkHelper
    {
        private const string Chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-";       

        public string GenerateShortLink()
        {
            Random rnd = new Random();
            string uid = "";
            for (int i = 0; i < 5; i++)
            {
                uid += Chars[rnd.Next(0, 63)];
            }
            return uid;
        }

        
    }
}