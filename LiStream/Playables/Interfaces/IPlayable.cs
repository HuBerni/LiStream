﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables.Interfaces
{
    public interface IPlayable
    {
        Guid Id { get; }
        string Name { get; }
        DateTime ReleaseDate { get; }
        TimeSpan Lenght { get; }
        bool IsPlaying { get; }
        TimeSpan CurrentPosition { get; }

        void Play();
        void Pause();
        void Restart();
    }
}
