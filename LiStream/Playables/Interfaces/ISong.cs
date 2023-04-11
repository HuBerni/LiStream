using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables.Interfaces
{
    public interface ISong : IPlayable
    {
        Guid Id { get; }
        byte[] Data { get; }
        string Title { get; }
        IArtistProfile Artist { get; }
        IAlbum? Album { get; }
        DateTime ReleaseDate { get; }
        List<IGenre> Genres { get; }
        List<IArtistProfile> Features { get; }
        long PlayCount { get; }
    }
}
