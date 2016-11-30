using NUnit.Framework;
using TextMatch.Tests.Internals.Builders;

namespace TextMatch.Tests.Internals.Services.Matchers
{
    [TestFixture]
    public class TextMatcherNunit
    {
        private readonly TextMatcherBuilder matcherBuilder = new TextMatcherBuilder();

        [TestCase("", "Test", 0)]
        [TestCase("Test", "", 0)]
        [TestCase("Test", "Fail", 0)]
        [TestCase("Test", "Test", 1)]
        [TestCase("TestTestTest", "Test", 3)]
        [TestCase("TestTESTtest", "Test", 3)]
        public void FindMatches_WithVariosInputs_ReturnsCorrectNumberOfResults(string text, string subtext, int matches)
        {
            //assign 
            var matcher = this.matcherBuilder.Build();

            //act
            var result = matcher.FindMatches(text, subtext);

            //assert
            Assert.AreEqual(matches, result.Length);
        }

        [TestCase]
        public void FindMatches_WithTextInput_ReturnsArrayWithCorrectPossitions()
        {
            //assign 
            var matcher = this.matcherBuilder.Build();

            //act
            var result = matcher.FindMatches("Test TEST test", "test");

            //assert
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(6, result[1]);
            Assert.AreEqual(11, result[2]);
        }

        [TestCase]
        public void BuilderMethods_UsingFluidBuilder_ReturnsCorrectMatches()
        {
            //assign 
            var matcher = this.matcherBuilder.WithFourSequencesInTheText().Build();

            //act
            var result = matcher.FindMatches("Test TEST test", "test");

            //assert
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(6, result[1]);
            Assert.AreEqual(11, result[2]);
        }
    }
}
