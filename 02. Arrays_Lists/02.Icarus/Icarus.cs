using System;
using System.Linq;

namespace _02.Icarus
{
    class Icarus
    {
        static void Main(string[] args)
        {
            int[] plane = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();

            int startIndex = int.Parse(Console.ReadLine());

            string commandAndSteps = String.Empty;

            int damage = 1;

            while ((commandAndSteps = Console.ReadLine()) != "Supernova")
            {
                string[] cmdArgs = commandAndSteps.Split(' ');
                string cmd = cmdArgs[0];
                int steps = int.Parse(cmdArgs[1]);

                switch (cmd)
                {
                    case "left":
                        while (steps-- > 0)
                        {
                            if (startIndex == 0)
                            {
                                startIndex = plane.Length - 1;
                                damage++;
                                plane[startIndex] -= damage;
                                continue;
                            }
                            startIndex--;
                            plane[startIndex] -= damage;
                        }
                        break;

                    case "right":
                        while (steps-- > 0)
                        {
                            if (startIndex == plane.Length - 1)
                            {
                                startIndex = 0;
                                damage++;
                                plane[startIndex] -= damage;
                                continue;
                            }
                            startIndex++;
                            plane[startIndex] -= damage;
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", plane));
        }
    }
}
