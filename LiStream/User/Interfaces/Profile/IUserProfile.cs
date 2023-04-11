using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User.Interfaces.Profile
{
    public interface IUserProfile : IProfile
    {
        List<IPlaylist>? Playlists { get; }
        List<IProfile>? FollowedProfiles { get; }
        List<IPlayableCollection>? FollowedPlayableCollections { get; }
    }
}
