using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataHandler
    {
        IAlbum GetAlbum(Guid id);
        IArtistProfile GetArtistProfile(Guid id);
        IPlaylist GetPlaylist(Guid id);
        ISong GetSong(Guid id);
        IUserProfile GetUserProfile(Guid id);
    }
}