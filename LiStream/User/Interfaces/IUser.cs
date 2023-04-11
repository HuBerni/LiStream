using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User.Interfaces
{
    public interface IUser
    {
        List<IPlayable>? FavoritePlayables { get; }

        IPlaylist CreatePlaylist(string name);
        bool DeletePlaylist(Guid id);
        void Follow(IProfile profile);
        void UnFollow(IProfile profile);
        void FollowPlayableCOllection(IPlayableCollection collection);
        void UnFollowPlayableCOllection(IPlayableCollection collection);
        void AddToFavoriteSongs(Guid id);
        void RemoveFromFavoriteSongs(Guid id);
    }
}
