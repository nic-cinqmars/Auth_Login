using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Login
{
    internal class Cryptography
    {
        private static int saltLength = 8;
        private static int iterations = 10000;

        public static string EncryptString(string input, string password, byte[] salt)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] randomSalt = GetRandomBytes();
            byte[] encryptedBytes = new byte[inputBytes.Length + randomSalt.Length];
            for (int i = 0; i < randomSalt.Length; i++)
            {
                encryptedBytes[i] = randomSalt[i];
            }
            for (int i = 0; i < inputBytes.Length; i++)
            {
                encryptedBytes[i + randomSalt.Length] = inputBytes[i];
            }

            encryptedBytes = AES_Encrypt(encryptedBytes, passwordBytes, salt);

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptString(string input, string password, byte[] salt)
        {
            byte[] inputBytes = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] decryptedBytes = AES_Decrypt(inputBytes, passwordBytes, salt);

            int saltLength = GetSaltLength();
            byte[] result = new byte[decryptedBytes.Length - saltLength];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = decryptedBytes[i + saltLength];
            }

            return Encoding.UTF8.GetString(result);
        }

        public static string HashString(string input, byte[] salt)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = PBKDF2_Hash(inputBytes, salt);
            return Convert.ToBase64String(hashedBytes);
        }

        private static byte[] AES_Encrypt(byte[] bytesToEncrypt, byte[] passwordBytes, byte[] salt)
        {
            byte[] encryptedBytes;

            using (MemoryStream ms = new MemoryStream())
            {
                using (Aes AES = Aes.Create())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, salt, iterations);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private static byte[] AES_Decrypt(byte[] bytesToDecrypt, byte[] passwordBytes, byte[] salt)
        {
            byte[] decryptedBytes;

            using (MemoryStream ms = new MemoryStream())
            {
                using (Aes AES = Aes.Create())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, salt, iterations);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToDecrypt, 0, bytesToDecrypt.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private static byte[] PBKDF2_Hash(byte[] bytesToHash, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(bytesToHash, salt, iterations);
            byte[] hashedBytes = pbkdf2.GetBytes(20);
            return hashedBytes;
        }

        public static byte[] GetRandomBytes()
        {
            byte[] ba = new byte[saltLength];
            RandomNumberGenerator.Create().GetBytes(ba);
            return ba;
        }

        public static int GetSaltLength()
        {
            return saltLength;
        }
    }
}
