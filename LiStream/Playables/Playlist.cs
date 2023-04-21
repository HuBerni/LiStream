using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    public class Playlist : IPlaylist
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IUserProfile Owner { get; private set; }

        public DateTime CreationDate { get; private set; }

        public IList<IPlayable>? Playables { get; private set; }

        public Playlist(Guid id, string name, IUserProfile owner, DateTime creationDate, IList<IPlayable>? playables)
        {
            Id = id;
            this.Name = name;
            Owner = owner;
            CreationDate = creationDate;
            Playables = playables;
        }

        public void AddSong(ISong song)
        {
            throw new NotImplementedException();
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

        public void RemoveSong(ISong song)
        {
            throw new NotImplementedException();
        }
    }
}
