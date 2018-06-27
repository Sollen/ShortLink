using Xunit;
using ShortLink.Helpers;
using ShortLink.Models;


namespace ShortLink.Test
{
    public class AccountTest
    {
        private AccountHelper _helper;
        public AccountTest()
        {
            _helper = new AccountHelper();
        }

        [Fact]
        public void TestGenerateToken()
        {
            string token, newToken;
            token = _helper.GenerateToken(new User{Login= "User1"});
            newToken = _helper.GenerateToken(new User { Login = "User2" });
            Assert.NotEqual(token, newToken);
            
        }
    }
}
