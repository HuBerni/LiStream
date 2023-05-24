using LiStream.Commands.Interfaces;

namespace LiStream.Commands
{
    public class Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            _command.Execute();
        }

        public void Undo()
        {
            _command.Undo();
        }
    }
}
