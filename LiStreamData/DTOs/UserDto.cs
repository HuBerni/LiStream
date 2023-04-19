namespace LiStreamData.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public List<SongDto>? FavoritePlayables { get; set; }
        public List<PlaylistDto>? Playlists { get; set; }
        public List<PlayableCollectionDto>? FollowedPlayableCollections { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
