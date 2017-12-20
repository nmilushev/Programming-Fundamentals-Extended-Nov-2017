using System;

namespace _05.Wormfest
{
    class Worm
    {
        static void Main(string[] args)
        {
            long len = long.Parse(Console.ReadLine()) * 100; //given in meters, converted to cm
            double wid = double.Parse(Console.ReadLine());

            int rem = (int)(len % wid); //store remainder of division

            if (rem == 0 || wid == 0) //keything wid = 0!!!
            {
                Console.WriteLine($"{len * wid:F2}");
            }
            else
            {
                Console.WriteLine($"{((100 * len) / wid):F2}%");
            }
        }
    }
}
