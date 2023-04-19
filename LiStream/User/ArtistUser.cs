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
        public ArtistUser(Guid id, List<IAlbum> albums, List<IPlayable> singles, string bio, string displayName, string email) : base(id, albums, singles, bio, displayName, email)
        {

        }

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
