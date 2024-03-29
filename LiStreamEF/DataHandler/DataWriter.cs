﻿using LiStreamData.DTO;
using LiStreamData.Interfaces;
using LiStreamEF.Models;
using Microsoft.EntityFrameworkCore;

namespace LiStreamEF
{
    public class DataWriter : IDataWriter
    {
        private readonly LiStreamContext _context;

        public DataWriter(LiStreamContext context)
        {
            _context = context;
        }
        public bool DeleteAlbum(Guid albumID)
        {
            try
            {
                var songs = _context.Songs.Where(s => s.AlbumId == albumID);
                var author = _context.Albums.FirstOrDefault(a => a.AlbumId ==  albumID);

                _context.RemoveRange(songs);
                _context.Albums.Remove(author);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteArtist(Guid artistID)
        {
            try
            {
                var artist = _context.Artists.FirstOrDefault(a => a.ArtistId == artistID);

                _context.Artists.Remove(artist);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeletePlayableCollectionFromUserFollowed(Guid playlistalbumID, Guid userID)
        {
            try
            {
                var favCollection = _context.UserFollowedPlayableCollections
                                    .FirstOrDefault(f => f.UserId == userID && (f.PlaylistId == playlistalbumID || f.AlbumId == playlistalbumID));

                _context.UserFollowedPlayableCollections.Remove(favCollection);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeletePlaylist(Guid playlistID)
        {
            try
            {
                var playlistItems = _context.PlaylistItems.Where(p => p.PlaylistId == playlistID);
                var playlist = _context.Playlists.FirstOrDefault(p => p.PlaylistId == playlistID);

                _context.PlaylistItems.RemoveRange(playlistItems);
                _context.Playlists.Remove(playlist);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }



        public bool DeleteSong(Guid songID)
        {
            try
            {
                var songs = _context.Songs.FirstOrDefault(s => s.SongId == songID);

                if (songs == null) 
                    return false;

                _context.Songs.Remove(songs);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteSongFeature(Guid songID, Guid artistID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSongFromAlbum(Guid songID)
        {
            try
            {
                var song = _context.Songs.FirstOrDefault(s => s.SongId == songID);
                song.AlbumId = null;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteSongFromPlaylist(Guid songID, Guid playlistID)
        {
            try
            {
                var playlistItem = _context.PlaylistItems.FirstOrDefault(p => p.SongId == songID && p.PlaylistId == playlistID);

                _context.PlaylistItems.Remove(playlistItem);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteSongFromUserFavorites(Guid songID, Guid userID)
        {
            try
            {
                var favSong = _context.UserFavoriteSongs.FirstOrDefault(f => f.SongId == songID && f.UserId == userID);

                _context.UserFavoriteSongs.Remove(favSong);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteUser(Guid userID)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == userID);

                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CreateAlbum(AlbumDto album)
        {
            try
            {
                var al = new Album
                {
                    AlbumId = Guid.NewGuid(),
                    Artist = album.Artist.Id,
                    Name = album.Name,
                    ReleaseDate = album.ReleaseDate,
                };

                _context.Albums.Add(al);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CreateArtist(ArtistDto artist)
        {
            try
            {
                var ar = new Models.Artist
                {
                    ArtistId = Guid.NewGuid(),
                    Name = artist.DisplayName,
                    Email = artist.Email,
                    Bio = artist.Bio,
                };

                _context.Artists.Add(ar);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool InsertPlayableCollectionToUserFollowed(Guid playlistalbumID, Guid userID)
        {
            try
            {
                bool isPlaylist = _context.Playlists.Any(x => x.Equals(playlistalbumID));

                var followed = new UserFollowedPlayableCollection
                {
                    FavoriteId = Guid.NewGuid(),
                    UserId = userID,
                    AlbumId = playlistalbumID,
                    PlaylistId = playlistalbumID,
                };

                switch (isPlaylist)
                {
                    case true:
                        followed.AlbumId = null;
                        break;
                    case false:
                        followed.PlaylistId = null;
                        break;
                    default:
                        throw new Exception();
                }

                _context.UserFollowedPlayableCollections.Add(followed);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CreatePlaylist(PlaylistDto playlist)
        {
            try
            {
                var pl = new Playlist
                {
                    PlaylistId= Guid.NewGuid(),
                    Name = playlist.Name,
                    Owner = playlist.Owner.Id,
                    CreationDate = DateTime.Now,
                };

                _context.Playlists.Add(pl);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CreateSong(SongDto song)
        {
            try
            {
                var s = new Song
                {
                    SongId = Guid.NewGuid(),
                    Title = song.Name,
                    Data = song.Data,
                    ReleaseDate = song.ReleaseDate,
                    Lenght = (int)song.Lenght.TotalSeconds,
                    ArtistId = song.Artist.Id,
                    AlbumId = song.Album?.Id == Guid.Empty ? null : song.Album?.Id,
                    PlayCount = 0
                };

                _context.Songs.Add(s);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool InsertSongFeature(Guid songID, Guid artistID)
        {
            throw new NotImplementedException();
        }

        public bool InsertSongToAlbum(Guid songID, Guid albumID)
        {
            try
            {
                var song = _context.Songs.FirstOrDefault(s => s.SongId == songID);
                if (song != null)
                {
                    song.AlbumId = albumID;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool InsertSongToPlaylist(Guid songID, Guid playlistID, Guid userID)
        {
            try
            {
                var playlistitem = new PlaylistItem
                {
                    SongId = songID,
                    PlaylistId = playlistID,
                    AddedBy = userID,
                    AddDate = DateTime.Now,
                };

                _context.Entry(playlistitem).State = EntityState.Detached;

                _context.PlaylistItems.Add(playlistitem);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool InsertSongToUserFavorites(Guid songID, Guid userID)
        {
            try
            {
                var favsong = new UserFavoriteSong
                {
                    SongId = songID,
                    UserId = userID,
                    AddedDate = DateTime.Now,
                };

                _context.UserFavoriteSongs.Add(favsong);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CreateUser(UserDto user)
        {
            try
            {
                var u = new Models.User
                {
                    UserId = Guid.NewGuid(),
                    Name = user.DisplayName,
                    Email = user.Email,
                };

                _context.Users.Add(u);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateAlbum(AlbumDto album)
        {
            try
            {
                var a = _context.Albums.FirstOrDefault(a => a.AlbumId.Equals(album.Id));

                a.Name = album.Name;
                a.Artist = album.Artist.Id;
                a.AlbumId = album.Id;
                a.ReleaseDate = album.ReleaseDate;

                _context.Update(a);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateArtist(ArtistDto artist)
        {
            try
            {
                var a = _context.Artists.FirstOrDefault(a => a.ArtistId.Equals(artist.Id));

                a.Name = artist.DisplayName;
                a.Email = artist.Email;
                a.Bio = artist.Bio;

                _context.Update(a);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdatePlaylist(PlaylistDto playlist)
        {
            try
            {
                var p = _context.Playlists.FirstOrDefault(p => p.PlaylistId.Equals(playlist.Id));

                p.Name = playlist.Name;
                p.Owner = playlist.Owner.Id;

                _context.Update(p);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateSong(SongDto song)
        {
            try
            {
                var s = _context.Songs.FirstOrDefault(s => s.SongId.Equals(song.Id));

                s.Title = song.Name;
                s.AlbumId = song.Album?.Id == Guid.Empty ? null : song.Album.Id;
                s.ArtistId = song.Artist.Id;
                s.ReleaseDate = song.ReleaseDate;

                _context.Update(s);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateUserProfile(UserDto user)
        {
            try
            {
                var u = _context.Users.FirstOrDefault(u => u.UserId.Equals(user.Id));

                u.Name = user.DisplayName;
                u.Email = user.Email;

                _context.Update(u);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
