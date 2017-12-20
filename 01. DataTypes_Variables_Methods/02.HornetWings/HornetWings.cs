using System;

namespace _02.HornetWings
{
    class HornetWings
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //wing flaps
            double m = double.Parse(Console.ReadLine()); //distance per 1000 wing flaps
            int p = int.Parse(Console.ReadLine()); //hornet endurance

            double metersTraveled = (n / 1000) * m;
            Console.WriteLine($"{metersTraveled:F2} m.");
            double secondsPassed = (n/p)*5 + n/100;
            Console.WriteLine($"{secondsPassed} s.");
        }
    }
}
