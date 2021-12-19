namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the plateau width-height");
            var plateauLimit = Console.ReadLine();
            var limits = plateauLimit.Split(" ");
            
            if (limits.Length == 2)
            {
                Plateau plateau = new Plateau(Convert.ToInt32(limits[0]), Convert.ToInt32(limits[1]));

                while (true)
                {
                    Console.WriteLine("Locate Rover on the plateau");
                    var roverLocate = Console.ReadLine();
                    var pieces = roverLocate.Split(" ");

                    if (pieces.Length == 3)
                    {
                        Rover rover = new Rover(Convert.ToInt32(pieces[0]), Convert.ToInt32(pieces[1]), pieces[2], plateau);

                        Console.WriteLine("Move the rover..");
                        var commands = Console.ReadLine();
                        rover.RoverAction(commands);
                        Console.WriteLine(string.Format("{0} {1} {2}", rover.xCoordinate, rover.yCoordinate, rover.direction));
                    }

                    Console.WriteLine("Do you want to exit program ? (Y/N)");
                    var exitOrContinue = Console.ReadLine();
                    if (exitOrContinue == "Y")
                        break;
                }
            }
        }
    }
}
