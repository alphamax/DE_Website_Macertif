
using System.Security.Cryptography;
using WebCom.Data;
using WebCom.Services.Interfaces;

namespace WebCom.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private WebComContext _Context;
        public AuthenticationService(WebComContext context)
        {
            _Context = context;
        }

        public bool AuthenticateUser(string login, string password)
        {
            var user = _Context.Users.FirstOrDefault(item => item.Email == login);
            if (user == null)
            {
                return false;
            }
            var hashPassword = HashPassword(password, "SALT");
            return user.HashPassword == hashPassword;
        }

        public bool AuthenticateUser(string login, string password)
        {
            var user = _Context.Users.FirstOrDefault(item => item.Email == login);
            if (user == null)
            {
                return false;
            }
            var hashPassword = HashPassword(password, "SALT");
            return user.HashPassword == hashPassword;
        }

        private string HashPassword(string input, string salt)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            using (var sha = SHA256.Create())
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }
    }
}
