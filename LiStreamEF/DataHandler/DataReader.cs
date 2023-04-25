using LiStreamData.DTO;
using LiStreamData.Interfaces;
using LiStreamEF.DTO;
using LiStreamEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamEF
{
    public class DataReader : IDataReader
    {
        private readonly LiStreamContext _context;

        public DataReader(LiStreamContext context)
        {
            _context = context;
        }

        public AlbumDto GetAlbum(Guid albumID)
        {
            var album = _context.Albums
                .Include(a => a.ArtistNavigation)
                .Include(s => s.Songs)
                .FirstOrDefault(a => a.AlbumId.Equals(albumID));

            return album.ToAlbumDto(true, true);
        }

        public IList<AlbumDto> GetAlbums()
        {
            var albums = _context.Albums
                .Include(a => a.ArtistNavigation)
                .Include(s => s.Songs)
                .ToList();

            return albums.ToAlbumDto(true, true);
        }

        public IList<AlbumDto> GetArtistAlbums(Guid artistID)
        {
            var albums = _context.Albums
                .Include(a => a.ArtistNavigation)
                .Include(s => s.Songs)
                .Where(a => a.Artist.Equals(artistID)).ToList();

            return albums.Select(x => x.ToAlbumDto(true, true)).ToList();
        }

        public ArtistDto GetArtistProfile(Guid artistID)
        {
            var artist = _context.Artists
                .Include(a => a.Albums)
                .Include(s => s.SongsNavigation)
                .FirstOrDefault(x => x.ArtistId.Equals(artistID));

            return artist.ToArtistDto(true, true);
        }

        public IList<ArtistDto> GetArtistProfiles()
        {
            var artists = _context.Artists
                .Include(a => a.Albums)
                .Include(s => s.SongsNavigation)
                .ToList();

            return artists.ToArtistDto(true, true);
        }

        public IList<SongDto> GetFavoriteSongs(Guid userID)
        {
            var favSongs = _context.UserFavoriteSongs
                .Include(x => x.Song)
                .ThenInclude(x => x.Album)
                .Include(x => x.Song.Artist)
                .Where(u => u.UserId.Equals(userID)).ToList();

            return favSongs.Select(x => x.Song.ToSongDto(true, true)).ToList();
        }

        public IList<PlayableCollectionDto> GetFollowedCollections(Guid userID)
        {
            var followedCollections = _context.UserFollowedPlayableCollections
                .Include(x => x.User)
                .Include(x => x.Playlist)
                .Include(x => x.Playlist.PlaylistItems)
                .ThenInclude(x => x.Song)
                .ThenInclude(x => x.Album)
                .Include(x => x.Album)
                .ThenInclude(x => x.Songs)
                .Where(u => u.UserId.Equals(userID)).ToList();

            return followedCollections.ToPlayableCollectionDto(true, true);
        }

        public PlaylistDto GetPlaylist(Guid playlistID)
        {
            var playlist = _context.Playlists
                .Include(x => x.OwnerNavigation)
                .Include(x => x.PlaylistItems)
                .ThenInclude(x => x.Song)
                .FirstOrDefault(p => p.PlaylistId.Equals(playlistID));
            
            return playlist.ToPlaylistDto(true, true);
        }

        public IList<PlaylistDto> GetPlaylists()
        {
            var playlists = _context.Playlists
                .Include(x => x.OwnerNavigation)
                .Include(x => x.PlaylistItems)
                .ThenInclude(x => x.Song)
                .ToList();

            return playlists.ToPlaylistDto(true, true);
        }

        public SongDto GetSong(Guid songID)
        {
            var song = _context.Songs
                .Include(x => x.Artist)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .FirstOrDefault(s => s.SongId.Equals(songID));

            return song.ToSongDto(true, true);
        }

        public IList<SongDto> GetSongs()
        {
            var songs = _context.Songs
                .Include(x => x.Artist)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .ToList();

            return songs.ToSongDto(true, true);
        }

        public IList<PlaylistDto> GetUserPlaylists(Guid userID)
        {
            var playlists = _context.Playlists
                .Include(x => x.OwnerNavigation)
                .Include(x => x.PlaylistItems)
                .ThenInclude(x => x.Song)
                .Where(p => p.Owner.Equals(userID)).ToList();

            return playlists.Select(x => x.ToPlaylistDto(true, true)).ToList();
        }

        public UserDto GetUserProfile(Guid userID)
        {
            var user = _context.Users
                .Include(x => x.UserFavoriteSongs)
                .ThenInclude(x => x.Song)
                .Include(x => x.UserFollowedPlayableCollections)
                .Include(x => x.Playlists)
                .ThenInclude(x => x.PlaylistItems)
                .ThenInclude(x => x.Song)
                .FirstOrDefault(u => u.UserId.Equals(userID));

            return user.ToUserDto(true, true, true);
        }
    }
}
