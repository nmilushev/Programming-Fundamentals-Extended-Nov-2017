using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Traingram
{
    class Traingram
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            string pattern = @"^(^[<]{1}[[]{1}[^a-zA-Z0-9]*[]]{1}[.]{1}){1}([.]{1}[[]{1}[a-zA-Z0-9]*[]]{1}[.]{1})*";
            List<string> valid = new List<string>();

            while ((input = Console.ReadLine()) != "Traincode!")
            {
                if (input.First() != '<' || input.Last() != '.')
                {
                    continue;
                }

                if (Regex.Match(input, pattern).Success)
                {
                    Match match = Regex.Match(input, pattern);
                    if (match.ToString() == input)
                    {
                        valid.Add(input);
                    }
                }
            }

            foreach (var train in valid)
            {
                Console.WriteLine(train);
            }
        }
    }
}