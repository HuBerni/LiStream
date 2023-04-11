using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables.Interfaces
{
    public interface IAlbum : IPlayableCollection
    {
        Guid Id { get; }
        string Name { get; }
        DateTime ReleaseDate { get; }
        IArtistProfile Artist { get; }
    }
}
