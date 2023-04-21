using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User
{
    public class Artist : IArtistProfile
    {
        public Guid Id { get; protected set; }
        public IList<IAlbum>? Albums { get; protected set; }

        public IList<IPlayable>? Singles { get; protected set; }

        public string? Bio { get; }

        public string DisplayName { get; private set; }

        public string Email { get; private set; }

        public Artist(Guid id, IList<IAlbum> albums, IList<IPlayable> singles, string bio, string displayName, string email)
        {
            Id = id;
            Albums = albums;
            Singles = singles;
            Bio = bio;
            DisplayName = displayName;
            Email = email;
        }

        public IArtistProfile getSimilar()
        {
            throw new NotImplementedException();
        }

        public IList<IArtistProfile> getSimilarList()
        {
            throw new NotImplementedException();
        }
    }
}
