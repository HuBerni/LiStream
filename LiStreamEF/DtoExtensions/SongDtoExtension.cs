using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class SongDtoExtension
    {
        public static SongDto ToSongDto(this Song song, ArtistDto? artist = null, AlbumDto? album = null, List<ArtistDto>? features = null)
        {
            return new SongDto()
            {
                Id = song.SongId,
                Data = song.Data,
                Name = song.Title,
                Artist = artist,
                Album = album,
                ReleaseDate = song.ReleaseDate,
                Features = features,
                PlayCount = song.PlayCount,
                Lenght = new TimeSpan(0, 0, song.Lenght)
            };
        }
    }
}
