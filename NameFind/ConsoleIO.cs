using System;
using System.Collections.Generic;

namespace NameFind
{
    public static class ConsoleIO
    {
        private const string acceptedChars = "abcdefghijklmnopqrstuvwxyzåäö";
        /// <summary>
        /// Halts the thread and prompts the user for a KEY.
        /// </summary>
        /// <param name="prompt">Text to prompt the user with.</param>
        /// <param name="AcceptedChars">A string of accepted characters to accept for input.</param>
        /// <returns>Returns a char entered by the user.</returns>
        public static char GetKey(string prompt = "", string AcceptedChars = acceptedChars)
        {
            char GuessedKey;
            AcceptedChars = AcceptedChars.ToLower();
            Console.Write(prompt);
            do
            {
                GuessedKey = char.ToLower(Console.ReadKey(true).KeyChar);
            } while (!AcceptedChars.Contains(GuessedKey));
            return GuessedKey;
        }

        public static void Write(char c, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(c);
            Console.ForegroundColor = originalColor;
        }
        public static void WriteLine(char c, ConsoleColor color)
        {
            Write(c, color);
            Console.WriteLine();
        }

        public static void WriteCharsRow(Dictionary<char, bool> guessesDict)
        {
            foreach (char c in acceptedChars.ToUpper())
            {
                if (guessesDict.ContainsKey(c))
                {
                    if (guessesDict.TryGetValue(c, out bool value))
                        if (value)
                            Write(c, ConsoleColor.Green);
                        else
                            Write(c, ConsoleColor.Red);
                }
                else
                {
                    Write(c, ConsoleColor.DarkGray);
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prints messages to the Console with a border of '#'
        /// </summary>
        /// <param name="messages">A list of messages to print. Each string in the Array is printed on a separate line.</param>
        public static void PrintMessages(string[] messages, ConsoleColor fColor = ConsoleColor.Gray)
        {
            int MessageMaxLength = GetMaxLengthOfStrings(messages);
            if (MessageMaxLength == 0) return;

            const int BorderCharCount = 2;
            char BorderChar = '#';
            int MaxLengthNeeded = ((BorderCharCount + 1) * 2) + MessageMaxLength;

            Console.WriteLine("\n");
            WriteBorderChars(MaxLengthNeeded, BorderChar, fColor);
            Console.WriteLine();
            foreach (string msg in messages)
            {
                int spaceTaken = msg.Length + (BorderCharCount * 2);
                WriteBorderChars(BorderCharCount, BorderChar, fColor);
                Console.Write(Padding(MaxLengthNeeded, spaceTaken) + msg + Padding(MaxLengthNeeded, spaceTaken, false));
                WriteBorderChars(BorderCharCount, BorderChar, fColor);
                Console.WriteLine();
            }
            WriteBorderChars(MaxLengthNeeded, BorderChar, fColor);
            Console.WriteLine();
        }

        private static void WriteBorderChars(int charCount, char borderChar = '#', ConsoleColor fColor = ConsoleColor.Gray)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = fColor;
            Console.Write(new string(borderChar, charCount));
            Console.ForegroundColor = originalColor;
        }
        private static string Padding(int maxRowLength, int spaceTaken, bool isLeftSide = true)
        {
            double PaddingSpace = (maxRowLength - spaceTaken) / 2.0;
            if (isLeftSide)
            {
                PaddingSpace = Math.Floor(PaddingSpace);
            }
            else
            {
                PaddingSpace = Math.Ceiling(PaddingSpace);
            }
            return new string(' ', (int)PaddingSpace);
        }
        private static int GetMaxLengthOfStrings(string[] messages)
        {
            int LengthToReturn = 0;
            foreach (string msg in messages)
            {
                LengthToReturn = Math.Max(msg.Length, LengthToReturn);
            }
            return LengthToReturn;

        }
    }
}

