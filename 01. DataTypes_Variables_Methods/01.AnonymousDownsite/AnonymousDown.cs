using System;
using System.Collections.Generic;
using System.Numerics;

namespace _01.AnonymousDownsite
{
    class AnonymousDown
    {
        static void Main(string[] args)
        {
            int sitesDown = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal siteLoss = 0M; //meaning at least one decimal should be as multiplier
            List<string> sites = new List<string>();

            for (int i = 0; i < sitesDown; i++)
            {
                string inputSites = Console.ReadLine();
                string[] inputArguments = inputSites.Split(' ');
                string siteName = inputArguments[0];
                uint siteVisits = uint.Parse(inputArguments[1]); //check that, uint covers 2^32
                decimal pricePerVisit = decimal.Parse(inputArguments[2]); //20 decimal places

                //Wrong!!! It is never mentioned that duplicates shall NOT be printed
                //if (!sites.Contains(siteName))
                //{

                sites.Add(siteName);

                //}

                //Site Loss is not neccessary to be stored 
                //in a dict or array as it summed always, regardless siteName
                siteLoss += siteVisits * pricePerVisit;
            }

            foreach (var site in sites)
            {
                Console.WriteLine(site);
            }

            Console.WriteLine($"Total Loss: {siteLoss:F20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, sitesDown)}");
        }
    }
}
