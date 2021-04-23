using System.Collections.Generic;
using DanhoLibrary.Extensions;
using MIG.DataStuff;
using MIG.Helpers;
using static MIG.DataStuff.Names;

namespace MIG.Song
{
    public class Track
    {
        public string Title { get; set; }
        public Length Length { get; set; }
        public List<Genre> Genres { get; set; }
        public Reference Reference { get; set; }
        public Scale Scale { get; set; }

        public Track(string title, string length, params Genres[] genres)
        {
            Title = title;
            Length = new Length(Time.ToSeconds(length));
            Genres = new List<Genre>().AddRange<Genre>(genres.Map(genre => Data.GetGenres()[genre.ToString()])) as List<Genre>;
        }
    }
}
