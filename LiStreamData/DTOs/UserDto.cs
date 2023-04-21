namespace LiStreamData.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public IList<SongDto>? FavoritePlayables { get; set; }
        public IList<PlaylistDto>? Playlists { get; set; }
        public IList<PlayableCollectionDto>? FollowedPlayableCollections { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
