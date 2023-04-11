using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    internal class Album : IAlbum
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public IArtistProfile Artist { get; private set; }

        public List<IPlayable> Playables { get; private set; }

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
    }
}
