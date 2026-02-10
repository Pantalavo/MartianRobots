namespace MartianRobots
{
    public class CommandFactory
    {
        private static readonly Dictionary<char, ICommand> _commands = new()
        {
            { 'L', new TurnLeftCommand() },
            { 'R', new TurnRightCommand() },
            { 'F', new MoveForwardCommand() }
        };

        public static ICommand GetCommand(char c)
        {
            if (!_commands.TryGetValue(c, out var command))
                throw new InvalidOperationException($"Unknown command: {c}");

            return command;
        }
    }
}
