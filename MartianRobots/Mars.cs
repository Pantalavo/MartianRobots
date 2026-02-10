namespace MartianRobots
{
    public class Mars
    {
        private readonly HashSet<string> _scents = new();

        public Mars(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public int MaxX { get; }
        public int MaxY { get; }

        public bool IsOffSurface(int x, int y)
            => x < 0 || y < 0 || x > MaxX || y > MaxY;

        public void AddScent(int x, int y, Direction direction)
            => _scents.Add($"{x},{y},{direction}");
    }
}
