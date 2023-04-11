using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiStream.Interfaces;

namespace LiStream.Playables.Interfaces
{
    public interface IPlayable : IEvaluateable<IPlayable>
    {
        TimeSpan Lenght { get; }

        void Play();
        void Pause();
        void Restart();
    }
}
