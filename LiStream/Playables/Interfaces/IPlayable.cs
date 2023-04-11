using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables.Interfaces
{
    public interface IPlayable : IEvaluateable<IPlayable>
    {
        TimeSpan Lenght { get; }
        TimeSpan CurrentPosition { get; }

        void Play();
        void Pause();
        void Restart();
    }
}
