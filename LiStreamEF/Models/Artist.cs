﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LiStreamEF.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            SongsNavigation = new HashSet<Song>();
            Songs = new HashSet<Song>();
        }

        public Guid ArtistId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> SongsNavigation { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}