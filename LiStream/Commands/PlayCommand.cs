using LiStream.Commands.Interfaces;
using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Commands
{
    public class PlayCommand : ICommand
    {
        private readonly IPlayable _playable;

        public PlayCommand(IPlayable playable)
        {
            _playable = playable;
        }

        public void Execute()
        {
            _playable.Play();
        }

        public void Undo()
        {
            _playable.Pause();
        }
    }
}
