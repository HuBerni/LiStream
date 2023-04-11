using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables.Interfaces
{
    public interface IPlayableCollection : IEvaluateable<IPlayableCollection>
    {
        List<IPlayable> Playables { get; }

        void Next();
        void Previous();
        void PlayItem(IPlayable item);
    }
}
