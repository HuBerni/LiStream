using LiStream.Commands.Interfaces;
using LiStream.Playables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Commands
{
    public class PlayPauseCommand : ICommand
    {
        private readonly IPlayable _playable;

        public PlayPauseCommand(IPlayable playable)
        {
            _playable = playable;
        }

        public void Execute()
        {
            if (_playable.IsPlaying)
                _playable.Pause();
            else
                _playable.Play();
        }

        public void Undo()
        {
            Execute();
        }
    }
}
