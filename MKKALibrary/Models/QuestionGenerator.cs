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
        public Trivia GenKataQuestion(MKKAEngine eng)
        {
            var ret = new Trivia();
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

        public Trivia GenBoardDanQuestion(MKKAEngine eng)
        {
            /*
            possible question
            1: What rank is X degree?
            2: what is X rank?
            3: Who is the X?
            4: what position does Sensei X hold?
            5. What rank is Sensei X?  Need permission for this one
            */
            var ret = new Trivia();
            Random r = new Random();
            int pickedQuestion = r.Next() % 4;
            switch(pickedQuestion)
            {
                case 0:
                    {
                        int val = r.Next() % eng.rankings.Count;
                        DanRanking rank = eng.rankings.ElementAt(val);
                        ret.Question = "What rank is " + ordinals[rank.Degree] + " degree?";
                        ret.answer = rank.Name;
                        int answerLoc = r.Next() % 6;
                        for (int i = 0; ret.choices.Count < 6; ++i)
                        {
                            if (i == answerLoc)
                            {
                                ret.choices.Add(ret.answer);
                            }
                            else
                            {
                                do
                                {
                                    val = r.Next() % eng.rankings.Count;
                                    var wrong = eng.rankings.ElementAt(val);
                                    if (!ret.choices.Contains(wrong.Name) && wrong.Name != ret.answer)
                                    {
                                        ret.choices.Add(wrong.Name);
                                    }
                                } while (i == ret.choices.Count);
                            }
                        }
                        return ret;
                    }
                case 1:
                    {
                        int val = r.Next() % eng.rankings.Count;
                        DanRanking rank = eng.rankings.ElementAt(val);
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
                            {
                                do
                                {
                                    val = r.Next() % eng.rankings.Count;
                                    var wrong = eng.rankings.ElementAt(val);
                                    if (!ret.choices.Contains(wrong.Degree.ToString()) && wrong.Degree.ToString() != ret.answer)
                                    {
                                        ret.choices.Add(wrong.Degree.ToString());
                                    }
                                } while (i == ret.choices.Count);
                            }
                        }
                        return ret;
                    }
                case 2:
                    {
                        int val = r.Next() % eng.board.Count;
                        BoardMember member = eng.board.ElementAt(val);
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
                                do
                                {
                                    val = r.Next() % eng.board.Count;
                                    var wrong = eng.board.ElementAt(val);
                                    string newChoice = "Sensei " + wrong.FirstName + " " + wrong.LastName;
                                    if (!ret.choices.Contains(newChoice) && newChoice != ret.answer)
                                    {
                                        ret.choices.Add(newChoice);
                                    }
                                } while (i == ret.choices.Count);
                            }
                        }
                        ret.choices.Add("None");
                        return ret;
                    }
                case 3:
                    {
                        int val = r.Next() % eng.board.Count;
                        BoardMember member = eng.board.ElementAt(val);
                        int chanceForNoSensei = r.Next() % 10;
                        ret.Question = "What position does " + (chanceForNoSensei == 0 ? "" : "Sensei ") + member.FirstName + " " + member.LastName + " hold?";
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
                                do
                                {
                                    val = r.Next() % eng.board.Count;
                                    var wrong = eng.board.ElementAt(val);
                                    if (!ret.choices.Contains(wrong.Title) && wrong.Title != ret.answer)
                                    {
                                        ret.choices.Add(wrong.Title);
                                    }
                                } while (i == ret.choices.Count);
                            }
                        }
                        ret.choices.Add("None");
                        if (chanceForNoSensei == 0)
                        {
                            ret.answer = "None";
                        }
                        return ret;
                    }
            }
            return ret;

        }
    }
}
