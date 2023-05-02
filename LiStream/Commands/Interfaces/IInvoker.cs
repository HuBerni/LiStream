using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Commands.Interfaces
{
    public interface IInvoker
    {
        public void ExecuteCommand(ICommand command);
        public void UndoLastCommand();
    }
}
