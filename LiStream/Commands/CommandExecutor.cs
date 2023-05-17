using LiStream.Commands.Interfaces;

namespace LiStream.Commands
{
    public class CommandExecutor
    {
        private readonly Invoker _invoker = new Invoker();

        public void ExecuteCommand(ICommand command)
        {
            _invoker.SetCommand(command);
            _invoker.Execute();
        }
    }
}
