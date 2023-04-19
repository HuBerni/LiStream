using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListreamDTOs
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public List<AlbumDto>? Albums { get; set; }
        public List<SongDto>? Singles { get; set; }
        public string Bio { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
