using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NameFindLibrary.Test
{
    public class NameFind_Tests
    {
        [Fact]
        public void TriesLeft_CorrectStartCountDefault()
        {
            FindName n = new();
            Assert.Equal(n.TriesLeft, n.MaxTries);
            Assert.True(n.TriesLeft > 0);
        }
        [Fact]
        public void TriesLeft_CorrectStartCountSetValue()
        {
            FindName n = new(25);
            Assert.Equal(n.TriesLeft, n.MaxTries);
            Assert.Equal(25, n.TriesLeft);
        }

        //[Theory]
        //[InlineData('C', false)]
        //[InlineData('M', true)]
        //[InlineData('i', true)]
        //public void GuessDict_KeyFoundStored(char keyEntered, bool isKeyFound_Expected)
        //{
        //    FindName s = new();
        //    Assert.Empty(s.GuessDict);

        //    s.GuessChar(keyEntered);
        //    Assert.Single(s.GuessDict);
        //    s.GuessChar(keyEntered);  // Duplication to make sure no exception is thrown
        //    Assert.Single(s.GuessDict);

        //    bool actual = s.GuessDict[Char.ToUpper(keyEntered)];
        //    Assert.Equal(isKeyFound_Expected, actual);
        //}
    }
}
