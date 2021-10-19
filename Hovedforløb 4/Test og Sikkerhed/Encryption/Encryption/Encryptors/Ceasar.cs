using System.Text;

namespace Encryption
{
    public class Ceasar : IEncryptor
    {
        public static string Encrypt(string message, int key) => HandleEncryption(message, key, true);
        public static string Decrypt(string message, int key) => HandleEncryption(message, key, false);
        protected static string HandleEncryption(string message, int key, bool encrypt, bool writeFile = true)
        {
            char[] chars = FormatMessage(message).ToCharArray();
            StringBuilder sb = new();

            for (int i = 0; i < chars.Length; i++)
            {
                int indexInAlphabet = Alphabet.IndexOf(chars[i]);
                int index = encrypt ? indexInAlphabet + key : indexInAlphabet - key;
                if (index < 0) index = Alphabet.Length + index;
                else if (index >= Alphabet.Length) index -= Alphabet.Length;

                char value = char.IsWhiteSpace(chars[i]) ? chars[i] : Alphabet[index];
                sb.Append(value);
            }

            string result = sb.ToString();

            MayWriteFile(encrypt, writeFile, result);

            return result;
        }
    }
}
