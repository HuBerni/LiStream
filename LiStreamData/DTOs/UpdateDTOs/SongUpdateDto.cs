namespace LiStreamData.DTOs.UpdateDTOs
{
    public class SongUpdateDto
    {
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public Guid? AlbumId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
