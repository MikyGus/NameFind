using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameFind.Test
{
    [TestClass]
    class SecretWordFile
    {
        [DataTestMethod]
        [DataRow("Mikael", "******")]
        [DataRow("Bob", "***")]
        public void IWantThisToRund(string hiddenWord, string starString_expected)
        {
            SecretWord s = new SecretWord(hiddenWord);
            Assert.AreEqual(starString_expected, s.Hidden);
        }
    }
}
