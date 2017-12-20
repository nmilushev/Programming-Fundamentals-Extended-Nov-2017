using System;
using System.Collections.Generic;

namespace _04.Resurrection
{
    class Phoenix
    {
        public long totalLength { get; set; }
        public decimal totalWidth { get; set; }
        public int oneWingLen { get; set; }
        public decimal years { get; set; }
    }

    class Resurr
    {
        static void Main(string[] args)
        {
            List<Phoenix> dataBase = new List<Phoenix>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Phoenix p = new Phoenix();
                p.totalLength = long.Parse(Console.ReadLine());
                p.totalWidth = decimal.Parse(Console.ReadLine());
                p.oneWingLen = int.Parse(Console.ReadLine());
                p.years = (p.totalLength * p.totalLength) * (p.totalWidth + 2 * p.oneWingLen);
                dataBase.Add(p);
            }

            foreach (var phoenix in dataBase)
            {
                Console.WriteLine(phoenix.years);
            }
        }
    }
}
