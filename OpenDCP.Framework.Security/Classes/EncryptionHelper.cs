using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace OpenDCP.Framework.Security.Classes
{
    public static class EncryptionHelper
    {
        private const int KeySize = 32; // AES-256 requires a 256-bit key (32 bytes)
        private const int IVSize = 16; // AES block size is 128 bits (16 bytes)
        private const int Iterations = 100000; // Number of PBKDF2 iterations

        public static string GenerateKey()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateKey();
                return Convert.ToBase64String(aes.Key)
                    .Replace('+', '-')
                    .Replace('/', '_')
                    .TrimEnd('=');
            }
        }

        // Old .NET Framework style decryption
        public static string DecryptLegacy(string input, string passPhrase)
        {
            var iv = Encoding.UTF8.GetBytes(passPhrase.Substring(0, 16));
            var cipherBytes = Convert.FromBase64String(input);
            using var pdb = new PasswordDeriveBytes(passPhrase, null);
            var keyBytes = pdb.GetBytes(32);

            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            using var decryptor = aes.CreateDecryptor(keyBytes, iv);
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cs, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        public static string Encrypt(string data, string key)
        {
            if (string.IsNullOrEmpty(key) || key.Length < KeySize)
                throw new ArgumentException("Key must be at least 32 characters long.", nameof(key));

            using var aes = Aes.Create();
            aes.Key = DeriveKey(key); // Derive the AES key from the user-provided key
            aes.GenerateIV(); // Generate a new IV for this encryption session

            var inputBytes = Encoding.UTF8.GetBytes(data);

            using var encryptor = aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock(); // Ensure all data is written
            }

            var encryptedBytes = ms.ToArray();

            // Combine IV and encrypted data
            var result = new byte[IVSize + encryptedBytes.Length];
            Buffer.BlockCopy(aes.IV, 0, result, 0, IVSize);
            Buffer.BlockCopy(encryptedBytes, 0, result, IVSize, encryptedBytes.Length);

            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string data, string key)
        {
            if (string.IsNullOrEmpty(key) || key.Length < KeySize)
                throw new ArgumentException("Key must be at least 32 characters long.", nameof(key));

            var inputBytes = Convert.FromBase64String(data);

            // Extract IV and cipher text
            var iv = inputBytes.Take(IVSize).ToArray();
            var cipherBytes = inputBytes.Skip(IVSize).ToArray();

            using var aes = Aes.Create();
            aes.Key = DeriveKey(key); // Derive the AES key from the user-provided key
            aes.IV = iv; // Set the extracted IV

            using var decryptor = aes.CreateDecryptor();
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.UTF8);

            return sr.ReadToEnd();
        }

        public static string EncryptConnectionString(JsonObject connectionString, string key)
        {
            var input = connectionString.ToJsonString();
            return Encrypt(input, key);
        }

        public static JsonObject DecryptConnectionString(string input, string key)
        {
            var jsonString = Decrypt(input, key);
            return JsonSerializer.Deserialize<JsonObject>(jsonString);
        }

        private static byte[] DeriveKey(string key)
        {
            // Use a deterministic salt for key derivation
            var salt = Encoding.UTF8.GetBytes("FixedSaltValue"); // Replace with a secure fixed value

            return KeyDerivation.Pbkdf2(
                password: key,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: KeySize
            );
        }
    }
}
