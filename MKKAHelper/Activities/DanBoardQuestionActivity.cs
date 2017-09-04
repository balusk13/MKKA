using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MKKAHelper;
using MKKA;

namespace MKKAHelper
{
    [Activity(Label = "DanBoardQuestionActivity")]
    public class DanBoardQuestionActivity : QuestionActivity
    {
        public override Trivia GetTrivia()
        {
            return base.eng.GetBoardDanQuestion();
        }
    }
}