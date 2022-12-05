using System.Collections.Generic;
using System.Diagnostics;

namespace GG3902
{
    public class CommandList
    {
        private List<ICommand> commands;

        public CommandList()
        {
            commands = new List<ICommand>();
        }

        public void RegisterCommand(ICommand command)
        {
            Debug.WriteLine("Adding " + command.ToString());
            commands.Add(command);
        }

        public void DeregisterCommand(ICommand command)
        {
            Debug.WriteLine("Removing " + command.ToString());
            commands.Remove(command);
        }

        public void ClearCommands()
        {
            commands.Clear();
        }

        public void ExecuteCommands()
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }

        public void UndoCommands()
        {
            foreach (ICommand command in commands)
            {
                command.Undo();
            }
        }
    }
}
