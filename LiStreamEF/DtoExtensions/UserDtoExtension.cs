using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class UserDtoExtension
    {
        public static UserDto ToUserDto(this User user, List<SongDto>? favPlayables = null, List<PlaylistDto>? playlists = null, List<PlayableCollectionDto>? playableCollections = null)
        {
            return new UserDto()
            {
                Id = user.UserId,
                FavoritePlayables = favPlayables,
                Playlists = playlists,
                FollowedPlayableCollections = playableCollections,
                DisplayName = user.Name,
                Email = user.Email
            };
        }
    }
}
