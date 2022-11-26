using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption
{
    public class Vigenere : Ceasar
    {
        public static string Encrypt(string message, string keys) => HandleEncryption(message, keys, true);
        public static string Decrypt(string message, string keys) => HandleEncryption(message, keys, false);
        protected static string HandleEncryption(string message, string keys, bool encrypt, bool writeFile = true)
        {
            //Add key together with itself, until it matches or is above the message length
            while (keys.Length < message.Length)
                keys += keys;

            char[] chars = FormatMessage(message).ToCharArray();
            keys = FormatMessage(keys);
            StringBuilder sb = new();
            //When encoutering a space, the key index should not be affected
            int space = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                //current char
                char c = chars[i];
                //key for char
                char key = keys[i - space];

                //char is space, add 1 to space variable and continue loop
                if (char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                    space++;
                    continue;
                }

                //Index of key, to treat as key from Ceasar encryption
                int keyIndex = Alphabet.IndexOf(key);
                
                sb.Append(HandleEncryption(c.ToString(), keyIndex, encrypt, false));
            }

            string result = sb.ToString();

            MayWriteFile(encrypt, writeFile, result);

            return result;
        }
        
        public static Dictionary<int, string> FindKey(string message)
        {
            char[] letters = Alphabet.ToCharArray();
            Dictionary<int, string> result = new();

            for (int i = 0; i < letters.Length; i++)
                result.Add(i, Encrypt(message, i));

            return result;
        }
        public static string FindKeys(string encrypted)
        {
            int length = GetKeyLength();

            for (int i = 1; i < length; i++)
            {

            }

            throw new NotImplementedException();

            //Functions

            int GetKeyLength()
            {
                var rows = DefineRows();
                var coincidences = GetCoincidences();
                int average = int.Parse(coincidences.Values.Average().ToString());

                for (int i = 1; i < rows.Count; i++)
                {
                    int preCoincidence = coincidences[i - 1];
                    int coincidence = coincidences[i];

                    if (preCoincidence - coincidence > average || 
                        coincidence - preCoincidence > average) 
                        return i;
                }
                return -1;
            }
            List<List<char>> DefineRows()
            {
                char[] letters = encrypted.ToCharArray();
                List<List<char>> result = new();

                foreach (var letter in letters)
                    result.Add(new List<char>(letters));

                return result;
            }
            Dictionary<int, int> GetCoincidences() //Dictionary<row, coincidences>
            {
                List<List<char>> rows = DefineRows();
                Dictionary<int, int> coincidences = new();

                for (int i = 0; i < rows.Count; i++)
                {
                    List<char> row = rows[i];
                    int value = 0;

                    for (int j = 0; j < encrypted.ToCharArray().Length; j++)
                        if (encrypted[j + i] == row[j]) 
                            value++;

                    coincidences.Add(i, value);
                }

                return coincidences;
            }
        }
        public static string FindKeys(string encrypted, string decrypted)
        {
            throw new NotImplementedException();
        }
    }
}
