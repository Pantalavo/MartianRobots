namespace MartianRobots.Tests
{
    public class InputParserTests
    {
        [Fact]
        public void ParseMarsDataReturnsCorrectDimensions()
        {
            var parser = new InputParser(new StringReader("5 3\n"));

            var (maxX, maxY) = parser.ParseMarsData();

            Assert.Equal(5, maxX);
            Assert.Equal(3, maxY);
        }

        [Fact]
        public void ParseMarsDataThrowsOnNullInput()
        {
            var parser = new InputParser(new StringReader(""));

            Assert.Throws<InvalidOperationException>(() => parser.ParseMarsData());
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -2)]
        [InlineData(53, 0)]
        [InlineData(0, 51)]
        public void ParseMarsDataThrowsForInvalidCoordinates(int x, int y)
        {
            var parser = new InputParser(new StringReader($"{x} {y}\n"));

            Assert.Throws<ArgumentException>(() => parser.ParseMarsData());
        }

        [Fact]
        public void ParseRobotsDataReturnsSingleRobot()
        {
            var parser = new InputParser(new StringReader("1 1 E\nRFRFRFRF\n"));

            var robots = parser.ParseRobotsData().ToList();

            Assert.Single(robots);
            Assert.Equal(1, robots[0].x);
            Assert.Equal(1, robots[0].y);
            Assert.Equal(Direction.E, robots[0].direction);
            Assert.Equal("RFRFRFRF", robots[0].instructions);
        }

        [Fact]
        public void ParseRobotsDataReturnsMultipleRobots()
        {
            var parser = new InputParser(new StringReader("1 1 E\nRFRFRFRF\n3 2 N\nFRRFLLFFRRFLL\n"));

            var robots = parser.ParseRobotsData().ToList();

            Assert.Equal(2, robots.Count);
            Assert.Equal(Direction.E, robots[0].direction);
            Assert.Equal(Direction.N, robots[1].direction);
        }

        [Theory]
        [InlineData(-2, 0)]
        [InlineData(0, -1)]
        [InlineData(53, 0)]
        [InlineData(0, 51)]
        public void ParseRobotsDataThrowsForInvalidRobotCoordinates(int x, int y)
        {
            var parser = new InputParser(new StringReader($"{x} {y} N\nF\n"));

            Assert.Throws<ArgumentException>(() => parser.ParseRobotsData().ToList());
        }

        [Fact]
        public void ParseRobotsDataThrowsForInstructionsTooLong()
        {
            var longInstructions = new string('F', 100);
            var parser = new InputParser(new StringReader($"1 1 N\n{longInstructions}\n"));

            Assert.Throws<ArgumentException>(() => parser.ParseRobotsData().ToList());
        }

        [Fact]
        public void ParseRobotsDataAcceptsInstructionsUnder100Characters()
        {
            var instructions = new string('F', 99);
            var parser = new InputParser(new StringReader($"1 1 N\n{instructions}\n"));

            var robots = parser.ParseRobotsData().ToList();

            Assert.Single(robots);
            Assert.Equal(instructions, robots[0].instructions);
        }
    }
}
