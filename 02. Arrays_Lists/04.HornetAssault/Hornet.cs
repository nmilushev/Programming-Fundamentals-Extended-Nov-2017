using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HornetAssault
{
    class Hornet
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine().Split(' ')
                .Select(long.Parse)
                .ToList();

            List<long> hornets = Console.ReadLine().Split(' ')
                .Select(long.Parse)
                .ToList();

            List<long> beehivesAlive = new List<long>();

            bool allHornetsAlive = true;
            long sum = 0;

            for (int i = 0; i < hornets.Count; i++)
            {
                sum += hornets[i];
            }

            foreach (long bee in beehives)
            {
                if (sum <= bee)
                {
                    allHornetsAlive = false;
                    break;
                }
            }

            if (allHornetsAlive)
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
            else
            {
                for (int i = 0; i < beehives.Count; i++)
                {
                    if (sum <= beehives[i])
                    {
                        beehives[i] -= sum;
                        if (beehives[i] > 0)
                        {
                            beehivesAlive.Add(beehives[i]);
                        }
                        if (hornets.Count > 0)
                        {
                            hornets.Remove(hornets[0]);
                            sum = 0;
                            for (int j = 0; j < hornets.Count; j++)
                            {
                                sum += hornets[j];
                            }
                        }
                    }
                }

                Console.WriteLine(beehivesAlive.Count > 0
                    ? string.Join(" ", beehivesAlive)
                    : string.Join(" ", hornets));
            }
        }
    }
}