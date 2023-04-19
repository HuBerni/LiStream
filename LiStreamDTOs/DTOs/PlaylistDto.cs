using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListreamDTOs
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<SongDto>? Playables { get; set; }
        public UserDto? Owner { get; set; }
    }
}
