using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.HornetComm
{
    class Hornet
    {
        static void Main(string[] args)
        {
            string patternPrivateMessage = @"^([0-9]*)( [<][-][>] )([a-zA-Z0-9]*)?";
            string patternBroadcast = @"^([^0-9]*)( [<][-][>] )([a-zA-Z0-9]*)?";

            List<string> recipient = new List<string>();
            List<string> messages = new List<string>();

            List<string> frequency = new List<string>();
            List<string> messagesBroadcast = new List<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Hornet is Green")
            {
                var inputArgs = input.Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs.Length != 2)
                {
                    continue;
                }

                string query1 = inputArgs[0];
                string query2 = inputArgs[1];

                Match match = Regex.Match(input, patternBroadcast);
                Match match2 = Regex.Match(input, patternPrivateMessage);

                if (!Regex.IsMatch(input, patternBroadcast) && !Regex.IsMatch(input, patternPrivateMessage))
                {
                    continue;
                }
                if (match.ToString() != input && match2.ToString() != input)
                {
                    continue;
                }
                if (Regex.Match(input, patternPrivateMessage).Success)
                {
                    recipient.Add(ReverseString(query1));
                    messages.Add(query2);
                }
                if (Regex.Match(input, patternBroadcast).Success)
                {
                    messagesBroadcast.Add(LowToUpToLow(query2));
                    frequency.Add(query1);
                }
            }

            Console.WriteLine("Broadcasts:");

            if (messagesBroadcast.Count <= 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                for (int i = 0; i < messagesBroadcast.Count; i++)
                {
                    Console.Write(messagesBroadcast[i] + " -> " + frequency[i]);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Messages:");
            if (messages.Count <= 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    Console.Write(recipient[i] + " -> " + messages[i]);
                    Console.WriteLine();
                }
            }
        }

        private static string LowToUpToLow(string query2) //covnerts the lower case chars to up and vice versa
        {
            List<char> chars = new List<char>();

            for (int i = 0; i < query2.Length; i++)
            {
                chars.Add(query2[i]);
            }

            for (int i = 0; i < chars.Count; i++)
            {
                if (chars[i] >= 97 && chars[i] <= 122)
                {
                    chars[i] -= ' ';
                }
                else if (chars[i] >= 65 && chars[i] <= 90)
                {
                    chars[i] += ' ';
                }
            }

            string result = "";

            for (int i = 0; i < chars.Count; i++)
            {
                result += Convert.ToChar(chars[i]);
            }

            return result;
        }

        private static string ReverseString(string query1)
        {
            var temp = query1.ToCharArray();
            Array.Reverse(temp);
            return new string(temp);
        }
    }
}
