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
        public IList<IPlayable>? FavoritePlayables { get; private set; }

        public IList<IPlaylist>? Playlists { get; private set; }

        public IList<IPlayableCollection>? FollowedPlayableCollections { get; private set; }

        public string DisplayName { get; private set; }

        public string Email { get; private set; }

        public User(Guid id, IList<IPlayable> favPlayables, IList<IPlayableCollection> followedCollections, IList<IPlaylist> playlists, string displayName, string email)
        {
            Id = id;
            FavoritePlayables = favPlayables;
            FollowedPlayableCollections = followedCollections;
            Playlists = playlists;
            DisplayName = displayName;
            Email = email;
        }

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

        public void FollowPlayableCollection(IPlayable collection)
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

        public void UnFollowPlayableCollection(IPlayable collection)
        {
            throw new NotImplementedException();
        }
    }
}
