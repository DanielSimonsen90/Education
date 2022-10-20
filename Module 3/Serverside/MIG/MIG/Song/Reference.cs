using DanhoLibrary.Extensions;
namespace MIG.Song
{
    public class Reference
    {
        public Artist Artist { get; set; }
        public Track Track { get; set; }
        public Genre Genre { get; set; }

        public Reference(Genre genre)
        {
            Genre = genre;
            //Artist = GetAllArtists().Filter((a, aIndex, aArr) => a.AllTracks.Filter((t, tIndex, tArr) => t.Genres.Contains(genre)).Count > 0).GetRandomItem();
            Track = Artist.AllTracks.Filter((t, i, arr) => t.Genres.Contains(genre)).GetRandomItem();
        }
        public Reference(Artist artist)
        {
            Artist = artist;
            Track = artist.AllTracks.GetRandomItem();
            Genre = Track.Genres.GetRandomItem();
        }
        public Reference(Genre genre, Artist artist)
        {
            Genre = genre;
            Artist = artist;
            Track = artist.AllTracks.Filter((t, i, arr) => t.Genres.Contains(genre)).GetRandomItem();
        }
    }
}