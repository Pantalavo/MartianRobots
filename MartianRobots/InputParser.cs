namespace MartianRobots
{
    public class InputParser
    {
        private readonly TextReader _reader;

        public InputParser() : this(Console.In) { }

        public InputParser(TextReader reader)
        {
            _reader = reader;
        }

        // reads and validates the first line of input for Mars dimensions
        public (int maxX, int maxY) ParseMarsData()
        {
            var input = _reader.ReadLine()?.Split() ?? throw new InvalidOperationException("Error reading dimensions");
            int maxX = int.Parse(input[0]);
            int maxY = int.Parse(input[1]);

            ValidateCoordinate(maxX);
            ValidateCoordinate(maxY);

            return (maxX, maxY);
        }

        // reads and validates robot data yielding tuples of (x, y, direction, instructions)
        public IEnumerable<(int x, int y, Direction direction, string instructions)> ParseRobotsData()
        {
            while (true)
            {
                var line = _reader.ReadLine();
                if (line is null)
                    break;

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Trim().Split();
                int x = int.Parse(parts[0].Trim());
                int y = int.Parse(parts[1].Trim());
                Direction direction = Enum.Parse<Direction>(parts[2].Trim());

                ValidateCoordinate(x);
                ValidateCoordinate(y);

                var instructions = _reader.ReadLine()?.Trim() ?? "";
                ValidateInstructions(instructions);

                yield return (x, y, direction, instructions);
            }
        }

        private void ValidateCoordinate(int value)
        {
            if (value < 0 || value > 50)
                throw new ArgumentException("Coordinate must be between 0 and 50");
        }

        private void ValidateInstructions(string instructions)
        {
            if (instructions.Length >= 100)
                throw new ArgumentException("Instructions must be less than 100 characters");
        }
    }
}
