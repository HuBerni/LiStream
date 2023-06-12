using LiStreamData.DTO;
using LiStreamEF.Models;

namespace LiStreamEF.DTO
{
    public static class UserDtoExtension
    {
        public static UserDto ToUserDto(this User user, bool mapFavPlayables = false, bool mapPlaylists = false, bool mapFollowedCollections = false)
        {
            var userDto = new UserDto
            {
                Id = user.UserId,
                DisplayName = user.Name,
                Email = user.Email
            };

            if (mapFavPlayables)
                userDto.FavoritePlayables = user.UserFavoriteSongs?.Select(x => x.Song.ToSongDto()).ToList();

            if (mapPlaylists)
                userDto.Playlists = user.Playlists?.ToPlaylistDto();

            if (mapFollowedCollections)
                userDto.FollowedPlayableCollections = user.UserFollowedPlayableCollections.Select(x => x.ToPlayableCollectionDto()).ToList();

            return userDto;
        }

        public static IList<UserDto> ToUserDto(this ICollection<User> users, bool mapFavPlayables = false, bool mapPlaylists = false, bool mapFollowedCollections = false)
        {
            return users.Select(x => x.ToUserDto(mapFavPlayables, mapPlaylists, mapFollowedCollections)).ToList();
        }
    }
}
