﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LiStreamEF.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Songs = new HashSet<Song>();
        }

        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}