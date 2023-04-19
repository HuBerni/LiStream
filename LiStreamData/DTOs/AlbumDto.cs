namespace LiStreamData.DTO
{
    public class AlbumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ArtistDto? Artist { get; set; }
        public List<SongDto>? Playables { get; set; }
    }
}
