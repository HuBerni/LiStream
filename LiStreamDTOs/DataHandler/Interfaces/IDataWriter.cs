using LiStream.Playables.Interfaces;
using LiStream.User;
using LiStream.User.Interfaces.Profile;
using ListreamDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataWriter
    {
        bool InsertArtist(ArtistDto artist);
        bool InsertUser (UserDto user);
        bool InsertAlbum(AlbumDto album);
        bool InsertPlaylist(PlaylistDto playlist);
        bool InsertSong(SongDto song);
        bool InsertSongToPlaylist(Guid songID, Guid playlistID, Guid userID);
        bool InsertSongToAlbum(Guid songID, Guid albumID);
        bool InsertSongToUserFavorites(Guid songID, Guid userID);
        bool InsertPlayableCollectionToUserFollowed(Guid playlistalbumID, Guid userID);
        bool InsertSongFeature(Guid songID, Guid artistID);

        bool UpdateArtist(ArtistDto artist);
        bool UpdateUser(UserDto user);
        bool UpdateAlbum(AlbumDto album);
        bool UpdatePlaylist(PlaylistDto playlist);
        bool UpdateSong(SongDto song);

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
