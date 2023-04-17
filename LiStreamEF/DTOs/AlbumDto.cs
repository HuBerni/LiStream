using LiStream.Playables.Interfaces;
using LiStreamEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamEF.DTO
{
    public class AlbumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ArtistDto Artist { get; set; }
        public List<SongDto> Playables { get; set; }

        public LiStream.Playables.Album ToAlbum()
        {
            List<IPlayable> songlist = new List<IPlayable>();
            Playables.ForEach(x => songlist.Add(x.ToSong()));


            return new LiStream.Playables.Album(Id, Name, ReleaseDate, Artist.ToArtist(), songlist);
        }
    }

    public static class AlbumDtoExtension
    {
        public static AlbumDto ToAlbumDto(this Album album)
        {
            return new AlbumDto()
            {
                Id = album.AlbumId,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate,
                Artist = album.ArtistNavigation.ToArtistDto(),
                Playables = album.Songs.Select(s => s.ToSongDto()).ToList()
            };
        }
    }
}
