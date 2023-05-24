using LiStream.Commands.Interfaces;
using LiStream.Playables.Interfaces;

namespace LiStream.Commands
{
    public class NextPlayableCommand : ICommand
    {
        private readonly IList<IPlayable> _playables;

        public NextPlayableCommand(IList<IPlayable> playables)
        {
            _playables = playables;
        }


        public void Execute()
        {
            var invoker = new Invoker();
            int index = _playables.ToList().FindIndex(x => x.IsPlaying);

            if (index >= _playables.Count - 1 || index == -1)
                return;

            invoker.SetCommand(new PauseCommand(_playables[index++]));
            invoker.Execute();

            invoker.SetCommand(new PlayCommand(_playables[index]));
            invoker.Execute();
        }

        public void Undo()
        {
            var invoker = new Invoker();
            int index = _playables.ToList().FindIndex(x => x.IsPlaying);

            if (index <= 0 || index == -1)
                return;

            invoker.SetCommand(new PauseCommand(_playables[index--]));
            invoker.Execute();

            invoker.SetCommand(new PlayCommand(_playables[index]));
            invoker.Execute();
        }
    }
}
