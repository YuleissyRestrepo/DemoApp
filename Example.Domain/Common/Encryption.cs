using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Example.Domain.Common
{
    public static class Encryption
    {
        public static bool ValidateEncodedPassword(this string password, string hashedContrasena)
        {
            byte[] contrasenaBytes = Encoding.UTF8.GetBytes(password);
            using SHA256 sha256Hash = SHA256.Create();
            string saltedHash = Convert.ToBase64String(sha256Hash.ComputeHash(contrasenaBytes));
            byte[] hashedContrasenaBytes = Encoding.UTF8.GetBytes(hashedContrasena);
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(saltedHash);
            return hashedContrasenaBytes.SequenceEqual(saltedHashBytes);
        }
        public static string GenerarHash(this string contrasena)
        {
            byte[] contrasenaBytes = Encoding.UTF8.GetBytes(contrasena);
            using SHA256 sha256Hash = SHA256.Create();
            return Convert.ToBase64String(sha256Hash.ComputeHash(contrasenaBytes));
        }
    }
}
