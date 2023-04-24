using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class PlayableCollectionDtoExtension
    {
        public static PlayableCollectionDto ToPlayableCollectionDto(this UserFollowedPlayableCollection playableCollection, bool mapUser = false, bool mapAlbumOrPlaylist = false)
        {
            var playableCollectionDto = new PlayableCollectionDto
            {
                Id = playableCollection.FavoriteId,
            };

            if (mapUser)
                playableCollectionDto.User = playableCollection.User?.ToUserDto();

            if (mapAlbumOrPlaylist)
            {
                playableCollectionDto.Playlist = playableCollection.Playlist?.ToPlaylistDto(true, true);
                playableCollectionDto.Album =  playableCollection.Album?.ToAlbumDto(true , true);
            }

            return playableCollectionDto;
        }

        public static IList<PlayableCollectionDto> ToPlayableCollectionDto(this ICollection<UserFollowedPlayableCollection> playableCollections, bool mapUser = false, bool mapAlbumOrPlaylist = false)
        {
            return playableCollections.Select(x => x.ToPlayableCollectionDto(mapUser, mapAlbumOrPlaylist)).ToList();
        }
    }
}
