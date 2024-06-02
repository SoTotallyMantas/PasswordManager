using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.Util
{
    internal class AES
    {


        public static void EncryptFile(string plainText, string key, string path)
        {
            byte[] convertedkey = Convert.FromBase64String(key);
            byte[] encrypted = EncryptStringToBytes_Aes(plainText, convertedkey);
                

                System.IO.File.WriteAllBytes(path, encrypted);
            

        }

        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            if (Key == null || Key.Length != 32)
                throw new ArgumentNullException(nameof(Key));
            byte[] encrypted;
            byte[] IV;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.GenerateIV();
                IV = aesAlg.IV;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (System.IO.StreamWriter swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            byte[] result = new byte[IV.Length + encrypted.Length];
            IV.CopyTo(result, 0);
            encrypted.CopyTo(result, IV.Length);
            return result;
        }

        public static string DecryptFile(string path, string key)
        {
            byte[] encrypted = System.IO.File.ReadAllBytes(path);
            byte[] bytes = Convert.FromBase64String(key);
            return DecryptStringFromBytes_Aes(encrypted, bytes);
        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));
            if (Key == null || Key.Length != 32)
                throw new ArgumentNullException(nameof(Key));
        
            byte[] IV = new byte[16];
            byte[] cipher = new byte[cipherText.Length - 16];
            Array.Copy(cipherText, 0, IV, 0, 16);
            Array.Copy(cipherText, 16, cipher, 0, cipherText.Length - 16);
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
               
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream(cipher))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (System.IO.StreamReader srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                    }
                }
                
            return plaintext;
                }
            }

        }
