﻿using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables
{
    public class Song : ISong, IDisplayable
    {
        public Guid Id { get; private set; }

        public byte[] Data { get; private set; }

        public string Name { get; private set; }

        public IArtistProfile Artist { get; private set; }

        public IAlbum? Album { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public IList<IArtistProfile>? Features { get; private set; }

        public long PlayCount { get; private set; }

        public TimeSpan Lenght { get; private set; }

        public bool IsPlaying { get; private set; }

        public TimeSpan CurrentPosition { get; private set; }

        public Song(Guid id, byte[] data, string title, IArtistProfile artist, IAlbum album, DateTime releaseDate, IList<IArtistProfile> features, long playCount, TimeSpan lenght)
        {
            Id = id;
            Data = data;
            Name = title;
            Artist = artist;
            Album = album;
            ReleaseDate = releaseDate;
            Features = features;
            PlayCount = playCount;
            Lenght = lenght;
        }

        public void Pause()
        {
            IsPlaying = false;
        }

        public void Play()
        {
            IsPlaying = true;
        }

        public void Restart()
        {
            CurrentPosition = TimeSpan.Zero;
            IsPlaying = true;
        }

        public string GetDisplayableName()
        {
            return Name;
        }

        public IList<DisplayableInformation> GetAdditionalInformation()
        {
            return new List<DisplayableInformation>()
            {
                new DisplayableInformation("Title", Name),
                new DisplayableInformation("Artist", Artist.DisplayName),
                new DisplayableInformation("Album", Album?.Name ?? ""),
                new DisplayableInformation("Release Date", ReleaseDate.ToShortDateString()),
                new DisplayableInformation("Length", Lenght.ToString())
            };  
        }

        bool IDisplayable.IsPlaying()
        {
            return IsPlaying;
        }
    }
}
