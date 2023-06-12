namespace LiStreamData.DTOs.CreateDTOs
{
    public class SongCreateDto
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
        public Guid? AlbumId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; } 
    }
}
