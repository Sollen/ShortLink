using System.Collections.Generic;
using Moq;
using ShortLink.Helpers;
using ShortLink.Helpers.Abstract;
using ShortLink.Models;
using Xunit;
using static ShortLink.Helpers.EntityHelper;

namespace ShortLink.Test
{
    public class EntityTest
    {
        private EntityHelper _dbContext;
        public EntityTest()
        {
            var repo = new Mock<IRepository>();
            repo.Setup(u => u.GetUser(It.IsAny<string>())).Returns<string>(login => {

                if (login != "User1" && login != "User2" && login != "User3") return null;
                return new User { Login = login };
            });
            repo.Setup(u => u.GetUserLinks(It.IsAny<string>())).Returns<string>(login =>
            {
                if (login != "User1" && login != "User2" && login != "User3") return null;
                var linkList = new List<Link>();
                var link = new Link()
                {
                    User = new User { Login = login }
                };
                linkList.Add(link);
                return linkList;
            });
            repo.Setup(u => u.GetLink(It.IsAny<string>())).Returns<string>(shortUri =>
            {
                if (shortUri != "zx34r" && shortUri != "qaswd" && shortUri != "qwert") return null;
                return new Link() { ShortUri = shortUri, Uri = "www.google.com" }; ;
            });
            _dbContext = new EntityHelper(repo.Object);
        }
        
        [Theory]
        [InlineData("User1")]
        [InlineData("User2")]
        [InlineData("User3")]
        public void TestGetUser(string login)
        {
            User user = _dbContext.GetUser(login);
            Assert.Equal(user, new User{Login = login}); 
        }

        [Theory]
        [InlineData("User4")]
        [InlineData("User5")]
        [InlineData("User6")]
        public void TestUserNotFound(string login)
        {
            string message = $"User: {login} not found";
            var exception = Assert.Throws<UserNotFoundExcception>(() => _dbContext.GetUser(login));
            Assert.Equal(exception.Message, message);
        }

        [Theory]
        [InlineData("User1")]
        [InlineData("User2")]
        [InlineData("User3")]
        public void TestGetLinksByUser(string login)
        {
            var links = _dbContext.GetUserLinks(login);
            foreach (var link in links)
            {
                Assert.Equal(link.User, new User { Login = login});
            }
            
        }

        [Theory]
        [InlineData("User4")]
        [InlineData("User5")]
        [InlineData("User6")]
        public void TestNotFoundLinksByUser(string login)
        {
            string message = $"links for User: {login} not found";
            var exception = Assert.Throws<LinkByUserNotFoundExcception>(() => _dbContext.GetUserLinks(login));
            Assert.Equal(exception.Message, message);

        }

        [Theory]
        [InlineData("qwert")]
        [InlineData("qaswd")]
        [InlineData("zx34r")]
        public void TestGetLinkByShortUrl(string shortUri)
        {
            Link link = _dbContext.GetLink(shortUri);
            Assert.Equal(shortUri, link.ShortUri);
        }
        
        [Theory]
        [InlineData("qwer1")]
        [InlineData("qasw2")]
        [InlineData("zx343")]
        public void TestNotFoundLinkByShortUrl(string shortUri)
        {
            string message = $"link {shortUri} not found";
            var exception = Assert.Throws<LinkByShortUriNotFoundExcception>(() => _dbContext.GetLink(shortUri));
            Assert.Equal(exception.Message, message);
        }
        
        

    }
}
