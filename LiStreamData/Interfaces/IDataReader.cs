﻿using LiStreamData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamData.Interfaces
{
    public interface IDataReader
    {
        UserDto GetUserProfile(Guid userID);
        ArtistDto GetArtistProfile(Guid artistID);
        SongDto GetSong(Guid songID);
        PlaylistDto GetPlaylist(Guid playlistID);
        AlbumDto GetAlbum(Guid albumID);

        IList<SongDto> GetSongs();
        IList<ArtistDto> GetArtistProfiles();
        IList<AlbumDto> GetAlbums();
        IList<PlaylistDto> GetPlaylists();
        IList<UserDto> GetUserProfiles();

        IList<SongDto> GetFavoriteSongs(Guid userID);
        IList<PlaylistDto> GetUserPlaylists(Guid userID);
        IList<PlayableCollectionDto> GetFollowedCollections(Guid userID);
        IList<AlbumDto> GetArtistAlbums(Guid aristID);

        IList<SongDto> GetPlaylistSongs(Guid playlistID);
        IList<SongDto> GetAlbumSongs(Guid albumID);
        IList<SongDto> GetArtistSongs(Guid artistID);
        UserDto GetUserByEmail(string email);
    }
}
