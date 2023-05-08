using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiStream.Commands.Interfaces;

namespace LiStream.Commands
{
    public class MusicPlayer : IMusicPlayer
    {
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

        private ICommand _playCommand;
        private ICommand _pauseCommand;
        private ICommand _restartCommand;
        private ICommand _nextPlayableCommand;
        private ICommand _previousPlayableCommand;

        public MusicPlayer(ICommand playCommand, ICommand pauseCommand, ICommand restartCommand, ICommand nextPlayableCommand, ICommand previousPlayableCommand)
        {
            _playCommand = playCommand;
            _pauseCommand = pauseCommand;
            _restartCommand = restartCommand;
            _nextPlayableCommand = nextPlayableCommand;
            _previousPlayableCommand = previousPlayableCommand;
        }

        public void ExecutePlay()
        {
            _playCommand.Execute();
            _commandHistory.Push(_playCommand);
        }

        public void ExecutePause()
        {
            _pauseCommand.Execute();
            _commandHistory.Push(_pauseCommand);
        }

        public void ExecuteRestart()
        {
            _restartCommand.Execute();
            _commandHistory.Push(_restartCommand);
        }

        public void ExecuteNextPlayable()
        {
            _nextPlayableCommand.Execute();
            _commandHistory.Push(_nextPlayableCommand);
        }

        public void ExecutePreviousPlayable()
        {
            _previousPlayableCommand.Execute();
            _commandHistory.Push(_previousPlayableCommand);
        }

        public void UndoLastCommand()
        {
            if (_commandHistory.Count > 0)
            {
                var lastCommand = _commandHistory.Pop();
                lastCommand.Undo();
            }
        }
    }
}
