﻿using System;
using System.Collections.Generic;

namespace NameFind
{
    public class SecretWord
    {
        private const string ErrorMsgSecretWordEmpty = "Secret word is empty!";
        private const char HiddenChar = '*';
        private string secret = "";
        private string hidden = "";
        private Dictionary<char, bool> guessDict = new Dictionary<char, bool>();

        public SecretWord(string secret)
        {
            if (string.IsNullOrEmpty(secret))
                throw new ArgumentOutOfRangeException(paramName: "secret", message: ErrorMsgSecretWordEmpty, actualValue: "");
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
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess)
                {
                    hidden_chars[i] = guess;
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
