using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PokemonDontGo
{
    class Poke
    {
        static void Main(string[] args)
        {
            List<int> numbers =
                Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> removedInts =
                new List<int>();

            while (numbers.Count > 0)
            {
                int cmd = int.Parse(Console.ReadLine());

                if (cmd < 0)
                {
                    cmd = 0;
                    int temp = numbers[cmd];
                    removedInts.Add(numbers[cmd]);

                    numbers.RemoveAt(0);
                    numbers.Insert(0, numbers[numbers.Count - 1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= temp) numbers[i] += temp;
                        else numbers[i] -= temp;
                    }

                }
                else if (cmd > numbers.Count - 1)
                {
                    cmd = numbers.Count - 1;
                    int temp = numbers[cmd];
                    removedInts.Add(numbers[cmd]);

                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Insert(numbers.Count, numbers[0]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= temp) numbers[i] += temp;
                        else numbers[i] -= temp;
                    }
                }
                else
                {
                    int temp = numbers[cmd];
                    removedInts.Add(numbers[cmd]);
                    numbers.RemoveAt(cmd);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] <= temp) numbers[i] += temp;
                        else numbers[i] -= temp;
                    }
                }
            }

            long sum = 0L;

            for (int i = 0; i < removedInts.Count; i++)
            {
                sum += removedInts[i];
            }
            Console.WriteLine(sum);
        }
    }
}
