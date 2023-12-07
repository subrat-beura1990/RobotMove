using System;
using System.IO;

namespace RoboMove
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "C:\\RoboMove\\RoboMove\\RoboMove\\commands.txt";
                if (File.Exists(filePath))
                {
                    string[] commands = File.ReadAllLines(filePath);
                    ToyRobot toyRobot = new ToyRobot();

                    foreach (string command in commands)
                    {
                        ExecuteCommand(toyRobot, command);
                    }
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ExecuteCommand(ToyRobot toyRobot, string command)
        {
            string[] parts = command.Split(' ');
            switch (parts[0])
            {
                case "PLACE":
                    if (parts.Length == 2)
                    {
                        string[] position = parts[1].Split(',');
                        if (position.Length == 3 &&
                            int.TryParse(position[0], out int x) &&
                            int.TryParse(position[1], out int y) &&
                            Enum.TryParse(position[2], out Direction direction))
                        {
                            toyRobot.Place(x, y, direction);
                        }
                    }
                    break;

                case "MOVE":
                    toyRobot.Move();
                    break;

                case "LEFT":
                    toyRobot.TurnLeft();
                    break;

                case "RIGHT":
                    toyRobot.TurnRight();
                    break;

                case "REPORT":
                    //var res = toyRobot.Report();
                    Console.WriteLine(toyRobot.Report());
                    //Console.ReadLine();
                    break;
            }
        }
    }

}
