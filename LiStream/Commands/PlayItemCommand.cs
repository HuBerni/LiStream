using LiStream.Commands.Interfaces;
using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Commands
{
    public class PlayItemCommand : ICommand
    {
        private readonly IPlayableCollection _collection;
        private int _previousIndex;
        private int _index;

        public PlayItemCommand(IPlayableCollection collection, int index)
        {
            _collection = collection;
            _previousIndex = _collection.CurrentPlayableIndex;
            _index = index;
        }

        public void Execute()
        {
            _collection.PlayItem(_index);
        }

        public void Undo()
        {
            _collection.PlayItem(_previousIndex);
        }
    }
}
