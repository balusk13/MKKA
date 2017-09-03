using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKA
{ 
    class QuestionGenerator
    {
        static string[] ordinals = new[] { "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth"};
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
                    {
                        DanRanking rank = eng.rankings.ElementAt(r.Next() % eng.rankings.Count);
                        ret.Question = "What rank is " + ordinals[rank.Degree + 1] + " degree?";
                        ret.answer = rank.Name;
                        int answerLoc = r.Next() % 6;
                        for (int i = 0; ret.choices.Count < 6; ++i)
                        {
                            if (i == answerLoc)
                            {
                                ret.choices.Add(ret.answer);
                            }
                            else
                                ret.choices.Add(eng.rankings.ElementAt(r.Next() % 10).Name);
                        }
                        return ret;
                    }
                case 1:
                    {
                        DanRanking rank = eng.rankings.ElementAt(r.Next() % eng.rankings.Count);
                        ret.Question = "What degree is " + rank.Name + "?";
                        ret.answer = rank.Degree.ToString();
                        int answerLoc = r.Next() % 6;
                        for (int i = 0; ret.choices.Count < 6; ++i)
                        {
                            if (i == answerLoc)
                            {
                                ret.choices.Add(ret.answer);
                            }
                            else
                                ret.choices.Add(eng.rankings.ElementAt(r.Next() % 10).Degree.ToString());
                        }
                        return ret;
                    }
                case 2:
                    {
                        BoardMember member = eng.board.ElementAt(r.Next() % eng.board.Count);
                        ret.Question = "Who is the " + member.Title + "?";
                        ret.answer = "Sensei " + member.FirstName + " " + member.LastName;
                        int answerLoc = r.Next() % 5;
                        for (int i = 0; ret.choices.Count < 5; ++i)
                        {
                            if (i == answerLoc)
                            {
                                ret.choices.Add(ret.answer);
                            }
                            else
                            {
                                var wrong = eng.board.ElementAt(r.Next() % eng.board.Count);
                                ret.choices.Add("Sensei " + wrong.FirstName + " " + wrong.LastName);
                            }
                        }
                        return ret;
                    }
                case 3:
                    {
                        BoardMember member = eng.board.ElementAt(r.Next() % eng.board.Count);
                        ret.Question = "What position does Sensei " + member.FirstName + " " + member.LastName + " hold?";
                        ret.answer = member.Title;
                        int answerLoc = r.Next() % 5;
                        for (int i = 0; ret.choices.Count < 5; ++i)
                        {
                            if (i == answerLoc)
                            {
                                ret.choices.Add(ret.answer);
                            }
                            else
                            {
                                var wrong = eng.board.ElementAt(r.Next() % eng.board.Count);
                                ret.choices.Add(wrong.Title);
                            }
                        }
                        return ret;
                    }
            }
            return ret;

        }
    }
}
