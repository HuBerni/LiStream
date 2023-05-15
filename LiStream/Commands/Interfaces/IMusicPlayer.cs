namespace LiStream.Commands.Interfaces
{
    public interface IMusicPlayer
    {
        void SetPlayCommand(ICommand playCommand);
        void SetPauseCommand(ICommand pauseCommand);
        void SetRestartCommand(ICommand restartCommand);
        void SetNextPlayableCommand(ICommand nextPlayableCommand);
        void SetPreviousPlayableCommand(ICommand previousPlayableCommand);
        void ExecuteNextPlayable();
        void ExecutePause();
        void ExecutePlay();
        void ExecutePreviousPlayable();
        void ExecuteRestart();
        void UndoLastCommand();
    }
}