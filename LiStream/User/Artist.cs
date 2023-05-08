using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User
{
    public class Artist : IArtistProfile, IDisplayable
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

        public string GetDisplayableName()
        {
            return DisplayName;
        }

        public IList<DisplayableInformation> GetAdditionalInformation()
        {
            return new List<DisplayableInformation>()
            {
                new DisplayableInformation("Name", DisplayName),
                new DisplayableInformation("Bio", Bio)
            };
        }

        public bool IsPlaying()
        {
            throw new NotImplementedException();
        }
    }
}
