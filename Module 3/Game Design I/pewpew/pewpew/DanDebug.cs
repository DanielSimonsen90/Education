using System;
using System.Diagnostics;
using System.IO;

namespace pewpew
{
    public class DanDebug
    {
        private static string FilePath(string name) => $"../../../DanDebug/{name}.txt";
        private static readonly object Lock = new();
        public static void Write(string fileName, string text)
        {
            string file = FilePath(fileName);
            string content = $"[{DateTime.Now:HH:mm}]: {text}\n{new StackTrace()}\n\n";

            if (!File.Exists(file))
                File.Create(file).Close();

            lock (Lock) File.AppendAllText(file, content);
        }
    }
}
