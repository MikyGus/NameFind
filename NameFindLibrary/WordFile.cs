using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameFindLibrary
{
    public class WordFile
    {
        public string FilePath { get; set; } = ""; //Default is same directory as the executable
        public string FileName { get; set; } = "Names.txt";
        public string FullFilePath { 
            get {
                if (string.IsNullOrEmpty(FileName))
                    return "";
                else if (string.IsNullOrEmpty(FilePath))
                    return Path.GetFullPath(FileName);
                else
                    return Path.GetFullPath(FileName, FilePath);
            } 
        }
        public bool IsValidFullFilePath { get { return File.Exists(this.FullFilePath); } }

        public string[] GetWordList()
        {
            if (!IsValidFullFilePath)
            {
                throw new ArgumentException(paramName: "InvalidFilePath", message: $"File cannot be loaded at location: {this.FullFilePath}");
            }
            string[] Output = File.ReadAllLines(this.FullFilePath);
            return Output;
        }

        public string GetRandomWord()
        {
            string[] Words = GetWordList();
            var rand = new Random();
            return Words[rand.Next(Words.Length)];
        }





            //var rand = new Random();
            //const string filePath = @"Names.txt";
            //if (!File.Exists(filePath))
            //{
            //    Console.WriteLine($"File: {filePath}, not found!");
            //    return 1;
            //}
            //string[] NameList = File.ReadAllLines(filePath);
            //char GuessedKey;
            //int tries = 10;
            //string secretName = NameList[rand.Next(NameList.Length)];
    }
}
