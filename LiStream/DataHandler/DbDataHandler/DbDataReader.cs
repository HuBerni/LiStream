using LiStream.DataHandler.Interfaces;
using LiStream.DtoHandler;
using LiStream.Playables;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;
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
    public class DbDataReader : IDataReader
    {
        private readonly LiStreamContext _context;

        public DbDataReader(LiStreamContext context)
        {
            _context = context;
        }

        public IAlbum GetAlbum(Guid albumID)
        {
            var album = _context.Albums
                .Include(a => a.ArtistNavigation)
                .Include(s => s.Songs)
                .FirstOrDefault(a => a.AlbumId.Equals(albumID));

            var artist = album.ArtistNavigation.ToArtistDto();
            var songs = album.Songs.Select(x => x.ToSongDto()).ToList();

            return album.ToAlbumDto(artist).toAlbum();
        }

        public List<IAlbum> GetArtistAlbums(Guid artistID)
        {
            var albums = _context.Albums
                .Where(a => a.Artist.Equals(artistID)).ToList();

            var albumList = new List<IAlbum>();
            albums.ForEach(a => albumList.Add(GetAlbum(a.AlbumId)));

            return albumList;
        }

        public IArtistProfile GetArtistProfile(Guid artistID)
        {
            var artist = _context.Artists
                .Include(a => a.Albums)
                .Include(s => s.Songs.Where(x => x.AlbumId != null))
                .FirstOrDefault(x => x.ArtistId.Equals(artistID));

            return artist.ToArtistDto().toArtist();
        }

        public List<ISong> GetFavoriteSongs(Guid userID)
        {
            var favSongs = _context.UserFavoriteSongs.Where(u => u.User.Equals(userID)).ToList();

            var favSongsList = new List<ISong>();
            favSongs.ForEach(f => favSongsList.Add(GetSong(userID)));

            return favSongsList;
        }

        public List<IPlayableCollection> GetFollowedCollections(Guid userID)
        {
            throw new NotImplementedException();
        }

        public IPlaylist GetPlaylist(Guid playlistID)
        {
            var playlist = _context.Playlists
                .Include(x => x.OwnerNavigation)
                .Include(x => x.PlaylistItems)
                .FirstOrDefault(p => p.PlaylistId.Equals(playlistID));
            
            return playlist.ToPlaylistDto().toPlaylist();
        }

        public ISong GetSong(Guid songID)
        {
            var song = _context.Songs
                .Include(x => x.Artist)
                .Include(x => x.Artists)
                .Include(x => x.Album)
                .FirstOrDefault(s => s.SongId.Equals(songID));

            var artistDto = song.Artist.ToArtistDto();
            var albumDto = song.Album.ToAlbumDto();


            return song.ToSongDto(artistDto, albumDto).toSong();
        }

        public List<IPlaylist> GetUserPlaylists(Guid userID)
        {
            var playlists = _context.Playlists.Where(p => p.Owner.Equals(userID)).ToList();

            var playlistList = new List<IPlaylist>();
            playlists.ForEach(x => playlistList.Add(GetPlaylist(userID)));

            return playlistList;
        }

        public IUserProfile GetUsers(Guid userID)
        {
            var user = _context.Users
                .Include(x => x.UserFavoriteSongs)
                .Include(x => x.UserFollowedPlayableCollections)
                .Include(x => x.Playlists)
                .ThenInclude(x => x.PlaylistItems)
                .FirstOrDefault(u => u.UserId.Equals(userID));
            
            return user.ToUserDto().toUser();
        }
    }
}
