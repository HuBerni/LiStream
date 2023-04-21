using System.Reflection.Metadata.Ecma335;

namespace LiStreamData.DTO
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public IList<AlbumDto>? Albums { get; set; }
        public IList<SongDto>? Singles { get; set; }
        public string Bio { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
