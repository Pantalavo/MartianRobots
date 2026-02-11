namespace MartianRobots.Tests
{
    public class CommandFactoryTests
    {
        [Fact]
        public void LReturnsTurnLeftCommand()
        {
            var command = CommandFactory.GetCommand('L');

            Assert.IsType<TurnLeftCommand>(command);
        }

        [Fact]
        public void RReturnsTurnRightCommand()
        {
            var command = CommandFactory.GetCommand('R');

            Assert.IsType<TurnRightCommand>(command);
        }

        [Fact]
        public void FReturnsMoveForwardCommand()
        {
            var command = CommandFactory.GetCommand('F');

            Assert.IsType<MoveForwardCommand>(command);
        }

        [Fact]
        public void InvalidCharacterThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => CommandFactory.GetCommand('J'));
        }

        [Fact]
        public void AddCommandAddsNewCommand()
        {
            var customCommand = new TurnLeftCommand();
            CommandFactory.AddCommand('X', customCommand);

            var result = CommandFactory.GetCommand('X');

            Assert.Same(customCommand, result);
        }
    }
}
