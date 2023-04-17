using LiStream.Playables.Interfaces;
using LiStream.User;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataWriter
    {
        bool InsertArtist(ArtistUser artist);
        bool InsertUser (IUserProfile user);
        bool InsertAlbum(IAlbum album);
        bool InsertPlaylist(IPlaylist playlist);
        bool InsertSong(ISong song);
        bool InsertSongToPlaylist(Guid songID, Guid playlistID, Guid userID);
        bool InsertSongToAlbum(Guid songID, Guid albumID);
        bool InsertSongToUserFavorites(Guid songID, Guid userID);
        bool InsertPlayableCollectionToUserFollowed(Guid playlistalbumID, Guid userID);
        bool InsertSongFeature(Guid songID, Guid artistID);

        bool UpdateArtist(IArtistProfile artist);
        bool UpdateUser(IUserProfile user);
        bool UpdateAlbum(IAlbum album);
        bool UpdatePlaylist(IPlaylist playlist);
        bool UpdateSong(ISong song);

        bool DeleteArtist(Guid artistID);
        bool DeleteUser(Guid userID);
        bool DeleteAlbum(Guid albumID);
        bool DeletePlaylist(Guid playlistID);
        bool DeleteSong(Guid songID);
        bool DeleteSongFromPlaylist(Guid songID, Guid playlistID);
        bool DeleteSongFromAlbum(Guid songID);
        bool DeleteSongFeature(Guid songID, Guid artistID);
        bool DeleteSongFromUserFavorites(Guid songID, Guid userID);
        bool DeletePlayableCollectionFromUserFollowed(Guid playlistalbumID, Guid userID);
    }
}
