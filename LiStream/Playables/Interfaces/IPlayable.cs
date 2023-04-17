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
        Guid Id { get; }
        string Name { get; }
        DateTime ReleaseDate { get; }
        TimeSpan Lenght { get; }

        void Play();
        void Pause();
        void Restart();
    }
}
