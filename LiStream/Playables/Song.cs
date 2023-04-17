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

        public string Name { get; private set; }

        public IArtistProfile Artist { get; private set; }

        public IAlbum? Album { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public List<IArtistProfile>? Features { get; private set; }

        public long PlayCount { get; private set; }

        public TimeSpan Lenght { get; private set; }

        public Song(Guid id, byte[] data, string title, IArtistProfile artist, IAlbum album, DateTime releaseDate, List<IArtistProfile> features, long playCount, TimeSpan lenght)
        {
            Id = id;
            Data = data;
            Name = title;
            Artist = artist;
            Album = album;
            ReleaseDate = releaseDate;
            Features = features;
            PlayCount = playCount;
            Lenght = lenght;
        }

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
