using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User
{
    public class ArtistUser : Artist, IArtistUser
    {
        public void AddAlbum(List<ISong> songs)
        {
            throw new NotImplementedException();
        }

        public void AddSingle(ISong song)
        {
            throw new NotImplementedException();
        }

        public void UpldateBio(string bio)
        {
            throw new NotImplementedException();
        }
    }
}
