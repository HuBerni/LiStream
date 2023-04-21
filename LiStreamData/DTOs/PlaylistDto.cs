namespace LiStreamData.DTO
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public IList<SongDto>? Playables { get; set; }
        public UserDto? Owner { get; set; }
    } 
}
