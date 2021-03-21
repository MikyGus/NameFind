using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameFind;
using System;

namespace NameFind.Test
{
    [TestClass]
    public class SecretWord_Tests
    {
        [TestMethod]
        public void Create_HiddenWordMikael_6stars()
        {
            SecretWord s = new SecretWord("Mikael");
            Assert.AreEqual("******", s.Hidden);
        }

        [TestMethod]
        public void Create_HiddenWordBob_3stars()
        {
            SecretWord s = new SecretWord("Bob");
            Assert.AreEqual("***", s.Hidden);
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

        [TestMethod]
        public void GuessChar_KeyAonMikael_HiddenSSSASS()
        {
            SecretWord s = new SecretWord("Mikael");
            bool b = s.GuessChar('A');
            Assert.AreEqual("***A**", s.Hidden);
            Assert.IsTrue(b);
        }
        [TestMethod]
        public void GuessChar_KeyKonMikael_HiddenSSKSSS()
        {
            SecretWord s = new SecretWord("Mikael");
            bool b = s.GuessChar('K');
            Assert.AreEqual("**K***", s.Hidden);
            Assert.IsTrue(b);
        }
        [TestMethod]
        public void GuessChar_KeykonMikael_HiddenSSKSSS()
        {
            SecretWord s = new SecretWord("Mikael");
            bool b = s.GuessChar('k');
            Assert.AreEqual("**K***", s.Hidden);
            Assert.IsTrue(b);
        }
        [TestMethod]
        public void GuessChar_KeyOonMikael_HiddenSSSSSS()
        {
            SecretWord s = new SecretWord("Mikael");
            bool b = s.GuessChar('O');
            Assert.AreEqual("******", s.Hidden);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public void GuessChar_KeyMonMikael_ISFoundFalse()
        {
            SecretWord s = new SecretWord("Mikael");
            bool b = s.GuessChar('M');
            Assert.AreEqual("M*****", s.Hidden);
            Assert.IsTrue(b);
            Assert.IsFalse(s.IsFound);
        }
        [TestMethod]
        public void GuessChar_KeyMIKAELonMikael_ISFoundTrue()
        {
            SecretWord s = new SecretWord("Mikael");
            s.GuessChar('M');
            s.GuessChar('I');
            s.GuessChar('K');
            s.GuessChar('A');
            s.GuessChar('E');
            s.GuessChar('L');
            Assert.AreEqual("MIKAEL", s.Hidden);
            Assert.IsTrue(s.IsFound);
        }

        [TestMethod]
        public void GuessDictionary_NoKeyonMikael_EmptyDictionary()
        {
            SecretWord s = new SecretWord("Mikael");
            Assert.AreEqual(0, s.GuessDict.Count);
        }
        [TestMethod]
        public void GuessDictionary_KeyKonMikael_DictionaryKeyKValueTrue()
        {
            SecretWord s = new SecretWord("Mikael");
            s.GuessChar('K');
            s.GuessChar('K'); //To make sure it doesn't throw an exception
            Assert.AreEqual(1, s.GuessDict.Count);
            bool value;
            Assert.IsTrue(s.GuessDict.TryGetValue('K', out value));
            Assert.IsTrue(value);
        }
        [TestMethod]
        public void GuessDictionary_KeyOonMikael_DictionaryKeyOValueFalse()
        {
            SecretWord s = new SecretWord("Mikael");
            s.GuessChar('O');
            s.GuessChar('O'); //To make sure it doesn't throw an exception
            Assert.AreEqual(1, s.GuessDict.Count);
            Assert.IsTrue(s.GuessDict.TryGetValue('O', out bool value));
            Assert.IsFalse(value);
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
