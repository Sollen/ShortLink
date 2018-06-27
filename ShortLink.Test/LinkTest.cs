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
            
            string shortUrl = controller.Generate();
            Assert.Equal(5, shortUrl.Length);
            string newShortUrl = controller.Generate();
            Assert.Equal(5, newShortUrl.Length);
            Assert.NotEqual(shortUrl, newShortUrl);

            
            

        }
    }
}
