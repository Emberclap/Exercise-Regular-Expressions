using Microsoft.VisualBasic;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine()
                .Split(", ")
                .ToArray();

            Dictionary<string, int> participant = new Dictionary<string, int>();  
            for (int i = 0; i < participants.Length; i++)
            {
                participant.Add(participants[i], 0);
            }
            string namePattern = @"[A-Za-z]";
            string kmPattern = @"\d";
            string input = "";
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder name = new StringBuilder();
                int distance = 0;
                foreach (Match match in Regex.Matches(input, namePattern))
                {
                    name.Append(match.Value);
                }
                foreach (Match match in Regex.Matches(input, kmPattern))
                {
                    distance += int.Parse(match.Value);
                }
                if (participant.ContainsKey(name.ToString()))
                {
                    participant[name.ToString()] += distance; 
                }
               
            }
            var sortedList = participant
                .OrderByDescending(x => x.Value)
                .ToList();
                Console.WriteLine($"1st place: {sortedList[0].Key}");
                Console.WriteLine($"2nd place: {sortedList[1].Key}");
                Console.WriteLine($"3rd place: {sortedList[2].Key}");

        }
    }
}