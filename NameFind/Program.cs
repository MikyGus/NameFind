using System;

namespace NameFind
{

    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            string[] NameList =
            {
                "Mikael",
                "Marie",
                "Liam",
                "Noah",
                "Oliver",
                "William",
                "Elijah",
                "James",
                "Benjamin"
            };
            char GuessedKey;
            int tries = 5;
            string secretName = NameList[rand.Next(NameList.Length)];

            //Console.WriteLine("Five random integers between 50 and 100:");
            //for (int ctr = 0; ctr <= 4; ctr++)
            //    Console.Write("{0,8:N0}", rand.Next(0, NameList.Length));
            Console.WriteLine($"Pssst, secret is: {secretName}");


            SecretWord s = new SecretWord(secretName);

            //Console.Clear();
            Console.WriteLine("Guess the secret name:");
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
