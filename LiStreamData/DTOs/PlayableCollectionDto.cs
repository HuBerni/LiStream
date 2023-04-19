namespace LiStreamData.DTO
{
    public class PlayableCollectionDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public AlbumDto Album { get; set; }
        public PlaylistDto Playlist { get; set; }
    }
}
