using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.HornetArmada
{
    class Hornet
    {
        static void Main(string[] args)
        {
            Dictionary<string, Legion> database
              = new Dictionary<string, Legion>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(new char[] { '=', '-', '>', ':', ' ' }
                    , StringSplitOptions.RemoveEmptyEntries);

                long lastActivity = long.Parse(inputArgs[0]);
                string legionName = inputArgs[1];
                string soldierType = inputArgs[2];
                long soldierCount = long.Parse(inputArgs[3]);

                if (!database.ContainsKey(legionName))
                {
                    database.Add(legionName, new Legion(legionName, lastActivity));
                    database[legionName].Soldier.Add(soldierType, soldierCount);
                }
                else
                {
                    if (!database[legionName].Soldier.ContainsKey(soldierType))
                    {
                        database[legionName].Soldier.Add(soldierType, soldierCount);
                    }
                    else
                    {
                        database[legionName].Soldier[soldierType] += soldierCount;
                    }
                    if (database[legionName].lastActivity < lastActivity)
                    {
                        database[legionName].lastActivity = lastActivity;
                    }
                }
            }

            string[] cmdOutputArgs = Console.ReadLine().Split('\\');

            if (cmdOutputArgs.Length > 1)
            {
                long activity = long.Parse(cmdOutputArgs[0]);
                string soldierTyp = cmdOutputArgs[1];

                foreach (var legion in database
                    .Where(a => a.Value.Soldier.ContainsKey(soldierTyp))
                    .OrderByDescending(b => b.Value.Soldier[soldierTyp]))
                {
                    if (legion.Value.lastActivity < activity)
                    {
                        Console.WriteLine($"{legion.Key} -> {legion.Value.Soldier[soldierTyp]}");
                    }
                }
            }
            else
            {
                string soldierTyp = cmdOutputArgs[0];

                foreach (var legion in database.OrderByDescending(a => a.Value.lastActivity))
                {
                    if (legion.Value.Soldier.ContainsKey(soldierTyp))
                    {
                        Console.WriteLine($"{legion.Value.lastActivity} : {legion.Key}");
                    }
                }
            }
        }
    }

    class Legion
    {
        public string legionName { get; set; }
        public long lastActivity { get; set; }

        public Dictionary<string, long> Soldier
            = new Dictionary<string, long>();

        public Legion(string legionName, long lastActivity)
        {
            this.legionName = legionName;
            this.lastActivity = lastActivity;
            this.Soldier = new Dictionary<string, long>();
        }
    }
}
