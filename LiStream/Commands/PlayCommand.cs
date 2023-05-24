using LiStream.Commands.Interfaces;
using LiStream.Playables.Interfaces;

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
