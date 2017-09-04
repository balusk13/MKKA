using MKKA;

namespace MKKAHelper
{
    internal class KataQuestionActivity : QuestionActivity
    {
        public override Trivia GetTrivia()
        {
            return base.eng.GetKataQuestion();
        }
    }
}