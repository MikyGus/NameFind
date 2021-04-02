using System;
using System.Collections.Generic;
using System.Globalization;

namespace NameFind
{
    public class SecretWord
    {
        private const string ErrorMsgSecretWordEmpty = "Secret word is empty!";
        private const char HiddenChar = '*';
        private readonly string secret = "";
        private string hidden = "";
        private readonly Dictionary<char, bool> guessDict = new();

        public SecretWord(string secret)
        {
            if (string.IsNullOrEmpty(secret))
                throw new ArgumentOutOfRangeException(paramName: nameof(secret), message: ErrorMsgSecretWordEmpty, actualValue: "");
            this.secret = secret.ToUpper();
            this.hidden = new string(HiddenChar, secret.Length);
        }

        public string Secret { get { return secret; } }

        public string Hidden { get { return hidden; } }

        public bool IsFound { get { return secret == hidden; } }

        public bool GuessChar(char guess)
        {
            char[] hidden_chars = hidden.ToCharArray();
            guess = char.ToUpper(guess);
            bool isFound = false;
            string guessStr = Convert.ToString(guess);
            for (int i = 0; i < secret.Length; i++)
            {
                if (string.Compare(guessStr, Convert.ToString(secret[i]), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0)
                {
                    hidden_chars[i] = secret[i];
                    isFound = true;
                }
            }
            hidden = new string(hidden_chars);

            guessDict.TryAdd(guess, isFound);
            return isFound;
        }

        public Dictionary<char, bool> GuessDict { get { return guessDict; } }
    }
}
