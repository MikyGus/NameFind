using System;
using Xunit;

namespace NameFindLibrary.Test
{
    public class WordFile_Tests
    {
        [Theory]
        [InlineData(@"",@"Names.txt")]
        [InlineData(@"C:\Users\taxi3\source\repos\NameFind\NameFindLibrary.Test\bin\Debug\net5.0\", @"Names.txt")]
        [InlineData(@"C:\Users\taxi3\source\repos\NameFind\NameFindLibrary.Test\bin\Debug\net5.0", @"Names.txt")]
        public void FullFilePath_Valid(string filePath, string fileName)
        {
            WordFile s = new()
            {
                FilePath = filePath,
                FileName = fileName
            };
            Assert.True(s.IsValidFullFilePath);
        }

        [Theory]
        [InlineData(@"", @"NonExistingFile.txt")]
        [InlineData(@"", @"")]
        public void FullFilePath_InValid(string filePath, string fileName)
        {
            WordFile s = new()
            {
                FilePath = filePath,
                FileName = fileName
            };
            Assert.False(s.IsValidFullFilePath);
        }

        [Fact]
        public void GetWordList_SuccessfullyGetsListOfNames()
        {
            WordFile s = new WordFile();
            string[] actual_list = s.GetWordList();
            Assert.True(actual_list.Length > 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("InvalidTextfile.txt")]
        public void GetWordList_ThrowEceptionInvalidFilePath(string fileName)
        {
            WordFile s = new WordFile()
            {
                FilePath = "",
                FileName = fileName
            };
            var ex = Assert.Throws<ArgumentException>(() => s.GetWordList());
            Assert.Equal("InvalidFilePath", ex.ParamName);
        }

        [Fact]
        public void GetRandomWord_SuccessfullyGetRandomWordFromList()
        {
            WordFile s = new WordFile();
            string[] Words = s.GetWordList();
            string actual = s.GetRandomWord();
            Assert.False(string.IsNullOrEmpty(actual));
            Assert.Contains(actual, Words);
        }

        [Fact]
        public void GetRandomWord_DifferentRandomWord()
        {
            WordFile s = new WordFile();
            string word1 = s.GetRandomWord();
            string word2 = s.GetRandomWord();
            Assert.NotEqual(word1, word2);
        }

        //[Fact]
        //public void SecretWordFile_SuccessfullyGetsRandomWord()
        //{
        //    SecretWordFile s = new SecretWordFile();
        //    string actual_word = s.GetWord();
        //    Assert.True(actual_word.Length > 0);
        //}

        //[Theory]
        //[InlineData(3)]
        //[InlineData(5)]
        //[InlineData(6)]
        //public void MyFirstTheory(int value)
        //{
        //    Assert.True(IsOdd(value));
        //}

        //bool IsOdd(int value)
        //{
        //    return value % 2 == 1;
        //}
    }
}
