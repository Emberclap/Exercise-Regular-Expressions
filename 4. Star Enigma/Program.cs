using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    internal class Program
    {
            static void Main()
            {
                int n = int.Parse(Console.ReadLine());
                List<string> attackedPlanets = new List<string>();
                List<string> destroyedPlanets = new List<string>();

                for (int i = 0; i < n; i++)
                {
                    string encryptedMessage = Console.ReadLine();

                    int key = CountLetters("star", encryptedMessage);
                    string decryptedMessage = DecryptMessage(encryptedMessage, key);

                    string pattern = @"@([A-Za-z]+)[^@\-!:>]*:([0-9]+)[^@\-!:>]*!([AD])![^@\-!:>]*->([0-9]+)";
                    Match match = Regex.Match(decryptedMessage, pattern);

                    if (match.Success)
                    {
                        string planetName = match.Groups[1].Value;
                        int population = int.Parse(match.Groups[2].Value);
                        string attackType = match.Groups[3].Value;
                        int soldierCount = int.Parse(match.Groups[4].Value);

                        if (attackType == "A")
                            attackedPlanets.Add(planetName);
                        else if (attackType == "D")
                            destroyedPlanets.Add(planetName);
                    }
                }

                PrintPlanets("Attacked planets", attackedPlanets);
                PrintPlanets("Destroyed planets", destroyedPlanets);
            }

            static int CountLetters(string letters, string message)
            {
                int count = 0;
                foreach (char letter in message)
                {
                    if (letters.Contains(char.ToLower(letter)))
                        count++;
                }
                return count;
            }

            static string DecryptMessage(string message, int key)
            {
                string decrypted = "";
                foreach (char letter in message)
                {
                    char decryptedLetter = (char)(letter - key);
                    decrypted += decryptedLetter;
                }
                return decrypted;
            }

            static void PrintPlanets(string title, List<string> planets)
            {
                Console.WriteLine($"{title}: {planets.Count}");
                foreach (string planet in planets.OrderBy(p => p))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }

    }
