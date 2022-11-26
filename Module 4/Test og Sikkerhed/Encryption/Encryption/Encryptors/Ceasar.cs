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
                //Which direction to go in the alphabet, depending on the encrypt value
                int index = encrypt ? indexInAlphabet + key : indexInAlphabet - key;
                //index too low? Move to end of alphabet and subtract the current index number
                if (index < 0) index = Alphabet.Length + index;
                //index too high? Remove alphabet's length from index (Move index to start of alphabet)
                else if (index >= Alphabet.Length) index -= Alphabet.Length;

                //If char isn't a space, set value as Alphabet[index], else ignore (treat as space)
                char value = char.IsWhiteSpace(chars[i]) ? chars[i] : Alphabet[index];
                sb.Append(value);
            }

            string result = sb.ToString();

            MayWriteFile(encrypt, writeFile, result);

            return result;
        }
    }
}
