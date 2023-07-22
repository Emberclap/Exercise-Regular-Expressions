using System.Globalization;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furniture>[A-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
            string input = " ";
            var regex = new Regex(pattern);
            decimal sum = 0;
            List<string> furniture = new List<string>();
            while ((input = Console.ReadLine()) != "Purchase")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    furniture.Add(match.Groups["furniture"].Value);
                    decimal price = decimal.Parse((match.Groups["price"].Value), System.Globalization.CultureInfo.InvariantCulture);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    sum += price * quantity;
                }

            }
            
            Console.WriteLine("Bought furniture:");
            foreach (var item in furniture)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}