using System;
using TextMatch.Logic.Matchers;

namespace TextMatch.Logic.Tests.Builders
{
    class TextMatcherBuilder
    {
        private string text;
        private string subText;

        public TextMatcher Build()
        {
            return new TextMatcher().WithText(this.text).WithSubText(this.subText);
        }

        public  TextMatcherBuilder WithFourSequencesInTheText()
        {
            return this.WithText("Four four four four").WithSubText("four");
        }

        private TextMatcherBuilder WithText(string text)
        {
            this.text = text;
            return this;
        }

        private TextMatcherBuilder WithSubText(string subText)
        {
            this.subText = subText;
            return this;
        }
    }
}
