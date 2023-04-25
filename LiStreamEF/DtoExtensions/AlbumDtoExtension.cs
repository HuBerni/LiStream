using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class AlbumDtoExtension
    {
        public static AlbumDto ToAlbumDto(this Album album, bool mapArtist = false, bool mapPlayables = false)
        {
            var albumDto = new AlbumDto
            {
                Id = album.AlbumId,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate,
            };

            if (mapArtist)
                albumDto.Artist = album.ArtistNavigation?.ToArtistDto();

            if (mapPlayables)
                albumDto.Playables = album.Songs?.ToSongDto();

            return albumDto;
        }

        public static IList<AlbumDto> ToAlbumDto(this ICollection<Album> albums, bool mapArtist = false, bool mapPlayables = false)
        {
            return albums.Select(x => x.ToAlbumDto(mapArtist, mapPlayables)).ToList();
        }
    }
}
