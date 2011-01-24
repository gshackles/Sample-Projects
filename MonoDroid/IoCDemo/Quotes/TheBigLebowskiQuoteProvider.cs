using System;
using System.Linq;

namespace IoCDemo.Quotes
{
    public class TheBigLebowskiQuoteProvider : IMovieQuoteProvider
    {
        private Random _randomNumberGenerator;

        public TheBigLebowskiQuoteProvider()
        {
            _randomNumberGenerator = new Random();
        }

        private string[] _quotes = 
        {
            "You want a toe? I can get you a toe, believe me. There are ways, Dude. You don't wanna know about it, believe me.",
            "That rug really tied the room together.",
            "Let me explain something to you. Um, I am not \"Mr. Lebowski\". You're Mr. Lebowski. I'm the Dude. So that's what you call me. You know, that or, uh, His Dudeness, or uh, Duder, or El Duderino if you're not into the whole brevity thing.",
            "Hey, nice marmot!",
            "Jackie Treehorn treats objects like women, man.",
            "Mark it, Dude."
        };

        public string GetQuote()
        {
            return _quotes[_randomNumberGenerator.Next(0, _quotes.Count() - 1)];
        }
    }
}