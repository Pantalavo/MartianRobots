namespace MartianRobots.Tests
{
    public class MarsTests
    {
        [Fact]
        public void ConstructorSetsDimensions()
        {
            var mars = new Mars(5, 3);

            Assert.Equal(5, mars.MaxX);
            Assert.Equal(3, mars.MaxY);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(6, 3)]
        [InlineData(5, 4)]
        public void IsOffSurfaceReturnsTrueForInvalidCoordinates(int x, int y)
        {
            var mars = new Mars(5, 3);

            Assert.True(mars.IsOffSurface(x, y));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 3)]
        [InlineData(2, 1)]
        [InlineData(5, 0)]
        [InlineData(0, 3)]
        public void IsOffSurfaceReturnsFalseForValidCoordinates(int x, int y)
        {
            var mars = new Mars(5, 3);

            Assert.False(mars.IsOffSurface(x, y));
        }

        [Fact]
        public void AddScentStoresScent()
        {
            var mars = new Mars(5, 3);

            mars.AddScent(3, 3);

            Assert.True(mars.HasScent(3, 3));
        }

        [Fact]
        public void HasScentReturnsFalseForNonExistentScent()
        {
            var mars = new Mars(5, 3);

            Assert.False(mars.HasScent(1, 1));
        }

        [Fact]
        public void ScentIsSpecificToPosition()
        {
            var mars = new Mars(5, 3);
            mars.AddScent(3, 3);

            // Different position - should not have scent
            Assert.False(mars.HasScent(2, 3));
            Assert.False(mars.HasScent(3, 2));

            // Same position - should have scent
            Assert.True(mars.HasScent(3, 3));
        }

        [Fact]
        public void MultipleScentsCanBeStored()
        {
            var mars = new Mars(5, 3);

            mars.AddScent(1, 1);
            mars.AddScent(2, 2);
            mars.AddScent(3, 3);

            Assert.True(mars.HasScent(1, 1));
            Assert.True(mars.HasScent(2, 2));
            Assert.True(mars.HasScent(3, 3));
        }
    }
}
