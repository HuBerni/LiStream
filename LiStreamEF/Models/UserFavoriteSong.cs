﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LiStreamEF.Models
{
    public partial class UserFavoriteSong
    {
        public Guid SongId { get; set; }
        public Guid UserId { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual Song Song { get; set; }
        public virtual User User { get; set; }
    }
}