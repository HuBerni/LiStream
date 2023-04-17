using LiStream.Playables.Interfaces;
using LiStreamEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamEF.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public List<SongDto> FavoritePlayables { get; set; }
        public List<PlaylistDto> Playlists { get; set; }
        public List<PlayableCollectionDto> FollowedPlayableCollections { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }

        public LiStream.User.User ToUser()
        {
            List<IPlayable> favSongs = new List<IPlayable>();
            FavoritePlayables.ForEach(x => favSongs.Add(x.ToSong()));

            List<IPlayableCollection> followedCollections = new List<IPlayableCollection>();
            FollowedPlayableCollections.ForEach(x => followedCollections.Add(x.ToPlayableCollection()));

            List<IPlaylist> playlists = new List<IPlaylist>();
            Playlists.ForEach(x => playlists.Add(x.ToPlaylist()));

            return new LiStream.User.User(Id, favSongs, null, playlists, DisplayName, Email);
        }
    }

    public static class UserDtoExtension
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto()
            {
                Id = user.UserId,
                FavoritePlayables = user.UserFavoriteSongs.Select(x => x.Song.ToSongDto()).ToList(),
                Playlists = user.Playlists.Select(x => x.ToPlaylistDto()).ToList(),
                FollowedPlayableCollections = user.UserFollowedPlayableCollections.Select(x => x.ToPlayableCollectionDto()).ToList(),
                DisplayName = user.Name,
                Email = user.Email
            };
        }
    }
}
