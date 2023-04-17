using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataReader
    {
        IUserProfile GetUsers(Guid userID);
        IArtistProfile GetArtistProfile(Guid artistID);
        ISong GetSong(Guid songID);
        IPlaylist GetPlaylist(Guid playlistID);
        IAlbum GetAlbum(Guid albumID);


        List<ISong> GetFavoriteSongs(Guid userID);
        List<IPlaylist> GetUserPlaylists(Guid userID);
        List<IPlayableCollection> GetFollowedCollections(Guid userID);
        List<IAlbum> GetArtistAlbums(Guid aristID);
    }
}
