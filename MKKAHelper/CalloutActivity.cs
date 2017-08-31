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
using System.Threading;
using System.Threading.Tasks;
using Android.Speech.Tts;

namespace MKKAHelper
{

    [Activity(Label = "Kata Callout")]
    public class CalloutActivity : Activity
    {
        private bool running;
        private Button BackButton;
        private Button StartStopButton;
        private TextView introTextLabel;
        private TextView KataDisplayText;
        MKKAEngine eng;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            running = false;
            SetContentView(Resource.Layout.KataCallout);
            // Create your application here
            eng = MKKAEngine.getEngine();
            FindViews();
            SetUpEvents();
        }

        private void FindViews()
        {
            BackButton = FindViewById<Button>(Resource.Id.BackButton);
            StartStopButton = FindViewById<Button>(Resource.Id.StartStopButton);
            introTextLabel = FindViewById<TextView>(Resource.Id.IntroText);
            KataDisplayText = FindViewById<TextView>(Resource.Id.KataDisplayText);
        }

        private void SetUpEvents()
        {
            BackButton.Click += BackButton_Click;
            StartStopButton.Click += StartStopButton_Click;
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!running)
            {
                StartCallout();
                StartStopButton.Text = "Stop";                
            }
            else
            {
                StopCallout();
                StartStopButton.Text = "Start";
            }
        }


        private CancellationTokenSource cts;
        public void StartCallout()
        {
            running = true;
            if (cts != null) cts.Cancel();
            cts = new CancellationTokenSource();
            var ignore = NextKata(cts.Token);
        }

        public void StopCallout()
        {
            running = false;
            if (cts != null) cts.Cancel();
            cts = null;
        }

        public async Task NextKata(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                string k = eng.GetRandomActiveKata();
                KataDisplayText.Text = k;
                Xamarin.Forms.DependencyService.Get<ITextToSpeech>().Speak(k);
                float delay = float.Parse(eng.GetSettingValue(SettingKeyEnum.secondsBetweenCallouts));
                await Task.Delay(TimeSpan.FromSeconds(delay), ct);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}