using LiStream.Commands.Interfaces;
using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Commands
{
    public class RestartCommand : ICommand
    {
        private readonly IPlayable _playable;

        public RestartCommand(IPlayable playable)
        {
            _playable = playable;
        }

        public void Execute()
        {
            _playable.Restart();
        }

        public void Undo()
        {

        }
    }
}
