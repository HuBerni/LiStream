using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class SongDtoExtension
    {
        public static SongDto ToSongDto(this Song song, bool mapArtist = false, bool mapAlbum = false)
        {
            var songDto = new SongDto
            {
                Id = song.SongId,
                Data = song.Data,
                Name = song.Title,
                ReleaseDate = song.ReleaseDate,
                PlayCount = song.PlayCount,
                Lenght = new TimeSpan(0, 0, song.Lenght)
            };

            if (mapArtist)
                songDto.Artist = song.Artist?.ToArtistDto();

            if (mapAlbum)
                songDto.Album = song.Album?.ToAlbumDto();

            return songDto;
        }

        public static IList<SongDto> ToSongDto(this ICollection<Song> songs, bool mapArtist = false, bool mapAlbum = false)
        {
            return songs.Select(x => x.ToSongDto(mapArtist, mapAlbum)).ToList();
        }

    }
}
