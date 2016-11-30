using System.Collections.Generic;

namespace TextMatch.Domain.Interfaces.Services.Matchers
{
    public interface ITextMatcher
    {
        /// <summary>
        /// An implementation of the famous kmp search algorithm. 
        /// It searches for the number of occurences of <code>subtext</code> in <code>text</code>, 
        /// and returns these possitions in an integer array. 
        /// 
        /// Logic:
        /// If either parameters are empty, an empty array is returned.
        /// The indexes returned are base 1, not 0 based
        /// The search algorithm is not case sensitive
        /// 
        /// </summary>
        /// <param name="text">The whole text to search through.</param>
        /// <param name="subtext">The sub text to search for, inside <code>text</code></param>
        /// <returns>An integer array, containing all possitions of <code>subtext</code> in <code>text</code>.</returns>
        IEnumerable<int> FindMatches(string text = null, string subtext = null);

        /// <summary>
        /// Sets the value of the text to search though.
        /// </summary>
        /// <param name="text">The text to search through.</param>
        /// <returns>This text matcher.</returns>
        ITextMatcher WithText(string text);

        /// <summary>
        /// Sets the value of the text to search for.
        /// </summary>
        /// <param name="subText">The value of the text to search for.</param>
        /// <returns>This matcher.</returns>
        ITextMatcher WithSubText(string subText);
    }
}
