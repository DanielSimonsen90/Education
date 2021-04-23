using DanhoLibrary.Extensions;
using System;
using System.Linq;
using MIG.Exceptions;
using System.Collections.Generic;

namespace MIG.Song
{
    public class Scale
    {
        public static Dictionary<string, string> Keys { get; } = SetKeys();
        private static Dictionary<string, string> SetKeys()
        {
            var temp = new Dictionary<string, string>();
            string[] keys = new string[] { "A", "A#/Bb", "B", "C", "C#/Db", "D#/Eb", "E", "F", "F#/Gb", "G" };
            string[] values = new string[] { "A", "A♯/B♭", "B", "C", "C♯/D♭", "D", "D♯/E♭", "E", "F", "F♯/G♭", "G" };

            for (int i = 0; i < keys.Length; i++)
                temp.Add(keys[i], values[i]);
            return temp;
        }
        public string Key { get; set; }

        public string Mood { get; set; }

        public Scale(string key, Mood mood)
        {
            if (!Keys.ContainsKey(key)) throw new InvalidKeyException($"{key} must be in range of: {Keys.Keys.ToArray().Join(", ")}");
            Key = Keys[key];
            Mood = mood.ToString();
        }
    }
    public enum Mood { Major, Minor }
}