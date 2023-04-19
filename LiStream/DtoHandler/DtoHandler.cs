using LiStream.Playables;
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
    public static class DtoHandler
    {
        public static PlayableCollectionDto PlayableCollectionDto(this IPlayableCollection playableCollectionDto)
        {
            var dto = new PlayableCollectionDto();
            dto.Id = playableCollectionDto.Id;

            if (playableCollectionDto is IAlbum album)
                dto.Album = toDto(album);

            if (playableCollectionDto is IPlaylist playlist)
                dto.Playlist = toDto(playlist);

            return dto;
        }

        public static IAlbum toAlbum(this AlbumDto albumDto)
        {
            var album = new Album(albumDto.Id, albumDto.Name, albumDto.ReleaseDate, null, null);

            return album;
        }

        public static IArtistProfile toArtist(this ArtistDto artistDto)
        {
            var artist = new Artist(artistDto.Id, null, null, artistDto.Bio, artistDto.DisplayName, artistDto.Email);

            return artist;
        }

        public static AlbumDto toDto(this IAlbum album)
        {
            var albumDto = new AlbumDto
            {
                Id = album.Id,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate,
                Artist = toDto(album.Artist),
                Playables = null
            };

            return albumDto;
        }

        public static ArtistDto toDto(this IArtistProfile artist)
        {
            var artistDto = new ArtistDto
            {
                Id = artist.Id,
                Albums = artist.Albums.Select(a => toDto(a)).ToList(),
                Singles = null,
                Bio = artist.Bio,
                DisplayName = artist.DisplayName,
                Email = artist.Email
            };

            return artistDto;
        }
        public static PlaylistDto toDto(this IPlaylist playlist)
        {
            var playlistDto = new PlaylistDto
            {
                Id = playlist.Id,
                Name = playlist.Name,
                CreationDate = playlist.CreationDate,
                Playables = null,
                Owner = toDto(playlist.Owner)
            };

            return playlistDto;
        }

        public static SongDto toDto(this ISong song)
        {
            var songDto = new SongDto
            {
                Id = song.Id,
                Data = song.Data,
                Name = song.Name,
                ReleaseDate = song.ReleaseDate,
                Lenght = song.Lenght,
                Features = song.Features.Select(f => toDto(f)).ToList(),
                Artist = toDto(song.Artist),
                Album = toDto(song.Album),
                PlayCount = song.PlayCount,
            };

            return songDto;
        }

        public static UserDto toDto(this IUserProfile user)
        {
            var userDto = new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Playlists = null,
                FollowedPlayableCollections = user.FollowedPlayableCollections.Select(p => PlayableCollectionDto(p)).ToList()
            };

            return userDto;
        }

        public static IPlayableCollection toPlayableCollection( this PlayableCollectionDto playableCollectionDto)
        {
            if (playableCollectionDto.Playlist is not null)
            {
                return new Playlist(playableCollectionDto.Id, playableCollectionDto.Playlist.Name, toUser(playableCollectionDto.Playlist.Owner), playableCollectionDto.Playlist.CreationDate, null);
            }

            return new Album(playableCollectionDto.Id, playableCollectionDto.Album.Name, playableCollectionDto.Album.ReleaseDate, toArtist(playableCollectionDto.Album.Artist), null);
        }


        public static IPlaylist toPlaylist(this PlaylistDto playlistDto)
        {
            throw new NotImplementedException();
        }

        public static ISong toSong(this SongDto songDto)
        {
            var song = new Song(songDto.Id, songDto.Data, songDto.Name, toArtist(songDto.Artist), toAlbum(songDto.Album), songDto.ReleaseDate, null, songDto.PlayCount, songDto.Lenght);

            return song;
        }

        public static IUserProfile toUser(this UserDto userDto)
        {
            var user = new User.User(userDto.Id, null, null, null, userDto.DisplayName, userDto.Email);

            return user;
        }
    }
}
