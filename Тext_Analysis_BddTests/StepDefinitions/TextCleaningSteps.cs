using Reqnroll;
using Text_Analysis.Services;
using Xunit;

namespace Text_Analysis_BddTests.StepDefinitions
{
    [Binding]
    public class TextCleaningSteps
    {
        private string _rawText = string.Empty;
        private string _cleanedText = string.Empty;

        [Given(@"сервис очистки текста инициализирован")]
        public void GivenServiceInitialized()
        {
            _rawText = string.Empty;
            _cleanedText = string.Empty;
        }

        [When(@"пользователь отправляет на анализ текст ""(.*)""")]
        public void WhenUserSendsText(string text)
        {
            _rawText = text;
            _cleanedText = TextAnalysisService.CleanText(_rawText);
        }

        [Then(@"в результате очистки должен остаться только текст ""(.*)""")]
        public void ThenCleanedTextShouldBe(string expectedText)
        {
            Assert.Equal(expectedText, _cleanedText);
        }
    }
}