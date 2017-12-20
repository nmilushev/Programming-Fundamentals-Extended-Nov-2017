using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.AnonymousVox
{
    class Anonymous
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(?<startEnd>[a-zA-Z]+)(?<placeholder>.*)\1");

            string text = Console.ReadLine();
            string replacement = Console.ReadLine();
            string[] replacementArgs = replacement.Split(new string[] { "{", "}" }
                , StringSplitOptions.RemoveEmptyEntries);

            MatchCollection matches = regex.Matches(text);
            List<string> matchesPlaceholder = new List<string>();

            foreach (Match match in matches)
            {
                matchesPlaceholder.Add(match.Groups["placeholder"].ToString());
            }

            for (int i = 0; i < matches.Count; i++)
            {
                int firstIndex = text.IndexOf(matchesPlaceholder[i]);
                text = text.Insert(firstIndex, replacementArgs[i]);
                text = text.Remove(firstIndex + replacementArgs[i].Length, matchesPlaceholder[i].Length);
            }

            Console.WriteLine(text);
        }
    }
}
