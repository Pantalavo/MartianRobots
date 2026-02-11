namespace MartianRobots.Tests
{
    public class TurnLeftCommandTests
    {
        [Theory]
        [InlineData(Direction.N, Direction.W)]
        [InlineData(Direction.W, Direction.S)]
        [InlineData(Direction.S, Direction.E)]
        [InlineData(Direction.E, Direction.N)]
        public void TurnsLeftCorrectly(Direction startDirection, Direction expectedDirection)
        {
            var mars = TestFixtures.CreateMars();
            var robot = TestFixtures.CreateRobot(0, 0, startDirection);
            var command = new TurnLeftCommand();

            command.Execute(robot, mars);

            Assert.Equal(expectedDirection, robot.Direction);
        }

        [Fact]
        public void TurnLeftDoesNotChangePosition()
        {
            var mars = TestFixtures.CreateMars();
            var robot = TestFixtures.CreateRobot(2, 3, Direction.N);
            var command = new TurnLeftCommand();

            command.Execute(robot, mars);

            Assert.Equal(2, robot.X);
            Assert.Equal(3, robot.Y);
        }
    }

    public class TurnRightCommandTests
    {
        [Theory]
        [InlineData(Direction.N, Direction.E)]
        [InlineData(Direction.E, Direction.S)]
        [InlineData(Direction.S, Direction.W)]
        [InlineData(Direction.W, Direction.N)]
        public void TurnsRightCorrectly(Direction startDirection, Direction expectedDirection)
        {
            var mars = TestFixtures.CreateMars();
            var robot = TestFixtures.CreateRobot(0, 0, startDirection);
            var command = new TurnRightCommand();

            command.Execute(robot, mars);

            Assert.Equal(expectedDirection, robot.Direction);
        }

        [Fact]
        public void TurnRightDoesNotChangePosition()
        {
            var mars = TestFixtures.CreateMars();
            var robot = TestFixtures.CreateRobot(2, 3, Direction.N);
            var command = new TurnRightCommand();

            command.Execute(robot, mars);

            Assert.Equal(2, robot.X);
            Assert.Equal(3, robot.Y);
        }
    }

    public class MoveForwardCommandTests
    {
        [Theory]
        [InlineData(Direction.N, 0, 0, 0, 1)]
        [InlineData(Direction.S, 0, 1, 0, 0)]
        [InlineData(Direction.E, 0, 0, 1, 0)]
        [InlineData(Direction.W, 1, 0, 0, 0)]
        public void MovesForwardInCorrectDirection(Direction direction, int startX, int startY, int expectedX, int expectedY)
        {
            var mars = TestFixtures.CreateMars();
            var robot = TestFixtures.CreateRobot(startX, startY, direction);
            var command = new MoveForwardCommand();

            command.Execute(robot, mars);

            Assert.Equal(expectedX, robot.X);
            Assert.Equal(expectedY, robot.Y);
        }

        [Fact]
        public void RobotMarkedLostWhenMovingOffGridWithoutScent()
        {
            var mars = TestFixtures.CreateMars();
            var robot = TestFixtures.CreateRobot(3, 3, Direction.N);
            var command = new MoveForwardCommand();

            command.Execute(robot, mars);

            Assert.True(robot.IsLost);
            Assert.Equal(3, robot.X);
            Assert.Equal(3, robot.Y);
        }

        [Fact]
        public void ScentAddedWhenRobotFallsOff()
        {
            var mars = TestFixtures.CreateMars();
            var robot = TestFixtures.CreateRobot(3, 3, Direction.N);
            var command = new MoveForwardCommand();

            command.Execute(robot, mars);

            Assert.True(mars.HasScent(3, 3));
        }

        [Fact]
        public void RobotNotMarkedLostWhenScentExists()
        {
            var mars = TestFixtures.CreateMars();

            // First robot falls off and leaves scent
            var robot1 = TestFixtures.CreateRobot(3, 3, Direction.N);
            var command = new MoveForwardCommand();
            command.Execute(robot1, mars);
            Assert.True(robot1.IsLost);

            // Second robot encounters same scent
            var robot2 = TestFixtures.CreateRobot(3, 3, Direction.N);
            command.Execute(robot2, mars);

            Assert.False(robot2.IsLost);
            // Robot stays at same position
            Assert.Equal(3, robot2.X);
            Assert.Equal(3, robot2.Y);
        }

        [Fact]
        public void MoveForwardDoesNotChangeDirection()
        {
            var mars = TestFixtures.CreateMars();
            var robot = TestFixtures.CreateRobot(1, 1, Direction.E);
            var command = new MoveForwardCommand();

            command.Execute(robot, mars);

            Assert.Equal(Direction.E, robot.Direction);
        }
    }
}
