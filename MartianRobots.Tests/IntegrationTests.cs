namespace MartianRobots.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void SampleInputProducesExpectedOutput()
        {
            var robotsData = new List<(int, int, Direction, string)>
            {
                (1, 1, Direction.E, "RFRFRFRF"),
                (3, 2, Direction.N, "FRRFLLFFRRFLL"),
                (0, 3, Direction.W, "LLFFFLFLFL"),
            };

            var results = TestFixtures.ProcessRobots(5, 3, robotsData);

            Assert.Equal(3, results.Count);
            Assert.Equal("1 1 E", results[0]);
            Assert.Equal("3 3 N LOST", results[1]);
            Assert.Equal("2 3 S", results[2]);
        }

        [Fact]
        public void ScentPreventsSecondRobotFromFallingOff()
        {
            var robotsData = new List<(int, int, Direction, string)>
            {
                (3, 3, Direction.N, "F"),
                (3, 3, Direction.N, "F"),
            };

            var results = TestFixtures.ProcessRobots(5, 3, robotsData);

            Assert.Equal("3 3 N LOST", results[0]);
            Assert.Equal("3 3 N", results[1]);
        }

        [Fact]
        public void MultipleRobotsCanFallOffAtDifferentEdges()
        {
            var robotsData = new List<(int, int, Direction, string)>
            {
                (5, 1, Direction.E, "F"),
                (1, 3, Direction.N, "F"),
            };

            var results = TestFixtures.ProcessRobots(5, 3, robotsData);

            Assert.Equal("5 1 E LOST", results[0]);
            Assert.Equal("1 3 N LOST", results[1]);
        }

        [Fact]
        public void InstructionsStopAfterRobotIsLost()
        {
            // Robot falls off going north, remaining instructions are ignored
            var robotsData = new List<(int, int, Direction, string)>
            {
                (2, 3, Direction.N, "FLFLFLF"),
            };

            var results = TestFixtures.ProcessRobots(5, 3, robotsData);

            // Robot should be lost at (2, 3) facing N — not moved further
            Assert.Equal("2 3 N LOST", results[0]);
        }
    }
}
