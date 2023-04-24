using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Playables.Interfaces
{
    public interface IPlayableCollection
    {
        Guid Id { get; }
        string Name { get; }
        IList<IPlayable>? Playables { get; }

        void Next();
        void Previous();
        void PlayItem(IPlayable item);
    }
}
