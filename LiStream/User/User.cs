using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User
{
    public class User : IUserProfile, IUser
    {
        public Guid Id { get; private set; }
        public List<IPlayable>? FavoritePlayables { get; private set; }

        public List<IPlaylist>? Playlists { get; private set; }

        public List<IProfile>? FollowedProfiles { get; private set; }

        public List<IPlayableCollection>? FollowedPlayableCollections { get; private set; }


        public string DisplayName { get; private set; }

        public void AddToFavoriteSongs(Guid id)
        {
            throw new NotImplementedException();
        }

        public IPlaylist CreatePlaylist(string name)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlaylist(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Follow(IProfile profile)
        {
            throw new NotImplementedException();
        }

        public void FollowPlayableCollection(IPlayableCollection collection)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromFavoriteSongs(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UnFollow(IProfile profile)
        {
            throw new NotImplementedException();
        }

        public void UnFollowPlayableCollection(IPlayableCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}
