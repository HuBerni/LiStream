using LiStream.DtoHandler.Interfaces;
using LiStream.Playables;
using LiStream.Playables.Interfaces;
using LiStream.User;
using LiStream.User.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;

namespace LiStream.DtoHandler
{
    public class DtoHandler : IDtoHandler
    {
        public PlayableCollectionDto ToDto(IPlayableCollection playableCollection)
        {
            var dto = new PlayableCollectionDto();

            if (playableCollection is null)
                return dto;

            dto.Id = playableCollection.Id;

            if (playableCollection is IAlbum album)
                dto.Album = ToDto(album);

            if (playableCollection is IPlaylist playlist)
                dto.Playlist = ToDto(playlist);

            return dto;
        }

        public IAlbum ToAlbum(AlbumDto albumDto)
        {
            IList<IPlayable>? playables = albumDto.Playables?.Select(x => ToSong(x)).ToList<IPlayable>();
            IArtistProfile? artist =  albumDto.Artist is not null ? ToArtist(albumDto.Artist) : null;


            var album = new Album(albumDto.Id, albumDto.Name, albumDto.ReleaseDate, artist, playables);

            return album;
        }

        public IArtistProfile ToArtist(ArtistDto artistDto)
        {
            IList<IAlbum> album = artistDto.Albums?.Select(x => ToAlbum(x)).ToList();
            IList<IPlayable> singles = artistDto.Singles?.Select(x => ToSong(x)).ToList<IPlayable>();

            var artist = new Artist(artistDto.Id, album, singles, artistDto.Bio, artistDto.DisplayName, artistDto.Email);

            return artist;
        }

        public AlbumDto ToDto(IAlbum album)
        {
            var albumDto = new AlbumDto
            {
                Id = album.Id,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate,
                Artist = album.Artist != null ? ToDto(album.Artist) : null,
                Playables = null
            };

            return albumDto;
        }

        public ArtistDto ToDto(IArtistProfile artist)
        {
            var singles = artist.Singles?.Select(x => ToDto((ISong)x)).ToList();

            var artistDto = new ArtistDto
            {
                Id = artist.Id,
                Albums = artist.Albums?.Select(a => ToDto(a)).ToList(),
                Singles = singles,
                Bio = artist.Bio,
                DisplayName = artist.DisplayName,
                Email = artist.Email
            };

            return artistDto;
        }
        public PlaylistDto ToDto(IPlaylist playlist)
        {
            var playables = playlist.Playables?.Select(x => ToDto((ISong)x)).ToList();

            var playlistDto = new PlaylistDto
            {
                Id = playlist.Id,
                Name = playlist.Name,
                CreationDate = playlist.CreationDate,
                Playables = playables,
                Owner = playlist.Owner != null ? ToDto(playlist.Owner) : null
            };

            return playlistDto;
        }

        public SongDto ToDto(ISong song)
        {
            var songDto = new SongDto
            {
                Id = song.Id,
                Data = song.Data,
                Name = song.Name,
                ReleaseDate = song.ReleaseDate,
                Lenght = song.Lenght,
                Features = song.Features?.Select(f => ToDto(f)).ToList(),
                Artist =  song.Artist != null ? ToDto(song.Artist) : null,
                Album = song.Album != null ? ToDto(song.Album) : null,
                PlayCount = song.PlayCount,
            };

            return songDto;
        }

        public UserDto ToDto(IUserProfile user)
        {
            var userDto = new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Playlists = user.Playlists?.Select(ToDto).ToList(),
                FavoritePlayables = user is IUser iuser ? iuser.FavoritePlayables?.Select(x => ToDto((ISong)x)).ToList() : null,
                FollowedPlayableCollections = user.FollowedPlayableCollections?.Select(ToDto).ToList()
            };

            return userDto;
        }

        public IPlayableCollection ToPlayableCollection(PlayableCollectionDto playableCollectionDto)
        {
            if (playableCollectionDto.Playlist is not null)
            {
                return ToPlaylist(playableCollectionDto.Playlist);
            }

            if (playableCollectionDto.Album is not null)
            {
                return ToAlbum(playableCollectionDto.Album);
            }

            return null;
        }


        public IPlaylist ToPlaylist(PlaylistDto playlistDto)
        {
            var owner = playlistDto.Owner is not null ? ToUser(playlistDto.Owner) : null;
            var playables = playlistDto.Playables?.Select(x => ToSong(x)).ToList<IPlayable>();


            var playlist = new Playlist(playlistDto.Id, playlistDto.Name, owner, playlistDto.CreationDate, playables);

            return playlist;
        }

        public ISong ToSong(SongDto songDto)
        {
            var artist = songDto.Artist is not null ? ToArtist(songDto.Artist) : null;
            var album = songDto.Album is not null ? ToAlbum(songDto.Album) : null;

            var song = new Song(songDto.Id, songDto.Data, songDto.Name, artist, album, songDto.ReleaseDate, null, songDto.PlayCount, songDto.Lenght);

            return song;
        }

        public IUserProfile ToUser(UserDto userDto)
        {
            var favPlayables = userDto.FavoritePlayables?.Select(x => ToSong(x)).ToList<IPlayable>();
            var playlists = userDto.Playlists?.Select(x => ToPlaylist(x)).ToList();
            var followedCollections = userDto.FollowedPlayableCollections?.Select(ToPlayableCollection).ToList();

            var user = new User.User(userDto.Id, favPlayables, followedCollections, playlists, userDto.DisplayName, userDto.Email);

            return user;
        }
    }
}
