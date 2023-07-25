using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataHandler
    {
        bool DeleteAlbum(Guid albumID);
        bool DeleteArtist(Guid artistID);
        bool DeletePlayableCollectionFromUserFollowed(Guid playlistalbumID, Guid userID);
        bool DeletePlaylist(Guid playlistID);
        bool DeleteSong(Guid songID);
        bool DeleteSongFeature(Guid songID, Guid artistID);
        bool DeleteSongFromAlbum(Guid songID);
        bool DeleteSongFromPlaylist(Guid songID, Guid playlistID);
        bool DeleteSongFromUserFavorites(Guid songID, Guid userID);
        bool DeleteUser(Guid userID);
        IAlbum GetAlbum(Guid albumID);
        IList<IAlbum> GetAlbums();
        IList<IAlbum> GetAlbumsByArtist(Guid artistID);
        IArtistProfile GetArtistProfile(Guid artistID);
        IList<IArtistProfile> GetArtistProfiles();
        IList<ISong> GetUsersFavouriteSongs(Guid userID);
        IList<IPlayableCollection> GetFollowedCollections(Guid userID);
        IList<IPlayableCollection> GetPlayableCollections();
        IPlaylist GetPlaylist(Guid playlistID);
        IList<IPlaylist> GetPlaylists();
        IArtistProfile GetSimilar(IArtistProfile artist);
        IPlayableCollection GetSimilar(IPlayableCollection collection);
        ISong GetSimilar(ISong song);
        IList<IArtistProfile> GetSimilarList(IArtistProfile artist);
        IList<IPlayableCollection> GetSimilarList(IPlayableCollection collection);
        IList<ISong> GetSimilarList(ISong song);
        ISong GetSong(Guid songID);
        IList<ISong> GetSongs();
        IList<IPlaylist> GetPlaylistsByUser(Guid userID);
        IUserProfile GetUserProfile(Guid userID);
        IList<ISong> GetSongsByPlaylist(Guid playlistID);
        IList<ISong> GetSongsByAlbum(Guid albumID);
        IList<ISong> GetSongsByArtist(Guid artistID);
        IList<IUserProfile> GetUserProfiles();
        IUserProfile GetUserByEmail(string email);
        bool CreateAlbum(AlbumDto album);
        bool CreateArtist(ArtistDto artist);
        bool InsertPlayableCollectionToUserFollowed(Guid playlistalbumID, Guid userID);
        bool CreatePlaylist(PlaylistDto playlist);
        bool CreateSong(SongDto song);
        bool InsertSongFeature(Guid songID, Guid artistID);
        bool InsertSongToAlbum(Guid songID, Guid albumID);
        bool InsertSongToPlaylist(Guid songID, Guid playlistID, Guid userID);
        bool InsertSongToUserFavorites(Guid songID, Guid userID);
        bool CreateUser(UserDto user);
        bool UpdateAlbum(AlbumDto album);
        bool UpdateArtist(ArtistDto artist);
        bool UpdatePlaylist(PlaylistDto playlist);
        bool UpdateSong(SongDto song);
        bool UpdateUserProfile(UserDto user);
    }
}