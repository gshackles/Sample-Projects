using System;
using System.Linq;

namespace IoCDemo.Quotes
{
    public class SpaceballsQuoteProvider : IMovieQuoteProvider
    {
        private Random _randomNumberGenerator;

        public SpaceballsQuoteProvider()
        {
            _randomNumberGenerator = new Random();
        }

        private string[] _quotes = 
        {
            "You have the ring, and I see your Schwartz is as big as mine. Now let's see how well you handle it.",
            "Look your highness, it's not that we're afraid, far from it. It's just that we've got this thing about death; it's not us.",
            "Out of order?! Even in the future, nothing works!",
            "Or else Pizza is gonna send out for you.",
            "So, at last we meet for the first time for the last time.",
            "So, Lone Starr, now you see that evil will always triumph, because good is dumb."
        };

        public string GetQuote()
        {
            return _quotes[_randomNumberGenerator.Next(0, _quotes.Count() - 1)];
        }
    }
}