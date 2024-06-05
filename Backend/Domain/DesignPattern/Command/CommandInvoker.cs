namespace Backend.Domain.DesignPattern;

public class CommandInvoker
{
    private readonly Queue<Command> _commands = new Queue<Command>();

    public void AddCommand(Command command)
    {
        _commands.Enqueue(command);
    }

    public void ExecuteCommands()
    {
        while (_commands.Count > 0)
        {
            var command = _commands.Dequeue();
            command.Execute();
        }
    }
}