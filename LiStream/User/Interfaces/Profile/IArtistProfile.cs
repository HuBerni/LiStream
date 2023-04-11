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
        List<IAlbum>? Albums { get; }
        List<IPlayable>? Singles { get; }
        string? Bio { get; }
        List<IArtistProfile>? SimilarArtists { get; }
    }
}
