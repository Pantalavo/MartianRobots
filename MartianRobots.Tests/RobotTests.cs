namespace MartianRobots.Tests
{
    public class RobotTests
    {
        [Fact]
        public void ConstructorSetsPositionAndDirection()
        {
            var robot = TestFixtures.CreateRobot(3, 5, Direction.N);

            Assert.Equal(3, robot.X);
            Assert.Equal(5, robot.Y);
            Assert.Equal(Direction.N, robot.Direction);
        }

        [Fact]
        public void ToStringFormatsCorrectlyWithoutLost()
        {
            var robot = TestFixtures.CreateRobot(1, 2, Direction.E);

            Assert.Equal("1 2 E", robot.ToString());
        }

        [Fact]
        public void ToStringFormatsCorrectlyWithLost()
        {
            var robot = TestFixtures.CreateRobot(3, 3, Direction.N);
            robot.IsLost = true;

            Assert.Equal("3 3 N LOST", robot.ToString());
        }

        [Fact]
        public void DirectionCanBeChanged()
        {
            var robot = TestFixtures.CreateRobot(0, 0, Direction.N);
            robot.Direction = Direction.E;

            Assert.Equal(Direction.E, robot.Direction);
        }

        [Fact]
        public void PositionCanBeChanged()
        {
            var robot = TestFixtures.CreateRobot(0, 0, Direction.N);
            robot.X = 5;
            robot.Y = 10;

            Assert.Equal(5, robot.X);
            Assert.Equal(10, robot.Y);
        }
    }
}
