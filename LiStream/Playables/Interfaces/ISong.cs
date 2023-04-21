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
        byte[] Data { get; }
        IArtistProfile Artist { get; }
        IAlbum? Album { get; }
        IList<IArtistProfile>? Features { get; }
        long PlayCount { get; }
    }
}
