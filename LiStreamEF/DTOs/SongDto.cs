using LiStreamEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamEF.DTO
{
    public class SongDto
    {
        public Guid Id { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public ArtistDto Artist { get; set; }
        public AlbumDto Album { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ArtistDto> Features { get; set; }
        public long PlayCount { get; set; }
        public TimeSpan Lenght { get; set; }

        public LiStream.Playables.Song ToSong()
        {
            return new LiStream.Playables.Song(Id, Data, Name, Artist.ToArtist(), Album.ToAlbum(), ReleaseDate, null, PlayCount, Lenght);
        }
    }

    public static class SongDtoExtension
    {
        public static SongDto ToSongDto(this Song song)
        {
            return new SongDto()
            {
                Id = song.SongId,
                Data = song.Data,
                Name = song.Title,
                Artist = song.Artist.ToArtistDto(),
                Album = song.Album.ToAlbumDto(),
                ReleaseDate = song.ReleaseDate,
                Features = song.Artists.Select(x => x.ToArtistDto()).ToList(),
                PlayCount = song.PlayCount,
                Lenght = new TimeSpan(0, 0, song.Lenght)
            };
        }
    }
}
