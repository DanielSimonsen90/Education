using DanhoLibrary.Extensions;
using MIG.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIG.Song
{
    public class Artist
    {
        public string Name { get; set; }
        public List<Track> Releases { get; set; }
        public List<Track> Remixes { get; set; }
        public List<Track> AllTracks
        {
            get
            {
                List<Track> temp = new();
                temp.AddRange(Releases);
                if (Remixes != null) temp.AddRange(Remixes);
                return temp;
            }
        }

        public List<Genre> Genres
        {
            get
            {
                List<Genre> temp = new();
                foreach (Track track in AllTracks)
                    foreach (Genre genre in track.Genres)
                        if (!temp.Contains(genre)) temp.Add(genre);
                return temp;
            }
        }

        public Artist(string name, Track[] releases)
        {
            Name = name;
            Releases = releases.ToList();
        }
        public Artist(string name, Track[] releases, Track[] remixes) : this(name, releases) => Remixes = remixes.ToList();

        public Track GetTrack(Genre genre) => RandomFromQuery((t, i, arr) => t.Title == genre.Title);
        public Track GetTrack(string title) => RandomFromQuery((t, i, arr) => t.Title.Contains(title));

        private Track RandomFromQuery(DanhoExtender.FilterCallback<Track> callback) => AllTracks.Filter(callback).GetRandomItem();
    }
}
