using LiStream.Playables.Interfaces;
using LiStreamEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamEF.DTO
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public List<AlbumDto> Albums { get; set; }
        public List<SongDto> Singles { get; set; }
        public string Bio { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }

        public LiStream.User.Artist ToArtist()
        {
            List<IAlbum> albums = new List<IAlbum>();
            Albums.ForEach(x => albums.Add(x.ToAlbum()));
            
            List<IPlayable> singles = new List<IPlayable>();
            Singles.ForEach(x => singles.Add(x.ToSong()));

            return new LiStream.User.Artist(Id, albums, singles, Bio, DisplayName, Email);
        }
    }

    public static class ArtistDtoExtension
    {
        public static ArtistDto ToArtistDto(this Artist artist)
        {
            return new ArtistDto()
            {
                Id = artist.ArtistId,
                Albums = artist.Albums.Select(x => x.ToAlbumDto()).ToList(),
                Singles = artist.Songs.Select(x => x.ToSongDto()).ToList(),
                Bio = artist.Bio,
                DisplayName = artist.Name,
                Email = artist.Email
            };
        }
    }
}
