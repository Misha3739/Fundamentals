using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;

namespace Fundamentals.Utility
{
    public class FundamentalsPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
           
            var bytes =new UnicodeEncoding().GetBytes(password);

            var hash = new SHA256Managed().ComputeHash(bytes);
            return System.Convert.ToBase64String(hash);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var hashed = HashPassword(providedPassword);
            return hashed.Equals(hashedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}