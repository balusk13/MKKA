using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKA
{ 
    class QuestionGenerator
    {
        public Trivia GenKataQuestion(ref MKKAEngine eng)
        {
            var ret = new Trivia("tmp");
            Random r = new Random();
            int picked  = r.Next() % eng.katas.Count;
            /*
            possible questions:
            1 : where does the X kick in Y go?
            2: What is the X move in Y?
            3: How many moves are in X?
            */
            return ret;
        }

        public Trivia GenBoardDanQuestion(ref MKKAEngine eng)
        {
            /*
            possible question
            1: What rank is X degree?
            2: what is X rank?
            3: Who is the X?
            4: what position does Sensei X hold?
            5. What rank is Sensei X?  Need permission for this one
            */
            var ret = new Trivia("tmp");
            Random r = new Random();
            int pickedQuestion = r.Next() % 4;
            switch(pickedQuestion)
            {
                case 0:
                    int pickedAnswer = r.Next() % 10 + 1;
                    foreach (var rank in eng.rankings)
                    {
                        if(rank.Degree == pickedAnswer)
                        {
                            ret.Question = "What rank is " + rank.Name + "?";
                            ret.answer = 
                        }
                    }
                    ret.Question = "What rank is " + eng.

            }
            return ret;

        }
    }
}
