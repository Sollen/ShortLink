using System;
using Xunit;
using ShortLink.Controllers;

namespace ShortLink.Test
{
    public class LinkTest
    {
        [Fact]
        public void testGenerateShortLink()
        {
            LinkController controller = new LinkController();
            string shortUrl = "", newShortUrl = "";
            for (int i = 0; i< 50; i++)
            {
                shortUrl = controller.Generate();
                Assert.Equal(5, shortUrl.Length);
                newShortUrl = controller.Generate();
                Assert.Equal(5, newShortUrl.Length);
                Assert.NotEqual(shortUrl, newShortUrl);
            }  
        }
    }
}
