using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class PlaylistDtoExtension
    {
        public static PlaylistDto ToPlaylistDto(this Playlist playlist, UserDto? owner = null)
        {
            return new PlaylistDto()
            {
                Id = playlist.PlaylistId,
                Name = playlist.Name,
                CreationDate = playlist.CreationDate,
                Owner = owner
            };
        }
    }
}
