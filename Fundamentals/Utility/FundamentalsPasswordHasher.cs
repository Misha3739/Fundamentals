using System.Text;
using Microsoft.AspNet.Identity;

namespace Fundamentals.Utility
{
    public class FundamentalsPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
           
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashed = new byte[bytes.Length];
            for (int i = 0; i < hashed.Length; i++)
            {
                hashed[i] = (byte)(bytes[i] ^ 12);
            }
            return Encoding.UTF8.GetString(hashed);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return HashPassword(providedPassword).Equals(hashedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}