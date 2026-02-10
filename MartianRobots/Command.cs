namespace MartianRobots
{
    public interface ICommand
    {
        void Execute(Robot robot, Mars mars);
    }

    public class TurnLeftCommand : ICommand
    {
        private static readonly Dictionary<Direction, Direction> _directionMapping = new()
        {
            { Direction.N, Direction.W },
            { Direction.W, Direction.S },
            { Direction.S, Direction.E },
            { Direction.E, Direction.N }
        };

        public void Execute(Robot robot, Mars mars)
        {
            robot.Direction = _directionMapping[robot.Direction];
        }
    }

    public class TurnRightCommand : ICommand
    {
        private static readonly Dictionary<Direction, Direction> _directionMapping = new()
        {
            { Direction.N, Direction.E },
            { Direction.E, Direction.S },
            { Direction.S, Direction.W },
            { Direction.W, Direction.N }
        };

        public void Execute(Robot robot, Mars mars)
        {
            robot.Direction = _directionMapping[robot.Direction];
        }
    }

    public class MoveForwardCommand : ICommand
    {
        public void Execute(Robot robot, Mars mars)
        {
            int nextX = robot.X;
            int nextY = robot.Y;

            switch (robot.Direction)
            {
                case Direction.N: 
                    nextY++;
                    break;
                case Direction.S: 
                    nextY--;
                    break;
                case Direction.E:
                    nextX++; 
                    break;
                case Direction.W:
                    nextX--;
                    break;
            }

            if (mars.IsOffSurface(nextX, nextY))
            {
                mars.AddScent(robot.X, robot.Y, robot.Direction);
                robot.IsLost = true;

                return;
            }

            robot.X = nextX;
            robot.Y = nextY;
        }
    }
}
