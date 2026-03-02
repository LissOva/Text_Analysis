using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Model
{
    public class AnalysisResult
    {
        public string Title { get; set; }
        public List<WordCount> TopWords { get; set; }
        public int TotalWords { get; set; }
        public int UniqueWords { get; set; }
        public double UniqueWordsPercentage { get; set; }
    }
}
