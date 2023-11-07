﻿using System.IO;
using System.Linq;

namespace Encryption
{
    public abstract class IEncryptor
    {
        public static string Alphabet => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Converts <paramref name="message"/> to uppercase and removes any unnecessary characters
        /// </summary>
        /// <param name="message">Message to format</param>
        public static string FormatMessage(string message) => new (message
            .ToUpper()
            .ToCharArray()
            .Where(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c))
            .ToArray());

        /// <summary>
        /// if <paramref name="encrypt"/> && <paramref name="write"/>, writes "encrypted.txt" file with <paramref name="content"/> as content
        /// </summary>
        /// <param name="encrypt">If method that called this is encrypting a message</param>
        /// <param name="write">Whether to write the file or not</param>
        /// <param name="content">Content of the file</param>
        protected static void MayWriteFile(bool encrypt, bool write, string content)
        {
            if (encrypt && write) File.WriteAllText("encrypted.txt", content);
        }
    }
}
