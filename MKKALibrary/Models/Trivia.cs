using System.Collections.Generic;

namespace MKKA
{
    public class Trivia
    {
        public string Question { get; set; }
        public HashSet<string> choices;
        public string answer;

        public Trivia(string youBetterBelieveIt)
        {
            answer = youBetterBelieveIt;
        }

    }
}