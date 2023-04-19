using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListreamDTOs
{
    public class SongDto
    {
        public Guid Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public ArtistDto? Artist { get; set; }
        public AlbumDto? Album { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ArtistDto>? Features { get; set; }
        public long PlayCount { get; set; }
        public TimeSpan Lenght { get; set; }
    }
}
