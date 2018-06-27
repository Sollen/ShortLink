using System.Collections.Generic;
using Moq;
using ShortLink.Helpers;
using ShortLink.Helpers.Abstract;
using ShortLink.Models;
using Xunit;

namespace ShortLink.Test
{
    public class EntityTest
    {
        private EntityHelper _dbContext;
        public EntityTest()
        {
            var repo = new Mock<IRepository>();
            repo.Setup(u => u.GetUser(It.IsAny<string>())).Returns<string>(login => new User { Login = login });
            repo.Setup(u => u.GetUserLinks(It.IsAny<string>())).Returns<string>(login =>
            {
                var linkList = new List<Link>();
                var link = new Link()
                {
                    User = new User { Login = login }
                };
                linkList.Add(link);
                return linkList;
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
        [InlineData("User1")]
        [InlineData("User2")]
        [InlineData("User3")]
        public void TestGetLinks(string login)
        {
            var links = _dbContext.GetUserLinks(login);
            foreach (var link in links)
            {
                Assert.Equal(link.User, new User { Login = login});
            }
            
        }
    }
}
