using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class ArtistDtoExtension
    {
        public static ArtistDto ToArtistDto(this Artist artist, bool mapAlbums = false, bool mapSongs = false)
        {
            var artistDto = new ArtistDto
            {
                Id = artist.ArtistId,
                Bio = artist.Bio,
                DisplayName = artist.Name,
                Email = artist.Email
            };

            artistDto.Albums = artist.Albums?.ToAlbumDto();
            artistDto.Singles = artist.SongsNavigation?.ToSongDto();

            return artistDto;
        }

        public static IList<ArtistDto> ToArtistDto(this ICollection<Artist> artists)
        {
            return artists.Select(x => x.ToArtistDto()).ToList();
        }
    }
}
