﻿using LiStreamData.DTO;

namespace LiStreamData.Interfaces
{
    public interface IDataWriter
    {
        bool CreateArtist(ArtistDto artist);
        bool CreateUser (UserDto user);
        bool CreateAlbum(AlbumDto album);
        bool CreatePlaylist(PlaylistDto playlist);
        bool CreateSong(SongDto song);
        bool InsertSongToPlaylist(Guid songID, Guid playlistID, Guid userID);
        bool InsertSongToAlbum(Guid songID, Guid albumID);
        bool InsertSongToUserFavorites(Guid songID, Guid userID);
        bool InsertPlayableCollectionToUserFollowed(Guid playlistalbumID, Guid userID);
        bool InsertSongFeature(Guid songID, Guid artistID);

        bool UpdateArtist(ArtistDto artist);
        bool UpdateUserProfile(UserDto user);
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
