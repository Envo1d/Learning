using System;

namespace XOR_Method
{
    public class Chiper
    {
        private static string Cipher(string text, int secretKey)
        {
            string result = string.Empty;
            for (int i = 0; i < text.Length; i++)
                result += (char)(text[i] ^ secretKey);
            return result;
        }
        public static string Encrypt(string plainText, int password)
        => Cipher(plainText, password);
        public static string Decrypt(string encryptedText, int password)
        => Cipher(encryptedText, password);
    }
}
