using LiStream.Playables.Interfaces;
using LiStreamEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamEF.DTO
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<SongDto>? Playables { get; set; }
        public UserDto Owner { get; set; }

        public LiStream.Playables.Playlist ToPlaylist()
        {
            List<IPlayable> playables = new List<IPlayable>();
            Playables.Select(x => x.ToSong()).ToList();

            return new LiStream.Playables.Playlist(Id, Name, Owner.ToUser(), CreationDate, playables);
        }
    }

    public static class PlaylistDtoExtension
    {
        public static PlaylistDto ToPlaylistDto(this Playlist playlist)
        {
            return new PlaylistDto()
            {
                Id = playlist.PlaylistId,
                Name = playlist.Name,
                CreationDate = playlist.CreationDate,
                Owner = playlist.OwnerNavigation.ToUserDto()
            };
        }
    }
}
