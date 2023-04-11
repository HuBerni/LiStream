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
        public List<IAlbum>? Albums { get; protected set; }

        public List<IPlayable>? Singles { get; protected set; }

        public string? Bio { get; }

        public List<IArtistProfile>? SimilarArtists { get; private set; }


        public string DisplayName { get; private set; }

        public IArtistProfile getSimilar()
        {
            throw new NotImplementedException();
        }

        public IArtistProfile getSimilarList()
        {
            throw new NotImplementedException();
        }
    }
}
