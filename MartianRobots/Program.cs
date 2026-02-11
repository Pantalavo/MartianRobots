namespace MartianRobots
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputParser = new InputParser();
            var (maxX, maxY) = inputParser.ParseMarsData();
            var mars = new Mars(maxX, maxY);

            var robotsData = inputParser.ParseRobotsData();
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

            foreach (var result in results)
                Console.WriteLine(result);
        }
    }
}
