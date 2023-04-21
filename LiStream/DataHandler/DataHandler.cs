using LiStream.DataHandler.Interfaces;
using LiStream.DtoHandler;
using LiStream.Playables.Interfaces;
using LiStream.User;
using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;
using LiStreamData.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler
{
    public class DataHandler : IDataHandler, IDataWriter
    {
        private readonly IDataWriter _writer;
        private readonly IDataReader _reader;
        private readonly IDtoHandler _dtoHandler;

        public DataHandler(IDataWriter writer, IDataReader reader, IDtoHandler dtoHandler)
        {
            _writer = writer;
            _reader = reader;
            _dtoHandler = dtoHandler;
        }

        public IAlbum GetAlbum(Guid id)
        {
            return _dtoHandler.ToAlbum(_reader.GetAlbum(id));
        }

        public IArtistProfile GetArtistProfile(Guid id)
        {
            return _dtoHandler.ToArtist(_reader.GetArtistProfile(id));
        }

        public IPlaylist GetPlaylist(Guid id)
        {
            return _dtoHandler.ToPlaylist(_reader.GetPlaylist(id));
        }

        public IUserProfile GetUserProfile(Guid id)
        {
            return _dtoHandler.ToUser(_reader.GetUserProfile(id));
        }

        public ISong GetSong(Guid id)
        {
            return _dtoHandler.ToSong(_reader.GetSong(id));
        }

        public bool InsertArtist(ArtistDto artist)
        {
            return _writer.InsertArtist(artist);
        }

        public bool InsertUser(UserDto user)
        {
            return _writer.InsertUser(user);
        }

        public bool InsertAlbum(AlbumDto album)
        {
            return _writer.InsertAlbum(album);
        }

        public bool InsertPlaylist(PlaylistDto playlist)
        {
            return _writer.InsertPlaylist(playlist);
        }

        public bool InsertSong(SongDto song)
        {
            return _writer.InsertSong(song);
        }

        public bool InsertSongToPlaylist(Guid songID, Guid playlistID, Guid userID)
        {
            return _writer.InsertSongToPlaylist(songID, playlistID, userID);
        }

        public bool InsertSongToAlbum(Guid songID, Guid albumID)
        {
            return _writer.InsertSongToAlbum(songID, albumID);
        }

        public bool InsertSongToUserFavorites(Guid songID, Guid userID)
        {
            return _writer.InsertSongToUserFavorites(songID, userID);
        }

        public bool InsertPlayableCollectionToUserFollowed(Guid playlistalbumID, Guid userID)
        {
            return _writer.InsertPlayableCollectionToUserFollowed(playlistalbumID, userID);
        }

        public bool InsertSongFeature(Guid songID, Guid artistID)
        {
            return _writer.InsertSongFeature(songID, artistID);
        }

        public bool UpdateArtist(ArtistDto artist)
        {
            return _writer.UpdateArtist(artist);
        }

        public bool UpdateUserProfile(UserDto user)
        {
            return _writer.UpdateUserProfile(user);
        }

        public bool UpdateAlbum(AlbumDto album)
        {
            return _writer.UpdateAlbum(album);
        }

        public bool UpdatePlaylist(PlaylistDto playlist)
        {
            return _writer.UpdatePlaylist(playlist);
        }

        public bool UpdateSong(SongDto song)
        {
            return _writer.UpdateSong(song);
        }

        public bool DeleteArtist(Guid artistID)
        {
            return _writer.DeleteArtist(artistID);
        }

        public bool DeleteUser(Guid userID)
        {
            return _writer.DeleteUser(userID);
        }

        public bool DeleteAlbum(Guid albumID)
        {
            return _writer.DeleteAlbum(albumID);
        }

        public bool DeletePlaylist(Guid playlistID)
        {
            return _writer.DeletePlaylist(playlistID);
        }

        public bool DeleteSong(Guid songID)
        {
            return _writer.DeleteSong(songID);
        }

        public bool DeleteSongFromPlaylist(Guid songID, Guid playlistID)
        {
            return _writer.DeleteSongFromPlaylist(songID, playlistID);
        }

        public bool DeleteSongFromAlbum(Guid songID)
        {
            return _writer.DeleteSongFromAlbum(songID);
        }

        public bool DeleteSongFeature(Guid songID, Guid artistID)
        {
            return _writer.DeleteSongFeature(songID, artistID);
        }

        public bool DeleteSongFromUserFavorites(Guid songID, Guid userID)
        {
            return _writer.DeleteSongFromUserFavorites(songID, userID);
        }

        public bool DeletePlayableCollectionFromUserFollowed(Guid playlistalbumID, Guid userID)
        {
            return _writer.DeletePlayableCollectionFromUserFollowed(playlistalbumID, userID);
        }
    }
}
