using System;
using System.IO;
using NameFindLibrary;

namespace NameFind
{

    class Program
    {
        static void Main()
        {
            NameFindLibrary.FindName nameFind = new();
            char GuessedKey;

            Console.Clear();
            Console.WriteLine("Guess the secret name:");

            do
            {
                ConsoleIO.WriteCharsRow(nameFind.GuessDict);
                string Prompt = $"Name: {nameFind.Hidden}, Tries left: {nameFind.TriesLeft} >";
                GuessedKey = ConsoleIO.GetKey(prompt: Prompt);
                if (nameFind.GuessChar(GuessedKey))
                    ConsoleIO.WriteLine(char.ToUpper(GuessedKey), ConsoleColor.Green);
                else
                    ConsoleIO.WriteLine(char.ToUpper(GuessedKey), ConsoleColor.Red);

            } while (!nameFind.IsGameOver);

            if (nameFind.IsSecretFound)
            {
                ConsoleIO.PrintMessages(nameFind.GameOverMessage, ConsoleColor.Green);
            }
            else
            {
                ConsoleIO.PrintMessages(nameFind.GameOverMessage, ConsoleColor.Red);
            }
        }
    }
}
