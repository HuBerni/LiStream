using LiStream.DataHandler.Interfaces;
using LiStream.DtoHandler;
using LiStream.Evaluator.Interfaces;
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
    public class DataHandler : IDataHandler
    {
        private readonly IDataWriter _writer;
        private readonly IDataReader _reader;
        private readonly IDtoHandler _dtoHandler;
        private readonly IEvaluator _evaluator;

        public DataHandler(IDataWriter writer, IDataReader reader, IDtoHandler dtoHandler, IEvaluator evaluator)
        {
            _writer = writer;
            _reader = reader;
            _dtoHandler = dtoHandler;
            _evaluator = evaluator;
        }

        public IAlbum GetAlbum(Guid albumID)
        {
            return _dtoHandler.ToAlbum(_reader.GetAlbum(albumID));
        }

        public IArtistProfile GetArtistProfile(Guid artistID)
        {
            return _dtoHandler.ToArtist(_reader.GetArtistProfile(artistID));
        }

        public IList<IArtistProfile> GetArtistProfiles()
        {
            return _reader.GetArtistProfiles().Select(x => _dtoHandler.ToArtist(x)).ToList();
        }

        public IPlaylist GetPlaylist(Guid playlistID)
        {
            return _dtoHandler.ToPlaylist(_reader.GetPlaylist(playlistID));
        }

        public IUserProfile GetUserProfile(Guid userID)
        {
            return _dtoHandler.ToUser(_reader.GetUserProfile(userID));
        }

        public ISong GetSong(Guid songID)
        {
            return _dtoHandler.ToSong(_reader.GetSong(songID));
        }

        public IList<ISong> GetSongs()
        {
            return _reader.GetSongs().Select(x => _dtoHandler.ToSong(x)).ToList();
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

        public IList<IAlbum> GetArtistAlbums(Guid artistID)
        {
            return _reader.GetArtistAlbums(artistID).Select(x => _dtoHandler.ToAlbum(x)).ToList();
        }

        public IList<IPlaylist> GetUserPlaylists(Guid userID)
        {
            return _reader.GetUserPlaylists(userID).Select(x => _dtoHandler.ToPlaylist(x)).ToList();
        }

        public IList<ISong> GetFavoriteSongs(Guid userID)
        {
            return _reader.GetFavoriteSongs(userID).Select(x => _dtoHandler.ToSong(x)).ToList();
        }

        public IList<IPlayableCollection> GetFollowedCollections(Guid userID)
        {
            return _reader.GetFollowedCollections(userID).Select(x => _dtoHandler.ToPlayableCollection(x)).ToList();
        }
        public IList<IAlbum> GetAlbums()
        {
            return _reader.GetAlbums().Select(x => _dtoHandler.ToAlbum(x)).ToList();
        }

        public IList<IPlaylist> GetPlaylists()
        {
            return _reader.GetPlaylists().Select(x => _dtoHandler.ToPlaylist(x)).ToList();
        }

        public IList<IPlayableCollection> GetPlayableCollections()
        {
            throw new NotImplementedException();
        }

        public ISong GetSimilar(ISong song)
        {
            return _evaluator.GetSimilar(song, GetSongs());
        }

        public IList<ISong> GetSimilarList(ISong song)
        {
            return _evaluator.GetSimilarList(song, GetSongs());
        }

        public IArtistProfile GetSimilar(IArtistProfile artist)
        {
            return _evaluator.GetSimilar(artist, GetArtistProfiles());
        }

        public IList<IArtistProfile> GetSimilarList(IArtistProfile artist)
        {
            return _evaluator.GetSimilarList(artist, GetArtistProfiles());
        }

        public IPlayableCollection GetSimilar(IPlayableCollection collection)
        {
            return _evaluator.GetSimilar(collection, GetPlayableCollections());
        }

        public IList<IPlayableCollection> GetSimilarList(IPlayableCollection collection)
        {
            return _evaluator.GetSimilarList(collection, GetPlayableCollections());
        }
    }
}
