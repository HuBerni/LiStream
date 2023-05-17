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
        private readonly IList<IPlayable> _playables;

        public PreviousPlayableCommand(IList<IPlayable> playables)
        {
            _playables = playables;
        }

        public void Execute()
        {
            var invoker = new Invoker();
            int index = _playables.ToList().FindIndex(x => x.IsPlaying);

            if (index <= 0 || index == -1)
                return;

            invoker.SetCommand(new PauseCommand(_playables[index]));
            invoker.Execute();

            invoker.SetCommand(new PlayCommand(_playables[index - 1]));
            invoker.Execute();
        }

        public void Undo()
        {
            var invoker = new Invoker();
            int index = _playables.ToList().FindIndex(x => x.IsPlaying);

            if (index >= _playables.Count - 2 || index == -1)
                return;

            invoker.SetCommand(new PauseCommand(_playables[index]));
            invoker.Execute();

            invoker.SetCommand(new PlayCommand(_playables[index + 1]));
            invoker.Execute();
        }
    }
}
