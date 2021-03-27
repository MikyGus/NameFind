using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NameFind.Test
{
    [TestClass]
    public class SecretWord_Tests
    {

        [DataTestMethod]
        [DataRow("Mikael", "******")]
        [DataRow("Bob", "***")]
        public void Create_HiddenWord_Stars(string hiddenWord, string starString_expected)
        {
            SecretWord s = new SecretWord(hiddenWord);
            Assert.AreEqual(starString_expected, s.Hidden);
        }

        [TestMethod]
        public void Create_EmptyName_ThrowArgumentOutOfRangeException()
        {
            AssertThrows<ArgumentOutOfRangeException>(delegate
            {
                SecretWord s = new SecretWord("");
            });
        }

        [TestMethod]
        public void Create_NullName_ThrowArgumentOutOfRangeException()
        {
            AssertThrows<ArgumentOutOfRangeException>(delegate
            {
                SecretWord s = new SecretWord(null);
            });
        }

        [DataTestMethod]
        [DataRow("Mikael", 'A', true, "***A**")]
        [DataRow("Mikael", 'K', true, "**K***")]
        [DataRow("Mikael", 'k', true, "**K***")]
        [DataRow("Mikael", 'O', false, "******")]
        [DataRow("André", 'E', true, "****É")]
        [DataRow("Bob", 'B', true, "B*B")]
        public void GuessChar_KeyEntered_HiddenStars(string hiddenWord, char keyEntered, bool isKeyFound_expected, string starString_expected)
        {
            SecretWord s = new SecretWord(hiddenWord);
            bool b = s.GuessChar(keyEntered);
            Assert.AreEqual(starString_expected, s.Hidden);
            Assert.AreEqual(isKeyFound_expected, b);
        }

        //// Check to make sure the hidden word is NOT found until all of the words characters have been entered.
        [DataTestMethod]
        [DataRow("Mikael", "MIKAEL", "FFFFFT")]
        [DataRow("Bob", "BO", "FT")]
        public void GuessChar_KeyEntered_isHiddenFound(string hiddenWord, string keysEntered, string isWordFound_expected)
        {
            SecretWord s = new SecretWord(hiddenWord);
            for (int i = 0; i < keysEntered.Length; i++)
            {
                s.GuessChar(keysEntered[i]);
                Assert.AreEqual((isWordFound_expected[i] == 'T'), s.IsFound, $"Tested char: { keysEntered[i] } at index { i } expected { isWordFound_expected[i] }");
            }
        }

        [DataTestMethod]
        [DataRow('A', true)]
        [DataRow('K', true)]
        [DataRow('O', false)]
        public void GuessDictionary_KeyKonMikael_isDictionaryKeyKValue(char keyEntered, bool isKeyFound_expected)
        {
            SecretWord s = new SecretWord("Mikael");
            Assert.AreEqual(0, s.GuessDict.Count);
            s.GuessChar(keyEntered);
            s.GuessChar(keyEntered); //Dublicate: To make sure it doesn't throw an exception
            Assert.AreEqual(1, s.GuessDict.Count);
            bool value;
            Assert.IsTrue(s.GuessDict.TryGetValue(keyEntered, out value));
            Assert.AreEqual(isKeyFound_expected, value);
        }

        internal static void AssertThrows<exception>(Action method)
                                    where exception : Exception
        {
            try
            {
                method.Invoke();
            }
            catch (exception)
            {
                return; // Expected exception.
            }
            catch (Exception ex)
            {
                Assert.Fail("Wrong exception thrown: " + ex.Message);
            }
            Assert.Fail("No exception thrown");
        }
    }
}
