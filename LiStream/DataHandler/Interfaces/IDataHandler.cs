using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataHandler
    {
        IAlbum GetAlbum(Guid albumID);
        IList<IAlbum> GetArtistAlbums(Guid artistID);
        IArtistProfile GetArtistProfile(Guid artistID);
        IList<IArtistProfile> GetArtistProfiles();
        IPlaylist GetPlaylist(Guid playlistID);
        IList<IPlaylist> GetUserPlaylists(Guid userID);
        ISong GetSong(Guid songID);
        IList<ISong> GetSongs();
        IUserProfile GetUserProfile(Guid userID);
        IList<ISong> GetFavoriteSongs(Guid userID);
        IList<IPlayableCollection> GetFollowedCollections(Guid userID);
        IList<IPlayableCollection> GetPlayableCollections();

        ISong GetSimilar(ISong song);
        IList<ISong> GetSimilarList(ISong song);
        IArtistProfile GetSimilar(IArtistProfile artist);
        IList<IArtistProfile> GetSimilarList(IArtistProfile artist);
        IPlayableCollection GetSimilar(IPlayableCollection collection);
        IList<IPlayableCollection> GetSimilarList(IPlayableCollection collection);
    }
}