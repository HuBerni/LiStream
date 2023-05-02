using LiStream.Commands.Interfaces;
using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Commands
{
    public class NextPlayableCommand : ICommand
    {
        private readonly IPlayableCollection _collection;

        public NextPlayableCommand(IPlayableCollection collection)
        {
            _collection = collection;
        }


        public void Execute()
        {
            _collection.Next();
        }

        public void Undo()
        {
            _collection.Previous();
        }
    }
}
