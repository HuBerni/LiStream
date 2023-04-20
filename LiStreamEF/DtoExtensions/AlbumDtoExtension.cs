using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class AlbumDtoExtension
    {
        public static AlbumDto ToAlbumDto(this Album album, ArtistDto? artist = null, List<SongDto>? playables = null)
        {
            playables = playables ?? new();

            return new AlbumDto()
            {
                Id = album.AlbumId,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate,
                Artist = artist,
                Playables = playables
            };
        }
    }
}
