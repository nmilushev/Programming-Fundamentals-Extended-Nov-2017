using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Trainlands
{
    class Trainlands
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, Dictionary<string, long>> dataBase =
                new Dictionary<string, Dictionary<string, long>>(); //trainName - (wagonName, wagonPower)

            while ((input = Console.ReadLine()) != "It's Training Men!")
            {
                string[] inputArgs = input.Split(new string[] { " -> ", " : ", " = " }, //ignoring the spaces before/after tokens won't do good
                    StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains(" -> ") && input.Contains(" : "))
                {
                    string trainName = inputArgs[0];
                    string wagonName = inputArgs[1];
                    long wagonPower = long.Parse(inputArgs[2]);

                    if (!dataBase.ContainsKey(trainName))
                    {
                        dataBase.Add(trainName, new Dictionary<string, long>());
                        dataBase[trainName].Add(wagonName, wagonPower);
                    }
                    else
                    {
                        dataBase[trainName].Add(wagonName, wagonPower);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string trainName = inputArgs[0];
                    string otherTrainName = inputArgs[1];

                    if (!dataBase.ContainsKey(trainName))
                    {
                        dataBase.Add(trainName, new Dictionary<string, long>());

                        foreach (var wagon in dataBase[otherTrainName])
                        {
                            dataBase[trainName].Add(wagon.Key, wagon.Value);
                        }
                        dataBase.Remove(otherTrainName);
                    }
                    else
                    {
                        foreach (var wagon in dataBase[otherTrainName])
                        {
                            dataBase[trainName].Add(wagon.Key, wagon.Value);
                        }
                        dataBase.Remove(otherTrainName);
                    }

                }
                else if (input.Contains(" = "))
                {
                    string trainName = inputArgs[0];
                    string otherTrainName = inputArgs[1];

                    if (!dataBase.ContainsKey(trainName))
                    {
                        dataBase.Add(trainName, new Dictionary<string, long>());

                        foreach (var wagon in dataBase[otherTrainName])
                        {
                            dataBase[trainName].Add(wagon.Key, wagon.Value);
                        }
                    }
                    else
                    {
                        dataBase[trainName].Clear();
                        foreach (var wagon in dataBase[otherTrainName])
                        {
                            dataBase[trainName].Add(wagon.Key, wagon.Value);
                        }
                    }
                }
            }

            foreach (var train in dataBase.OrderByDescending(a => a.Value.Values.Sum()).ThenBy(a => a.Value.Values.Count))
            {
                Console.WriteLine($"Train: {train.Key}");
                foreach (var wagon in train.Value.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"###{wagon.Key} - {wagon.Value}");
                }
            }
        }
    }
}
