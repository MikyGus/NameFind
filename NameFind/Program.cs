﻿using System;
using System.IO;
using NameFindLibrary;

namespace NameFind
{

    class Program
    {
        static void Main(string[] args)
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
            //WordFile secretWordFile = new()
            //{
            //    FileName = @"Names.txt"
            //};
            //string secretName = secretWordFile.GetRandomWord();
            //var rand = new Random();
            //const string filePath = @"Names.txt";
            //if (!File.Exists(filePath))
            //{
            //    Console.WriteLine($"File: {filePath}, not found!");
            //    return 1;
            //}
            //string[] NameList = File.ReadAllLines(filePath);
            //char GuessedKey;
            //int tries = 10;
            //string secretName = NameList[rand.Next(NameList.Length)];

            //Console.WriteLine($"Pssst, secret is: {secretName}");

            //SecretWord s = new(secretName);

            //Console.Clear();
            //Console.WriteLine("Guess the secret name:");
            //do
            //{
            //    ConsoleIO.WriteCharsRow(s.GuessDict);
            //    string Prompt = $"Name: {s.Hidden}, Tries left: {tries} >";
            //    GuessedKey = ConsoleIO.GetKey(prompt: Prompt);
            //    if (s.GuessChar(GuessedKey))
            //        ConsoleIO.WriteLine(char.ToUpper(GuessedKey), ConsoleColor.Green);
            //    else
            //    {
            //        ConsoleIO.WriteLine(char.ToUpper(GuessedKey), ConsoleColor.Red);
            //        tries--;
            //    }

            //} while (!s.IsFound && tries > 0);

            //if (s.IsFound)
            //{
            //    string[] Message = {
            //        "CONGRATUALTIONS! YOU FOUND THE SECRET NAME!",
            //        $"THE SECRET NAME WAS: {s.Secret}"
            //    };
            //    ConsoleIO.PrintMessages(Message, ConsoleColor.Green);
            //}
            //else
            //{
            //    string[] Message = {
            //        "YOU FAILED TO FIND THE SECRET NAME!",
            //        $"THE SECRET NAME WAS: {s.Secret}"
            //    };
            //    ConsoleIO.PrintMessages(Message, ConsoleColor.Red);
            //}
            //return 0;
        }
    }
}
