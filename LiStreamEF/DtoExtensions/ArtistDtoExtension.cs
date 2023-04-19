using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class ArtistDtoExtension
    {
        public static ArtistDto ToArtistDto(this Artist artist, List<AlbumDto>? albums = null, List<SongDto>? singles = null)
        {
            return new ArtistDto()
            {
                Id = artist.ArtistId,
                Albums = albums,
                Singles = singles,
                Bio = artist.Bio,
                DisplayName = artist.Name,
                Email = artist.Email
            };
        }
    }
}
