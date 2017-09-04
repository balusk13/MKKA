using System.Collections.Generic;

namespace MKKA
{
    public class Trivia
    {
        public string Question { get; set; }
        public List<string> choices { get; set; }
        public string answer;

        public Trivia()
        {
            choices = new List<string>();
        }

    }
}