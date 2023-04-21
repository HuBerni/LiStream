using LiStream.Interfaces;
using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User.Interfaces.Profile
{
    public interface IArtistProfile : IProfile, IEvaluateable<IArtistProfile>
    {
        IList<IAlbum>? Albums { get; }
        IList<IPlayable>? Singles { get; }
        string? Bio { get; }
    }
}
