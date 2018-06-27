using System;
using System.Collections.Generic;
using System.Text;
using ShortLink.Helpers;
using ShortLink.Models;
using Xunit;

namespace ShortLink.Test
{
    public class EntityTest
    {
        [Fact]
        public void testGetUser()
        {
            UserRepository users = new UserRepository();
            User user = users.GetUser("User1");
            Assert.Equal(user.Login, new User(){Login = "User1"}.Login); 

        }
    }
}
