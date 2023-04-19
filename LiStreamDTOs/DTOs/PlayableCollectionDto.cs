using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListreamDTOs
{
    public class PlayableCollectionDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public AlbumDto? Album { get; set; }
        public PlaylistDto? Playlist { get; set; }
    }
}
