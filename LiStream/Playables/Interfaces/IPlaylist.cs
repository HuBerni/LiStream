using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables.Interfaces
{
    public interface IPlaylist : IPlayableCollection
    {
        IUserProfile Owner { get; }
        DateTime CreationDate { get; }

        void AddSong(ISong song);
        void RemoveSong(ISong song);
    }
}
