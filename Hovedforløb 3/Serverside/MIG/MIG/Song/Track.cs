using System;
using System.Collections.Generic;

namespace MIG.Song
{
    public class Track
    {
        public string Title { get; set; }
        public Length Length { get; set; }
        public List<Genre> Genres { get; set; }
        public Reference Reference { get; set; }
    }
}
