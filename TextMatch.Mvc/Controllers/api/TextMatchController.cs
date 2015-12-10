using System.Collections.Generic;
using System.Web.Http;
using TextMatch.Logic.Matchers;

namespace TextMatch.Mvc.Controllers
{
    public class TextMatchController : ApiController
    {
        private ITextMatcher _textMatcher;

        public TextMatchController(ITextMatcher textMatcher)
        {
            _textMatcher = textMatcher;
        }

        /// <summary>
        /// Returns an int array of the possitions of all matches within the given string.
        /// </summary>
        /// <param name="text">The whole string to search though.</param>
        /// <param name="subtext">The sub string to search for</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<int> FindMatches(string text, string subtext)
        {
            return _textMatcher.FindMatches(text, subtext);
        }
    }
}
