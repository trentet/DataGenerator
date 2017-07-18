using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Generator c = new Generator();
            int minLength = 0;
            int maxLength = 21;
            Object[] set = c.ExcludeSpecialCharactersAsciiRange(); //excludes special characters
            //Object[] set = c.IncludeSpecialCharactersAsciiRange(); //includes special characters

            int minAscii = (int)set[0];
            int maxAscii = (int)set[1];
            char[] excludeFromArray = (char[])set[2];
            int numberOfValues = 50;
            List<string> testValues = new List<string>();
            
            for (int x = 0; x < numberOfValues; x++)
            {
                string testValue = c.GetTestValue(excludeFromArray, minLength, maxLength, minAscii, maxAscii);
                testValues.Add(testValue);
            }

            string csv = String.Join(",", testValues.Select(x => x.ToString()).ToArray());

            testValues.Sort();
            int y = 0;
            foreach (string testValue in testValues)
            {
                Console.WriteLine("#" + (y + 1) + ": " + testValue);
                y++;
            }
            File.WriteAllLines("D:\\text.csv", testValues.Select(x => string.Join(",", x)));
        }
    }
}
