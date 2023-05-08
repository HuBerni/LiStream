namespace LiStream.Commands.Interfaces
{
    public interface IMusicPlayer
    {
        void ExecuteNextPlayable();
        void ExecutePause();
        void ExecutePlay();
        void ExecutePreviousPlayable();
        void ExecuteRestart();
        void UndoLastCommand();
    }
}