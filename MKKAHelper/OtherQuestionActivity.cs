namespace MKKAHelper
{
        [Activity(Label = "Questions")]
        public class OtherQuestionActivity : Activity
        {
        private Button BackButton;
        private Button NextButton;
        private Button Choice1Button;
        private Button Choice2Button;
        private Button Choice3Button;
        private Button Choice4Button;
        private Button Choice5Button;
        private Button Choice6Button;
        private TextView QuestionText;
            MKKAEngine eng;

            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                running = false;
                SetContentView(Resource.Layout.QuestionsLayout);
                // Create your application here
                eng = MKKAEngine.getEngine();
                FindViews();
                SetUpEvents();
            }

        private void FindViews()
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
        }

        private void SetUpEvents()
        {
            BackButton.Click += BackButton_Click;
            NextButton.Click += StartStopButton_Click;
            Choice1Button.Click += Choice1Button_Click;
            Choice2Button.Click += Choice2Button_Click;
            Choice3Button.Click += Choice3Button_Click;
            Choice4Button.Click += Choice4Button_Click;
            Choice5Button.Click += Choice5Button_Click;
            Choice6Button.Click += Choice6Button_Click;
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            LoadQuestion();
        }
        private void Choice1Button_Click(object sender, EventArgs e)
        {

        }
        private void Choice2Button_Click(object sender, EventArgs e)
        {

        }
        private void Choice3Button_Click(object sender, EventArgs e)
        {

        }
        private void Choice4Button_Click(object sender, EventArgs e)
        {

        }
        private void Choice5Button_Click(object sender, EventArgs e)
        {

        }
        private void Choice6Button_Click(object sender, EventArgs e)
        {

        }

    }
}