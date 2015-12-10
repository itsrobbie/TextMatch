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

        [HttpGet]
        public IEnumerable<int> FindMatches(string text, string subtext)
        {
            return _textMatcher.FindMatches(text, subtext);
        }
    }
}
