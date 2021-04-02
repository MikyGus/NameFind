using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameFindLibrary
{
    public class FindName
    {
        private readonly int maxTries;
        public int MaxTries { get { return maxTries; } }
        public int TriesLeft { get; private set; }
        public Dictionary<char, bool> GuessDict { get; private set; } = new();
        private SecretWord secret { get; set; }
        public string Secret { get { return secret.Secret; } }
        public string Hidden { get { return secret.Hidden; } }
        public bool IsGameOver 
        { 
            get { return IsSecretFound || (TriesLeft <= 0); } 
        }
        public bool IsSecretFound { get { return (Hidden == Secret); } }
        public string[] GameOverMessage
        {
            get
            {
                if (IsSecretFound)
                {
                    string[] Message = {
                        "CONGRATUALTIONS! YOU FOUND THE SECRET NAME!",
                        $"THE SECRET NAME WAS: {Secret}"
                    };
                    return Message;
                }
                else
                {
                    string[] Message = {
                        "YOU FAILED TO FIND THE SECRET NAME!",
                        $"THE SECRET NAME WAS: {Secret}"
                    };
                    return Message;
                }
            }
        }

        public FindName(int maximumTries = 10)
        {
            this.maxTries = maximumTries;
            this.TriesLeft = maximumTries;

            WordFile f = new();
            string secret = f.GetRandomWord();
            this.secret = new(secret);
        }

        public bool GuessChar(char guessChar)
        {
            guessChar = Char.ToUpper(guessChar);
            bool IsFound = secret.GuessChar(guessChar);
            if (!IsFound)
                TriesLeft--;
            GuessDict.TryAdd(guessChar, IsFound);
            return IsFound;
        }


        
    }
}
