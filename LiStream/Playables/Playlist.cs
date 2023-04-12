using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    internal class Playlist : IPlaylist
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public IUser Owner { get; private set; }

        public DateTime CreationDate { get; private set; }

        public List<IPlayable>? Playables { get; private set; }

        public void AddSong(ISong song)
        {
            throw new NotImplementedException();
        }

        public IPlayableCollection getSimilar()
        {
            throw new NotImplementedException();
        }

        public IPlayableCollection getSimilarList()
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
