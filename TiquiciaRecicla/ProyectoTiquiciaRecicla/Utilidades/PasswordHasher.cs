using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoTiquiciaRecicla.Utilidades
{
   
        public static class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                var salt = Encoding.ASCII.GetBytes("your_salt_here");
                var hashedBytes = KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 128 / 8);

                return Convert.ToBase64String(hashedBytes);
            }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            var salt = Encoding.ASCII.GetBytes("your_salt_here");
            var hashedInput = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 128 / 8);

            return hashedPasswordBytes.SequenceEqual(hashedInput);
        }
    }
    }
