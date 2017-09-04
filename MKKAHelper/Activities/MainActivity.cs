using Android.App;
using Android.OS;
using MKKA;
using System;
using Android.Content;
using Android.Widget;
using System.IO;
using Android.Content.PM;

namespace MKKAHelper
{
    [Activity(Label = "MKKA Helper", MainLauncher = true, ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        private Button kataCalloutButton;
        private Button kataQuestionsButton;
        private Button otherQuestionsButton;
        private Button reviewButton;
        private Button settingsButton;
        private Button exitButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            string newPath = MKKAEngine.GetDatabasePath();
            using (var assets = Assets.Open("Karate.db"))
                using (var dest = File.Create(newPath))
                    assets.CopyTo(dest);
            MKKAEngine.getEngine();
            //Xamarin.Forms.DependencyService.Register<AndroidFileHelper>();*/
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            FindViews();
            SetUpEvents();
        }

        private void SetUpEvents()
        {
            kataCalloutButton.Click += KataCalloutButton_Click;
            kataQuestionsButton.Click += KataQuestionsButton_Click;
            otherQuestionsButton.Click += OtherQuestionsButton_Click;
            reviewButton.Click += ReviewButton_Click;
            settingsButton.Click += SettingsButton_Click;
            exitButton.Click += ExitButton_Click;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SettingsActivity));
            StartActivity(intent);
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ReviewActivity));
            StartActivity(intent);
        }

        private void OtherQuestionsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(QuestionActivity));
            StartActivity(intent);
        }

        private void KataQuestionsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(KataQuestionActivity));
            StartActivity(intent);
        }

        private void KataCalloutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CalloutActivity));
            StartActivity(intent);
        }

        private void FindViews()
        {
            kataCalloutButton = FindViewById<Button>(Resource.Id.KataCalloutButton);
            kataQuestionsButton = FindViewById<Button>(Resource.Id.KataQuestionsButton);
            otherQuestionsButton = FindViewById<Button>(Resource.Id.OtherQuestionsButton);
            reviewButton = FindViewById<Button>(Resource.Id.reviewButton);
            settingsButton = FindViewById<Button>(Resource.Id.settingsButton);
            exitButton = FindViewById<Button>(Resource.Id.exitButton);
        }   
    }       
}           
            
