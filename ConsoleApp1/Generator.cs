using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Generator
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public string getTestValue(char[] excludeFromArray, int minLength, int maxLength, int minAscii, int maxAscii)
        {
            string testValue = "";
            
            int stringLength = RandomNumber(minLength, maxLength + 1);
                                              
            for (int y = 0; y < stringLength; y++)
            {
                int asciiValue = giveMeANumber(excludeFromArray, minAscii, maxAscii + 1);
                testValue += (char)asciiValue;
            }
            return testValue;
        }

        public Object[] includeSpecialCharactersAsciiRange()
        {
            Object[] obj = new object[3];
            char[] excludeFromArray = new char[0];
            obj[0] = 32;
            obj[1] = 126;
            obj[2] = excludeFromArray;

            return obj;
        }

        public Object[] excludeSpecialCharactersAsciiRange()
        {
            Object[] obj = new object[3];
            char[] excludeFromArray = new char[17];
            excludeFromArray[0] = ':';
            excludeFromArray[1] = ';';
            excludeFromArray[2] = '<';
            excludeFromArray[3] = '=';
            excludeFromArray[4] = '>';
            excludeFromArray[5] = '?';
            excludeFromArray[6] = '@';
            excludeFromArray[7] = '[';
            excludeFromArray[8] = ']';
            excludeFromArray[9] = '\\';
            excludeFromArray[10] = '^';
            excludeFromArray[11] = '_';
            excludeFromArray[12] = '`';
            excludeFromArray[13] = '{';
            excludeFromArray[14] = '}';
            excludeFromArray[15] = '~';
            excludeFromArray[16] = '|';
            obj[0] = 48;
            obj[1] = 126;
            obj[2] = excludeFromArray;


            return obj;
        }

        public int giveMeANumber(char[] excludeArray, int min, int max)
        {
            var exclude = new HashSet<int>(Array.ConvertAll(excludeArray, c => (int)c));
            var range = Enumerable.Range(min, max-min).Where(i => !exclude.Contains(i));

            int index = RandomNumber(0, max-min - exclude.Count);
            return range.ElementAt(index);
        }

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
