using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShortLink.Config
{
    public class AuthConfig
    {
        public const string SecretKey = "dhx|$O~[c>k8+]m1W<OG";
        public const string Issuer = "MyAuthServer";
        public const int TokenLifetime = 5;


        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }
    }
}
