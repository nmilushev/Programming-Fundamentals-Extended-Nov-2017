using System;

namespace _03.PokeMon
{
    class Poke
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine()); //poke power for pokemon
            uint nNew = n;
            uint m = uint.Parse(Console.ReadLine()); //distance b/n poke targets
            byte y = byte.Parse(Console.ReadLine()); //exhaustionFactor 
            int targetsCount = 0;

            while (nNew >= m)
            {
                nNew -= m;
                targetsCount++;
                if (nNew == 0.5 * n)
                {
                    if (y != 0)
                    {
                        nNew /= y;
                    }
                }
            }

            Console.WriteLine(nNew);
            Console.WriteLine(targetsCount);
        }
    }
}
