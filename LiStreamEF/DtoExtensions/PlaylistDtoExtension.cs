using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class PlaylistDtoExtension
    {
        public static PlaylistDto ToPlaylistDto(this Playlist playlist, bool mapOwner = false, bool mapPlayables = false)
        {
            var playlistDto = new PlaylistDto
            {
                Id = playlist.PlaylistId,
                Name = playlist.Name,
                CreationDate = playlist.CreationDate,
            };

            if (mapOwner)
                playlistDto.Owner = playlist.OwnerNavigation?.ToUserDto();

            if (mapPlayables)
                playlistDto.Playables = playlist.PlaylistItems?.Select(x => x.Song.ToSongDto()).ToList();

            return playlistDto;
        }

        public static IList<PlaylistDto> ToPlaylistDto(this ICollection<Playlist> playlists, bool mapOwner = false, bool mapPlayables = false)
        {
            return playlists.Select(x => x.ToPlaylistDto(mapOwner, mapPlayables)).ToList();
        }
    }
}
