using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    public class Album : IAlbum
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public IArtistProfile? Artist { get; private set; }

        public IList<IPlayable>? Playables { get; private set; }

        public Album(Guid id, string name, DateTime releaseDate, IArtistProfile artist, IList<IPlayable>? playables)
        {
            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
            Artist = artist;
            Playables = playables;
        }

        public IPlayableCollection getSimilar()
        {
            throw new NotImplementedException();
        }

        public IList<IPlayableCollection> getSimilarList()
        {
            throw new NotImplementedException();
        }

        public void Next()
        {
            throw new NotImplementedException();
        }

        public void PlayItem(IPlayable item)
        {
            throw new NotImplementedException();
        }

        public void Previous()
        {
            throw new NotImplementedException();
        }
    }
}
