using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatch.Internals.Services.Matchers;

namespace TextMatch.Tests.Internals.Services.Matches
{
    /*
        Used with TDD to create my matching algorithm.

        NB. Naming convention for tests methods: {Method to test}_{what we are doing}_{what we are expecting}
        e.g. FindMatches_PassAnEmptyStringForText_ReturnAnEmptyArray
    */

    [TestClass]
    public class TextMatcherTests
    {
        private ITextMatcher _textMatcher;

        [TestInitialize]
        public void Setup()
        {
            _textMatcher = new TextMatcher();
        }

        //Business Logic: If the 'Text' field is ever empty, assume no matches
        [TestMethod]
        public void FindMatches_PassEmptyStringForText_ReturnEmptyArray()
        {
            //assign

            //act
            var result = _textMatcher.FindMatches(string.Empty, "Test");

            //asert
            Assert.AreEqual(0, result.Length);
        }

        //Business logic: If the 'SubText' field is ever empty, assume no matches
        [TestMethod]
        public void FindMatches_PassEmptyStringForSubText_ReturnEmptyArray()
        {
            //assign

            //act
            var result = _textMatcher.FindMatches("Test", string.Empty);

            //asert
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void FindMatches_PassSubtextThatDoesNotExistInText_ReturnEmptyArray()
        {
            //assign

            //act
            var result = _textMatcher.FindMatches("Test", "Fail");

            //asert
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void FindMatches_PassSameTextAsSubtext_ReturnArrayWithOneItemAtPossitionOne()
        {
            //assign
            var text = "Test";

            //act
            var result = _textMatcher.FindMatches(text, text);

            //asert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void FindMatches_TextIsThreeLotsOfSubtext_ReturnArrayWithThreeItemsAtCorrectPossitions()
        {
            //assign
            var subtext = "Test";
            var text = string.Join(string.Empty, subtext, subtext, subtext);

            //act
            var result = _textMatcher.FindMatches(text, subtext);

            //asert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(5, result[1]);
            Assert.AreEqual(9, result[2]);
        }

        [TestMethod]
        public void FindMatches_TextIsUppercaseAndLowerCaseAndMixedOfSubtext_ReturnArrayWithThreeItemsAtCorrectPossitions()
        {
            //assign
            var subtext = "Test";
            var text = string.Join(string.Empty, subtext.ToUpper(), subtext, subtext.ToLower());

            //act
            var result = _textMatcher.FindMatches(text, subtext);

            //asert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(5, result[1]);
            Assert.AreEqual(9, result[2]);
        }



        #region Test cases as defined in spec sheet
        private string testString = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";

        [TestMethod]
        public void FindMatches_UseDefinedTestStringAndPollyAsSubstring_ExpectThreeMatches()
        {
            //assign
            var subtext = "Polly";

            //act
            var result = _textMatcher.FindMatches(testString, subtext);

            //assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(26, result[1]);
            Assert.AreEqual(51, result[2]);
        }

        [TestMethod]
        public void FindMatches_UseDefinedTestStringAndEllEllAsSubstring_ExpectFiveMatches()
        {
            //assign
            var subtext = "ll";

            //act
            var result = _textMatcher.FindMatches(testString, subtext);

            //assert
            Assert.AreEqual(5, result.Length);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(28, result[1]);
            Assert.AreEqual(53, result[2]);
            Assert.AreEqual(78, result[3]);
            Assert.AreEqual(82, result[4]);
        }

        [TestMethod]
        public void FindMatches_UseDefinedTestStringAndXAsSubstring_ExpectNoMatches()
        {
            //assign
            var subtext = "X";

            //act
            var result = _textMatcher.FindMatches(testString, subtext);

            //assert
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void FindMatches_UseDefinedTestStringAndPolxAsSubstring_ExpectNoMatches()
        {
            //assign
            var subtext = "Polx";

            //act
            var result = _textMatcher.FindMatches(testString, subtext);

            //assert
            Assert.AreEqual(0, result.Length);
        }

        #endregion
    }
}
