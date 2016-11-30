using System.Collections.Generic;
using TextMatch.Domain.Interfaces.Services.Matchers;

namespace TextMatch.Internals.Services.Matchers
{
    public class TextMatcher : ITextMatcher
    {
        private int _currentIndexText = 0;
        private int _currentIndexSubtext = 0;

        private string _text;
        private string _subtext;

        private List<int> _matches = new List<int>();

        public int[] FindMatches(string text = null, string subtext = null)
        {
            this.WithText(text).WithSubText(subtext);

            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext)) { return new int[] { }; }

            _matches = new List<int>();
            _text = text.ToLower();
            _subtext = subtext.ToLower();

            while (IsIndexLessThanLengthOfText(_currentIndexText + _currentIndexSubtext, _text))
            {
                CompareCharacters(_subtext[_currentIndexSubtext], _text[_currentIndexText + _currentIndexSubtext]);
            }

            return _matches.ToArray();
        }

        /// <summary>
        /// Compares each char individually.
        /// </summary>
        /// <param name="c1">The first character to compare</param>
        /// <param name="c2">The second character to compare</param>
        private void CompareCharacters(char c1, char c2)
        {
            if (c1 == c2)
            {
                if (IsIndexAtEndOfString(_currentIndexSubtext, _subtext))
                {
                    _matches.Add(_currentIndexText + 1); //because the spec is base index 1, not base 0
                    MoveToNextPossitionInText();
                }
                else
                {
                    MoveToNextPossitionInSubtext();
                }
            }
            else
            {
                MoveToNextPossitionInText();
            }
        }

        private bool IsIndexAtEndOfString(int index, string text)
        {
            return index == text.Length - 1;
        }

        private void MoveToNextPossitionInText()
        {
            _currentIndexSubtext = 0;
            _currentIndexText++;
        }

        private void MoveToNextPossitionInSubtext()
        {
            _currentIndexSubtext++;
        }
        
        private bool IsIndexLessThanLengthOfText(int index, string text)
        {
            return index < text.Length;
        }

        public ITextMatcher WithText(string text)
        {
            this._text = text;
            return this;
        }

        public ITextMatcher WithSubText(string subText)
        {
            this._subtext = subText;
            return this;
        }
    }
}
