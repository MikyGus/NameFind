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
    }
}
