using System;
using System.Collections.Generic;
using System.Text;

namespace _01.AnonymousThreat
{
    class Anonymous
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArguments = input.Split(' ');
            List<string> strings = new List<string>();

            for (int i = 0; i < inputArguments.Length; i++)
            {
                strings.Add(inputArguments[i]);
            }

            string[] commandsInput = Console.ReadLine().Split(' ');

            while (commandsInput[0] != "3:1")
            {
                string cmd = commandsInput[0];
                int start = int.Parse(commandsInput[1]);
                int end = int.Parse(commandsInput[2]);

                switch (cmd)
                {
                    case "merge":
                        strings = MergeThatString(strings, start, end);
                        break;
                    case "divide":
                        strings = DivideThatString(strings, start, end);
                        break;
                }
                commandsInput = Console.ReadLine().Split(' ');
            }
            Console.Write(string.Join(" ", strings));

        }

        private static List<string> DivideThatString(List<string> strings, int start, int end)
        {
            List<string> res = new List<string>();
            List<string> parts = new List<string>();

            int len = strings[start].Length / end;

            //no check for index as per condition is always within the string

            //add elements before
            for (int i = 0; i < start; i++) { res.Add(strings[i]); }

            for (int i = 0; i < end; i++)
            {
                parts.Add(i == end - 1 ? strings[start].Substring(i * len) :
                                        strings[start].Substring(i * len, len));
            }

            //add parts to result list
            for (int i = 0; i < parts.Count; i++) { res.Add(parts[i]); }

            //add rest elements
            for (int i = start + 1; i < strings.Count; i++) { res.Add(strings[i]); }

            return res;
        }

        private static List<string> MergeThatString(List<string> strings, int start, int end)
        {
            if (start < 0 || start > strings.Count - 1)
                start = 0;
            if (end > strings.Count - 1 || end < 0)
                end = strings.Count - 1;

            StringBuilder sb = new StringBuilder();
            List<string> res = new List<string>();

            //add all elements from 0 to start to the list
            for (int i = 0; i < start; i++) { res.Add(strings[i]); }

            //append changes in a string builder
            for (int i = start; i <= end; i++) { sb.Append(strings[i]); }

            //add the sb to the list
            res.Add(sb.ToString());

            //add all elements from end to initialList.Length to the list
            for (int i = end + 1; i < strings.Count; i++) { res.Add(strings[i]); }

            return res;
        }
    }
}
