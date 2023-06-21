using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Hasher
{
    public class PasswordHasher<T> : IPasswordHasher<T> where T : class
    {
        public string HashPassword(T user, string password)
        {
            throw new NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(T user, string? hashedPassword, string providedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
