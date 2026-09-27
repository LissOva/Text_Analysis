using System;
using FsCheck.Xunit;
using Text_Analysis.Services;

namespace Text_Analysis.Tests
{
    public class FuzzingTests
    {
        // 1. Фаззинг модуля CleanText (поиск NullReferenceException / CWE-476)
        [Property(MaxTest = 1000)]
        public bool Fuzz_CleanText_Property(string? input)
        {
            string? testInput = input != null && input.Length % 2 == 0 ? null : input;

            TextAnalysisService.CleanText(testInput!);
            return true;
        }

        // 2. Фаззинг модуля GetUniqWordPercent (поиск DivideByZeroException / CWE-369)
        [Property(MaxTest = 1000)]
        public bool Fuzz_GetUniqWordPercent_Property(double total, double uniq)
        {
            TextAnalysisService.GetUniqWordPercent(total, uniq);
            return true;
        }
    }
}