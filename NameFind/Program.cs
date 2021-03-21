using System;

namespace NameFind
{
    class Program
    {
        static void Main(string[] args)
        {
            char GuessedKey;
            int tries = 5;
            SecretWord s = new SecretWord("Mikael");

            Console.Clear();
            do
            {
                ConsoleIO.WriteCharsRow(s.GuessDict);
                string Prompt = $"Name: {s.Hidden}, Tries left: {tries} >";
                GuessedKey = ConsoleIO.GetKey(prompt: Prompt);
                if (s.GuessChar(GuessedKey))
                    ConsoleIO.WriteLine(char.ToUpper(GuessedKey), ConsoleColor.Green);
                else
                {
                    ConsoleIO.WriteLine(char.ToUpper(GuessedKey), ConsoleColor.Red);
                    tries--;
                }

            } while (!s.IsFound && tries > 0);

            if (s.IsFound)
            {
                string[] Message = {
                    "CONGRATUALTIONS! YOU FOUND THE SECRET NAME!",
                    $"THE SECRET NAME WAS: {s.Secret}"
                };
                ConsoleIO.PrintMessages(Message, ConsoleColor.Green);
            }
            else
            {
                string[] Message = {
                    "YOU FAILED TO FIND THE SECRET NAME!",
                    $"THE SECRET NAME WAS: {s.Secret}"
                };
                ConsoleIO.PrintMessages(Message, ConsoleColor.Red);
            }
        }
    }
}
