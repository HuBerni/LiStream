using LiStream.Playables.Interfaces;
using LiStreamEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamEF.DTO
{
    public class PlayableCollectionDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public AlbumDto Album { get; set; }
        public PlaylistDto Playlist { get; set; }

        public IPlayableCollection ToPlayableCollection()
        {
            if (Album != null)
            {
                return Album.ToAlbum();
            }
            else if (Playlist != null)
            {
                return Playlist.ToPlaylist();
            }
            else
            {
                throw new Exception("PlayableCollectionDto is not valid");
            }
        }
    }

    public static class PlayableCollectionDtoExtension
    {
        public static PlayableCollectionDto ToPlayableCollectionDto(this UserFollowedPlayableCollection playableCollection)
        {
            return new PlayableCollectionDto()
            {
                Id = playableCollection.FavoriteId,
                User = playableCollection.User.ToUserDto(),
                Album = playableCollection.Album.ToAlbumDto(),
                Playlist = playableCollection.Playlist.ToPlaylistDto(),
            };
        }
    }
}
