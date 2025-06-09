using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

//password hasher found in docs and stackoverflow
//https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-5.0
//https://stackoverflow.com/questions/4181198/how-to-hash-a-password

namespace CarDealershipFinal.DatabaseFiles
{
    /// <summary>
    /// Static class to hash passwords
    /// </summary>
    public static class PasswordHasher
    {

        /// <summary>
        /// Hashes a password with a random 16 bit salt. 
        /// </summary>
        /// <param name="password"></param>
        /// <returns>returns a tuple of hash and salt as they are required for verification</returns>
        public static (string Hash, string Salt) HashPassword(string password)
        {
            // Generate a random salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            // Hash the password with the salt - online examples use 100000 iterations
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32); // 256-bit hash

                // Return Base64 versions to store as strings
                return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes));
            }
        }

        /// <summary>
        /// Verify the password with the given hash and salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="storedHash"></param>
        /// <param name="storedSalt"></param>
        /// <returns>true if the passwords matach and false if they dont</returns>
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            //Get the salt converted
            byte[] saltBytes = Convert.FromBase64String(storedSalt);

            //recreates the hash with the original salt and compares the hash values
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(32);
                string computedHash = Convert.ToBase64String(hashBytes);

                return computedHash == storedHash;
            }
        }

    }
}
