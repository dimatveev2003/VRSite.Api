using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace VRSite.Api.Business.ClientBusiness.Helpers
{
    public static class PasswordHashHelper
    {
        private const string Base64Salt = "IOWyS4qJ4s1FiDuurza/Dg==";

        public static string CreatePasswordHash(string password)
        {
            byte[] salt = Convert.FromBase64String(Base64Salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256,
                10000, 256 / 8));

            return hashed;
        }
    }
}
