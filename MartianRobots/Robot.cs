namespace MartianRobots
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
        public bool IsLost { get; set; }

        public Robot(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public override string ToString()
        {
            return IsLost ? $"{X} {Y} {Direction} LOST": $"{X} {Y} {Direction}";
        }
    }
}
