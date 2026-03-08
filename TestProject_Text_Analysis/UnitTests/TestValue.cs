using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject_Text_Analysis.UnitTests
{
    internal class TestValue
    {
        public static Dictionary<string, int> oneWordDictionary = new Dictionary<string, int>
            {
                { "a", 1 }
            };
        public static List<KeyValuePair<string, int>> oneWordList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("a", 1),
            };

        public static Dictionary<string, int> twoWordsDictionary = new Dictionary<string, int>
            {
                { "a", 1 },
                { "b", 2 }
            };
        public static List<KeyValuePair<string, int>> twoWordList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("b", 2),
                new KeyValuePair<string, int>("a", 1)
            };

        public static Dictionary<string, int> sameValueDictionary = new Dictionary<string, int>
            {
                { "a", 5 },
                { "b", 5 },
                { "c", 5 }
            };
        public static List<KeyValuePair<string, int>> sameValueList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("a", 5),
                new KeyValuePair<string, int>("b", 5),
                new KeyValuePair<string, int>("c", 5)
            };

        public static Dictionary<string, int> reversedDictionary = new Dictionary<string, int>
            {
                { "a", 1 },
                { "b", 2 },
                { "c", 3 },
                { "d", 4 },
                { "e", 5 },
                { "f", 6 },
                { "g", 7 },
                { "h", 8 },
                { "i", 9 },
                { "j", 10 }
            };
        public static List<KeyValuePair<string, int>> reversedList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("j", 10),
                new KeyValuePair<string, int>("i", 9),
                new KeyValuePair<string, int>("h", 8),
                new KeyValuePair<string, int>("g", 7),
                new KeyValuePair<string, int>("f", 6),
                new KeyValuePair<string, int>("e", 5),
                new KeyValuePair<string, int>("d", 4),
                new KeyValuePair<string, int>("c", 3),
                new KeyValuePair<string, int>("b", 2),
                new KeyValuePair<string, int>("a", 1)
            };

        public static Dictionary<string, int> normalDictionary = new Dictionary<string, int>
            {
                { "apple", 5 },
                { "banana", 10 },
                { "cherry", 3 },
                { "date", 9 },
                { "elderberry", 8 }
            };

        public static List<KeyValuePair<string, int>> normalList = new List<KeyValuePair<string, int>>
            {
            new KeyValuePair<string, int>("banana", 10 ),
            new KeyValuePair<string, int>("date", 9),
            new KeyValuePair<string, int>("elderberry", 8),
            new KeyValuePair<string, int>("apple", 5),
            new KeyValuePair<string, int>("cherry", 3),
            };

        public static Dictionary<string, int> GenerateLargeDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < 1000; i++)
            {
                dictionary.Add(new string('i', i), i);
            }
            return dictionary;
        }

    }
}
