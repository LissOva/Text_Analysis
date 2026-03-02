using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Model
{
    public class WordCount
    {
        public string Word { get; set; }
        public int Count { get; set; }

        public WordCount(string word, int count)
        {
            this.Word = word;
            this.Count = count; 
        }
    }
}
