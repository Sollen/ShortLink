using Microsoft.AspNetCore.Mvc;
using System;

namespace ShortLink.Controllers
{
    [Produces("application/json")]
    [Route("api/Link")]
    public class LinkController : Controller
    {
        private const string CHARS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-";
        Random rnd;
        public string Generate()
        {
            rnd = new Random();
            string uid = "";
            for (int i = 0; i < 5; i++)
            {
                uid += CHARS[rnd.Next(0, 63)];
            }
            return uid;
        }
    }
}