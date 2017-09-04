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
using MKKA;

namespace MKKAHelper
{
        [Activity(Label = "Questions")]
        public abstract class QuestionActivity : Activity
        {
        internal Button BackButton;
        internal Button NextButton;
        internal Button Choice1Button;
        internal Button Choice2Button;
        internal Button Choice3Button;
        internal Button Choice4Button;
        internal Button Choice5Button;
        internal Button Choice6Button;
        internal TextView QuestionText;
        internal ImageView ResultGraphic;
        internal MKKAEngine eng;
        static int attempted = 0, correct = 0;
        bool currCorrect;
        Trivia question;



        internal void FindViews()
        {
            BackButton = FindViewById<Button>(Resource.Id.BackButton);
            NextButton = FindViewById<Button>(Resource.Id.NextButton);
            Choice1Button = FindViewById<Button>(Resource.Id.Choice1Button);
            Choice2Button = FindViewById<Button>(Resource.Id.Choice2Button);
            Choice3Button = FindViewById<Button>(Resource.Id.Choice3Button);
            Choice4Button = FindViewById<Button>(Resource.Id.Choice4Button);
            Choice5Button = FindViewById<Button>(Resource.Id.Choice5Button);
            Choice6Button = FindViewById<Button>(Resource.Id.Choice6Button);
            QuestionText = FindViewById<TextView>(Resource.Id.QuestionText);
            ResultGraphic = FindViewById<ImageView>(Resource.Id.ResultGraphic);
        }

        internal void SetUpEvents()
        {
            BackButton.Click += BackButton_Click;
            NextButton.Click += NextButton_Click;
            Choice1Button.Click += Choice1Button_Click;
            Choice2Button.Click += Choice2Button_Click;
            Choice3Button.Click += Choice3Button_Click;
            Choice4Button.Click += Choice4Button_Click;
            Choice5Button.Click += Choice5Button_Click;
            Choice6Button.Click += Choice6Button_Click;
        }
        internal void BackButton_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
        internal void NextButton_Click(object sender, EventArgs e)
        {
            Trivia t = GetTrivia();
            LoadTrivia(t);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.QuestionLayout);
            // Create your application here
            eng = MKKAEngine.getEngine();
            FindViews();
            SetUpEvents();
            Trivia t = GetTrivia();
            LoadTrivia(t);
        }
        public abstract Trivia GetTrivia();
        public void LoadTrivia(Trivia t)
        {
            ++attempted;
            question = t;
            currCorrect = true;
            QuestionText.Text = question.Question;
            Choice1Button.Text = question.choices[0];
            Choice2Button.Text = question.choices[1];
            Choice3Button.Text = question.choices[2];
            Choice4Button.Text = question.choices[3];
            Choice5Button.Text = question.choices[4];
            Choice6Button.Text = question.choices[5];
            NextButton.Enabled = false;
            BackButton.Text = "Cancel";
            ResultGraphic.SetImageResource(0);
        }

        internal void Choice1Button_Click(object sender, EventArgs e)
        {
            CheckButton(Choice1Button);
        }
        internal void CheckButton(Button button)
        {
            if (button.Text == question.answer)
            {
                AnimateButton(button, true);
                NextButton.Enabled = true;
                BackButton.Text = "Finish";
                if (currCorrect)
                    ++correct;
            }
            else
            {
                AnimateButton(button, false);
                currCorrect = false;
            }
        }
        private void AnimateButton(Button button, bool v)
        {
            if (v)
                ResultGraphic.SetImageResource(Resource.Drawable.Check);
            else
                ResultGraphic.SetImageResource(Resource.Drawable.X);

        }

        internal void Choice2Button_Click(object sender, EventArgs e)
        {
            CheckButton(Choice2Button);
        }
        internal void Choice3Button_Click(object sender, EventArgs e)
        {
            CheckButton(Choice3Button);
        }
        internal void Choice4Button_Click(object sender, EventArgs e)
        {
            CheckButton(Choice4Button);
        }
        internal void Choice5Button_Click(object sender, EventArgs e)
        {
            CheckButton(Choice5Button);
        }
        internal void Choice6Button_Click(object sender, EventArgs e)
        {
            CheckButton(Choice6Button);
        }

    }
}