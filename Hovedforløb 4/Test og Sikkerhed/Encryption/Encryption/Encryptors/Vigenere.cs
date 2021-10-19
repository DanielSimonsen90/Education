using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DanhoLibrary.Extensions;

namespace Encryption
{
    public class Vigenere : Ceasar
    {
        public static string Encrypt(string message, string keys) => HandleEncryption(message, keys, true);
        public static string Decrypt(string message, string keys) => HandleEncryption(message, keys, false);
        protected static string HandleEncryption(string message, string keys, bool encrypt, bool writeFile = true)
        {
            while (keys.Length < message.Length)
                keys += keys;

            char[] chars = FormatMessage(message).ToCharArray();
            keys = FormatMessage(keys);
            StringBuilder sb = new();
            int space = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                char key = keys[i - space];
                if (char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                    space++;
                    continue;
                }

                int keyIndex = Alphabet.IndexOf(key);
                sb.Append(HandleEncryption(c.ToString(), keyIndex, encrypt, false));
            }

            string result = sb.ToString();

            MayWriteFile(encrypt, writeFile, result);

            return result;
        }
        
        public static Dictionary<int, string> FindKey(string message)
        {
            return Alphabet.ToCharArray().Reduce((result, c, i, self) => 
                result.Set(i, Encrypt(message, i))
            , new Dictionary<int, string>());
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
                return letters.Reduce((result, c, i, self) => 
                {
                    result.Add(new List<char>(letters));
                    return result;
                }, new List<List<char>>());
            }
            Dictionary<int, int> GetCoincidences() //Dictionary<row, coincidences>
            {
                return DefineRows().Reduce((coincidences, row, i, self) =>
                {
                    int value = 0;

                    encrypted.ToCharArray().ForEach((_, j) =>
                    {
                        if (encrypted[j + i] == row[j]) 
                            value++;
                    });
                    coincidences.Add(i, value);
                    return coincidences;
                }, new Dictionary<int, int>());
            }
        }
        public static string FindKeys(string encrypted, string decrypted)
        {
            throw new NotImplementedException();
        }
    }
}
