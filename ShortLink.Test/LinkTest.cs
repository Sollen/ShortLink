using Xunit;

using ShortLink.Helpers;

namespace ShortLink.Test
{
    public class LinkTest
    {
        [Fact]
        public void TestGenerateShortLink()
        {
            LinkHelper helper = new LinkHelper();
            string shortUrl, newShortUrl;
            for (int i = 0; i< 50; i++)
            {
                shortUrl = helper.GenerateShortLink();
                Assert.Equal(5, shortUrl.Length);
                newShortUrl = helper.GenerateShortLink();
                Assert.Equal(5, newShortUrl.Length);
                Assert.NotEqual(shortUrl, newShortUrl);
            }  
        }
    }
}
