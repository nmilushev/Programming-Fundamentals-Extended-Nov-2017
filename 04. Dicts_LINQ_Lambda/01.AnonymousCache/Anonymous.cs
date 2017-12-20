using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.AnonymousCache
{
    class Anonymous
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, Dictionary<string, long>> database =
                new Dictionary<string, Dictionary<string, long>>();

            Dictionary<string, Dictionary<string, long>> cache =
                new Dictionary<string, Dictionary<string, long>>();

            while ((input = Console.ReadLine()) != "thetinggoesskrra")
            {
                if (!input.Contains("->"))
                {
                    if (!database.ContainsKey(input))
                    {
                        database.Add(input, new Dictionary<string, long>());
                        if (cache.ContainsKey(input))
                        {
                            database[input] = cache[input];
                            cache.Remove(input);
                        }
                    }
                }
                else
                {
                    string[] inputArgs = input.Split(new string[] { " ", "-", ">", "|" },
                        StringSplitOptions.RemoveEmptyEntries);

                    string dataKey = inputArgs[0];
                    long dataSize = long.Parse(inputArgs[1]);
                    string dataSet = inputArgs[2];

                    if (!database.ContainsKey(dataSet))
                    {
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache.Add(dataSet, new Dictionary<string, long>());
                            cache[dataSet].Add(dataKey, dataSize);
                        }
                        else
                        {
                            cache[dataSet].Add(dataKey, dataSize);
                        }
                    }
                    else
                    {
                        database[dataSet].Add(dataKey, dataSize);
                    }
                }
            }

            if (database.Count != 0)
            {
                KeyValuePair<string, Dictionary<string, long>> result =
                    database.OrderByDescending(a => a.Value.Values.Sum()).First();

                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Values.Sum()}");

                foreach (var l in result.Value)
                {
                    Console.WriteLine($"$.{l.Key}");
                }
            }
        }
    }
}
