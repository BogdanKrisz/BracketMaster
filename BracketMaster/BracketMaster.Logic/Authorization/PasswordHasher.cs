using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Logic
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) 
                rng.GetBytes(salt);

            int iterations = 150000;
            int hashSize = 64;

            byte[] hash = KeyDerivation.Pbkdf2(
                            password: password,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA512,
                            iterationCount: iterations,
                            numBytesRequested: hashSize);

            return $"{Convert.ToBase64String(hash)}:{Convert.ToBase64String(salt)}:{iterations}";
        }

        public bool VerifyPassword(string givenPassword, string storedHash)
        {
            var parts = storedHash.Split('.');
            if (parts.Length != 3 ) 
                return false;

            byte[] hash = Convert.FromBase64String(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            int iterations = int.Parse(parts[2]);

            byte[] computedHash = KeyDerivation.Pbkdf2(
                                    password: givenPassword,
                                    salt: salt,
                                    prf: KeyDerivationPrf.HMACSHA512,
                                    iterationCount: iterations,
                                    numBytesRequested: hash.Length);

            return CryptographicOperations.FixedTimeEquals(computedHash, hash);
        }
    }
}
