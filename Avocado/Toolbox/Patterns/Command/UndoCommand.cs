using System.Collections.Generic;

namespace Avocado.Toolbox.Patterns.Command
{
    public class UndoCommand : ICommand
    {
        private Stack<ICommand> _executedCommands = new Stack<ICommand>();
        
        public void Execute()
        {
            var command = _executedCommands.Pop();
            if (command is null) 
                return;
            
            command.Undo();
            Execute();
        }

        public void Undo()
        {
            
        }
    }
}