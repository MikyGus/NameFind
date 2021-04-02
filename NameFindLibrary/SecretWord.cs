using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NameFindLibrary
{
    public class SecretWord
    {
        private const char HiddenChar = '*';
        private readonly char[] hiddenWord;
        //public Dictionary<char, bool> GuessDict { get; private set; } = new();
        
        public SecretWord(string secretWord)
        {
            if (string.IsNullOrEmpty(secretWord))
            {
                throw new ArgumentNullException(paramName: "Secret", message: "The secret word is empty!");
            }
            this.Secret = secretWord.ToUpper();
            hiddenWord = new string(HiddenChar,secretWord.Length).ToCharArray();
        }

        public string Secret { get; private set; }
        public string Hidden { get { return new string(hiddenWord); } }
        public bool IsFound { get { return Hidden == Secret; } }

        public bool GuessChar(char guess)
        {
            bool IsFound = false;
            guess = Char.ToUpper(guess);
            string guessStr = Convert.ToString(guess);

            for (int i = 0; i < Secret.Length; i++)
            {
                int cmp = string.Compare(guessStr, Convert.ToString(Secret[i]), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace);
                if (cmp == 0)
                {
                    IsFound = true;
                    hiddenWord[i] = Secret[i];
                }
            }
            
            return IsFound;
        }
    }
}
