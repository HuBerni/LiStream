using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListreamDTOs
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
