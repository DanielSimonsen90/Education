using System;
using System.Collections.Generic;
using DanhoLibrary;
using System.Linq;
using DanhoLibrary.Extensions;
using MIG.Song;

namespace MIG.DataStuff
{
    class Title
    {
        private static List<string> Result { get; } = new();

        public override string ToString() => GetTitle();
        public static string GetTitle() => GetTitle(Dictionary);
        public static string GetTitle(string[] Dictionary)
        {
            //Result title & individual word
            string Title = string.Empty, Word;

            //Randomize amount of words
            for (int x = 0; x < ConsoleItems.RandomNumber(2, 4); x++)
                //Word = Random word from Dictionary array, returns true of Word is valid
                if (GetAvailabilityConditions(Title, Word = Dictionary.GetRandomItem().ToLower()))
                    //Unless Word is "I", lowercase word
                    Title += (Word == "I") ? $"{Word} " : $"{Word.ToLower()} ";
                //If Word is invalid, go back a step to select new random Word
                else x--;

            //Return Title with capital first letter
            return Title.Capitalize();
        }

        /// <summary>
        /// If <paramref name="Word"/> contains special character or <paramref name="Title"/> already contains <paramref name="Word"/>, return false else true
        /// </summary>
        private static bool GetAvailabilityConditions(string Title, string Word)
        {
            if (Title.Contains(Word)) return false;
            if (Names.BannedWords.Contains(Word)) return false;
            if (Word.Contains("(") || Word.Contains(")")) return false;
            if (Word.Contains("\"")) return false;
            if (Word.Contains("[") || Word.Contains("]")) return false;
            return true;
        }

        public static string[] Dictionary
        {
            get
            {
                foreach (Artist artist in Data.GetArtists())
                    GoThroughTracks(artist.AllTracks.ToArray());

                return Result.ToArray();
            }
        }

        /// <summary> Used in <see cref="Dictionary"/> get{} </summary>
        private static void GoThroughTracks(Track[] tracks) => 
            Result.AddRange(
                from Track track in tracks
                from string Word in GetWords(track)
                where !Result.Contains(Word)
                select Word
            );

        /// <summary> Used in <see cref="GoThroughTracks(Track[])"/> </summary>
        private static List<string> GetWords(Track track)
        {
            List<string> result = new();
            int firstIndex = 0;
            for (int x = 0; x < track.Title.Length; x++)
                if (track.Title[x] != ' ')
                {
                    string word = track.Title.Substring(firstIndex, x - firstIndex);
                    if (!result.Contains(word))
                        result.Add(word);
                    firstIndex = x += 1;
                }
            return result;
        }
    }
}