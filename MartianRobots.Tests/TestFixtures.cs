namespace MartianRobots.Tests
{
    public class TestFixtures
    {
        public static Mars CreateMars() => new Mars(5, 3);

        public static Robot CreateRobot(int x, int y, Direction dir) => new Robot(x, y, dir);

        public static List<string> ProcessRobots(int maxX, int maxY, List<(int x, int y, Direction direction, string instructions)> robotsData)
        {
            var mars = new Mars(maxX, maxY);
            var results = new List<string>();

            foreach (var (x, y, direction, instructions) in robotsData)
            {
                var robot = new Robot(x, y, direction);

                foreach (char c in instructions)
                {
                    if (robot.IsLost)
                        break;

                    var command = CommandFactory.GetCommand(c);
                    command.Execute(robot, mars);
                }

                results.Add(robot.ToString());
            }

            return results;
        }
    }
}
