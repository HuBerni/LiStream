using LiStream.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables.Interfaces
{
    public interface IPlaylist : IPlayableCollection
    {
        Guid Id { get; }
        string Name { get; }
        IUser Owner { get; }
        DateTime CreationDate { get; }

        void AddSong(ISong song);
        void RemoveSong(ISong song);
    }
}
