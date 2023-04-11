using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    public class Genre : IGenre
    {
        public string Name { get; }
        public string Description { get; }
    }
}
