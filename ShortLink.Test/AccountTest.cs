using System;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xunit;
using ShortLink.Controllers;
using ShortLink.Models;


namespace ShortLink.Test
{
    public class AccountTest
    {
        [Fact]
        public void testGenerateToken()
        {
            LinkController controller = new LinkController();
            string token = "", newToken = "";
           
            token = controller.GenerateToken(new User{Login= "User1"});
            newToken = controller.GenerateToken(new User { Login = "User2" });
            Assert.NotEqual(token, newToken);
            
        }
    }
}
