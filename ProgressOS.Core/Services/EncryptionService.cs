using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ProgressOS.Core.Abstractions;
using System.Security.Cryptography;
using System.Text;

namespace ProgressOS.Core.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly int _iteration;
        private readonly int _saltSize;
        private readonly int _hashSize;
        private readonly int _ivSize;
        private readonly string _masterPassword;
        private byte[] _salt;
        private byte[] _key;
        private byte[] _iv;
        public EncryptionService(string masterPassword)
        {
            _iteration = 10000;
            _saltSize = 32;
            _hashSize = 32;
            _ivSize = 16;
            _masterPassword = masterPassword;
            _salt = GenerateRandomSalt();
            _iv = GenerateRandomIV();
            _key = GenerateKey(_masterPassword, _salt);
        }

        public EncryptionService(string masterPassword, int iteration, int saltSize, int hashSize,
            int ivSize)
        {
            _iteration = iteration;
            _saltSize = saltSize;
            _hashSize = hashSize;
            _ivSize = ivSize;
            _masterPassword = masterPassword;
            _salt = GenerateRandomSalt();
            _iv = GenerateRandomIV();
            _key = GenerateKey(_masterPassword, _salt);
        }

        public EncryptionResponce EncryptionData(string data)
        {
            EncryptionResponce responce = new EncryptionResponce();
            try
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] encryptedData = EncryptData(dataBytes, _key, _iv);
                responce.EncryptingData = Convert.ToBase64String(encryptedData);
                responce.IsFailed = false;
            }
            catch
            {
                responce.IsFailed = true;
            }

            return responce;
        }

        public EncryptionResponce DecryptionData(string cryptingData)
        {
            EncryptionResponce responce = new EncryptionResponce();
            try
            {
                byte[] restoredBytes = Convert.FromBase64String(cryptingData);
                byte[] decryptedData = DecryptData(restoredBytes, _key, _iv);
                responce.EncryptingData = Encoding.UTF8.GetString(decryptedData);
                responce.IsFailed = false;
            }
            catch
            {
                responce.IsFailed = true;
            }
            return responce;
        }

        private byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[_saltSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private byte[] GenerateRandomIV()
        {
            byte[] iv = new byte[_ivSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv);
            }
            return iv;
        }

        private byte[] GenerateKey(string masterPass, byte[] salt)
        {
            byte[] hash = KeyDerivation.Pbkdf2(
                password: masterPass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: _iteration,
                numBytesRequested: _hashSize);

            return hash;
        }

        private byte[] EncryptData(byte[] plainData, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream memoryStream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainData, 0, plainData.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        private byte[] DecryptData(byte[] encryptedData, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (MemoryStream resultStream = new MemoryStream())
                {
                    cryptoStream.CopyTo(resultStream);
                    return resultStream.ToArray();
                }
            }
        }
    }

    public class EncryptionResponce
    {
        public string EncryptingData { get; set; } = string.Empty;
        public bool IsFailed { get; set; }
    }
}
