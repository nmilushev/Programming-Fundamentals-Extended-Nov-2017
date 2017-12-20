using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PhoenixOscarRomeo
{
    class Phoenix
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> database =
                new Dictionary<string, List<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Blaze it!")
            {
                string[] inputArgs = input.Split(new string[] { " -> " },
                    StringSplitOptions.RemoveEmptyEntries);

                string creature = inputArgs[0];
                string squadMate = inputArgs[1];

                if (!database.ContainsKey(creature))
                {
                    database.Add(creature, new List<string>());
                    database[creature].Add(squadMate);
                }
                else
                {
                    if (!database[creature].Contains(squadMate))
                    {
                        database[creature].Add(squadMate);
                    }
                }
            }

            //whole "complication" here:
            var res = new Dictionary<string, List<string>>();

            foreach (var data in database)
            {
                res.Add(data.Key, new List<string>());

                foreach (var val in data.Value)
                {
                    if (database.ContainsKey(val) && database[val].Contains(data.Key)) //cross check
                    {
                        continue;
                    }
                    else
                    {
                        res[data.Key].Add(val);
                    }
                }
            }

            foreach (var data in res.OrderByDescending(a => a.Value.Count))
            {
                Console.WriteLine($"{data.Key} : {data.Value.Count}");
            }
        }
    }
}
