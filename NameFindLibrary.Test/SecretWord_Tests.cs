using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NameFindLibrary.Test
{
    public class SecretWord_Tests
    {
        [Theory]
        [InlineData("Mikael", "******")]
        [InlineData("Bob", "***")]
        public void HiddenWord_Stars(string secretWord, string hiddenStr_Expected)
        {
            SecretWord s = new(secretWord);
            string actual = s.Hidden;
            Assert.Equal(hiddenStr_Expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SecretWord_WordEmpty_ThrowArgumentException(string secretWord)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new SecretWord(secretWord));
            Assert.Equal("Secret", ex.ParamName);
        }

        [Theory]
        [InlineData('M', true)]
        [InlineData('m', true)]
        [InlineData('R', false)]
        [InlineData('A', true)]
        [InlineData('a', true)]
        public void GuessChar_FindCharInSecretWord(char guessChar, bool find_Expected)
        {
            SecretWord s = new("Mikael");
            bool actual = s.GuessChar(guessChar);
            Assert.Equal(find_Expected, actual);
        }

        [Theory]
        [InlineData("Mikael", 'M', "M*****")]
        [InlineData("Mikael", 'm', "M*****")]
        [InlineData("Bob", 'B', "B*B")]
        [InlineData("EÉèê", 'E', "EÉÈÊ")]
        [InlineData("åäaÅÄA", 'A', "**A**A")]
        public void GuessChar_SuccessfullyRevealHiddenWord(string secretWord, char guessChar, string hiddenWord_Expected)
        {
            SecretWord s = new(secretWord);
            s.GuessChar(guessChar);
            string actual = s.Hidden;
            Assert.Equal(hiddenWord_Expected, actual);
        }

        [Theory]
        [InlineData('É', 'E')]
        [InlineData('Ä', 'Ä')]
        public void GuessChar_SuccessfullyFindSpecialCharacter(char specialChar, char keyEntered)
        {
            SecretWord s = new(Convert.ToString(specialChar));
            bool actual = s.GuessChar(keyEntered);
            Assert.True(actual);
        }

        [Theory]
        [InlineData("Mikael", "MIKAEL", "FFFFFT")]
        [InlineData("Bob", "OB", "FT")]
        public void IsFound_CanDetermineIfSecretIsFound(string hiddenWord, string enteredKeys, string expected)
        {
            SecretWord s = new(hiddenWord);
            Assert.False(s.IsFound);

            for (int i = 0; i < enteredKeys.Length; i++)
            {
                s.GuessChar(enteredKeys[i]);
                Assert.Equal(expected[i] == 'T', s.IsFound);
            }
        }

        [Theory]
        [InlineData('C', false)]
        [InlineData('M', true)]
        [InlineData('i', true)]
        public void GuessDict_KeyFoundStored(char keyEntered, bool isKeyFound_Expected)
        {
            SecretWord s = new("Mikael");
            Assert.Empty(s.GuessDict);

            s.GuessChar(keyEntered);
            Assert.Single(s.GuessDict);
            s.GuessChar(keyEntered);  // Duplication to make sure no exception is thrown
            Assert.Single(s.GuessDict);

            bool actual = s.GuessDict[Char.ToUpper(keyEntered)];
            Assert.Equal(isKeyFound_Expected, actual); 
        }

    }
}
