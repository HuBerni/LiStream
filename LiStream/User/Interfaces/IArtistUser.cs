using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User.Interfaces
{
    public interface IArtistUser : IArtistProfile
    {
        void AddAlbum(List<ISong> songs);
        void AddSingle(ISong song);
        void UpldateBio(string bio);
    }
}
