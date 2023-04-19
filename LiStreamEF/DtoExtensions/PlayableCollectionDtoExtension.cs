using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
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
