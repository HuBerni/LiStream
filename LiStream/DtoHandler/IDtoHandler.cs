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
        AlbumDto ToDto(IAlbum album);
        IAlbum ToAlbum(AlbumDto albumDto);
        PlaylistDto ToDto(IPlaylist playlist);
        IPlaylist ToPlaylist(PlaylistDto playlistDto);
        ArtistDto ToDto(IArtistProfile artist);
        IArtistProfile ToArtist(ArtistDto artistDto);
        PlayableCollectionDto ToDto(IPlayable playableCollectionDto);
        IPlayableCollection ToPlayableCollection(PlayableCollectionDto playableCollectionDto);
        SongDto ToDto(ISong song);
        ISong ToSong(SongDto songDto);
        UserDto ToDto(IUserProfile user);
        IUserProfile ToUser(UserDto userDto);
    }
}
