using System.Globalization;
using System.Text.RegularExpressions;

namespace _3._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            string pattern = @"\%(?<name>[A-Z][a-z]+)\%[^|$%.]*<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+\.?\d*)\$";
            decimal sum = 0;
            while ((input = Console.ReadLine()) != "end of shift") 
            {
                Match match = Regex.Match(input, pattern);
                if (Regex.IsMatch(input, pattern))
                {
                    decimal totalPrice = decimal.Parse(match.Groups["price"].Value, System.Globalization.CultureInfo.InvariantCulture) * int.Parse(match.Groups["count"].Value);
                    sum += totalPrice;
                    Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {totalPrice:f2}");
                }
            }
            Console.WriteLine($"Total income: {sum:f2}");
        }
    }
}