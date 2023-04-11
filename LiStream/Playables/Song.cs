using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    public class Song : ISong
    {
        public Guid Id { get; private set; }

        public byte[] Data { get; private set; }

        public string Title { get; private set; }

        public IArtistProfile Artist { get; private set; }

        public IAlbum Album { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public List<IGenre> Genres { get; private set; }

        public List<IArtistProfile> Features { get; private set; }

        public long PlayCount { get; private set; }

        public TimeSpan Lenght { get; private set; }

        public TimeSpan CurrentPosition { get; private set; }

        public IPlayable getSimilar()
        {
            throw new NotImplementedException();
        }

        public IPlayable getSimilarList()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }
    }
}
