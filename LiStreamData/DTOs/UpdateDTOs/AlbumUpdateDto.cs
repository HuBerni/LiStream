namespace LiStreamData.DTOs.UpdateDTOs
{
    public class AlbumUpdateDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid ArtistId { get; set; }
        public Guid AlbumId { get; set; }
    }
}
