using LiStream.Playables.Interfaces;
using LiStream.User;
using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;
using LiStreamEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DtoHandler
{
    public interface IDtoHandler
    {
        AlbumDto toDto(IAlbum album);
        IAlbum toAlbum(AlbumDto albumDto);
        PlaylistDto toDto(IPlaylist playlist);
        IPlaylist toPlaylist(PlaylistDto playlistDto);
        ArtistDto toDto(IArtistProfile artist);
        IArtistProfile toArtist(ArtistDto artistDto);
        PlayableCollectionDto PlayableCollectionDto(IPlayableCollection playableCollectionDto);
        IPlayableCollection toPlayableCollection(PlayableCollectionDto playableCollectionDto);
        SongDto toDto(ISong song);
        ISong toSong(SongDto songDto);
        UserDto toDto(IUserProfile user);
        IUserProfile toUser(UserDto userDto);
    }
}
