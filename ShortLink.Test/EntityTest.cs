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


        [Fact]
        public void TestGetUser()
        {
            User user = _dbContext.GetUser("User1");
            Assert.Equal(user.Login, new User{Login = "User1"}.Login); 
        }

        [Fact]
        public void TestGetLinks()
        {
            var links = _dbContext.GetUserLinks("User1");
            foreach (var link in links)
            {
                Assert.Equal(link.User.Login, new User { Login = "User1" }.Login);
            }
            
        }
    }
}
