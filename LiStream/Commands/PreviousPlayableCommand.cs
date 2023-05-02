using LiStream.Commands.Interfaces;
using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Commands
{
    public class PreviousPlayableCommand : ICommand
    {
        private readonly IPlayableCollection _collection;

        public PreviousPlayableCommand(IPlayableCollection collection)
        {
            _collection = collection;
        }

        public void Execute()
        {
            _collection.Previous();
        }

        public void Undo()
        {
            _collection.Next();
        }
    }
}
