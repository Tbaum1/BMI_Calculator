using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System;
using Environment = System.Environment;

namespace BMI_Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public Type answer_activity { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var editTxtHeight = FindViewById < EditText >( Resource.Id.editTxtHeight);
            var editTxtWeight = FindViewById < EditText>( Resource.Id.editTxtWeight);
            var btnCalc = FindViewById<Button>(Resource.Id.btnCalc);
            double answer;
            Intent answerActivity = new Intent(this, typeof(AnswerActivity));
            btnCalc.Click += delegate
            {
                double height = Math.Pow(Double.Parse(editTxtHeight.Text), 2);
                int weight = int.Parse(editTxtWeight.Text);
                double temp = (weight / height) * 703;
                answer =  Math.Round(temp, 2);           
                checkAnswer();
            };

            void checkAnswer()
            {
                if (answer < 18.50)
                {
                    answerActivity.PutExtra("answer", "Underwieght" + Environment.NewLine + Convert.ToString(answer) + "% BMI");
                    StartActivity(answerActivity);
                }
                else if (answer >= 18.54 && answer <= 24.99)
                {
                    answerActivity.PutExtra("answer", "Normal or Heathly Weight" + Environment.NewLine + Convert.ToString(answer) + "% BMI");
                    StartActivity(answerActivity);
                }
                else if (answer >= 25.00 && answer <= 29.99)
                {
                    answerActivity.PutExtra("answer", "Overweight" + Environment.NewLine + Convert.ToString(answer) + "% BMI");
                    StartActivity(answerActivity);
                }
                else if (answer >= 30.00)
                {
                    answerActivity.PutExtra("answer", "Obese" + Environment.NewLine + Convert.ToString(answer) + "% BMI");
                    StartActivity(answerActivity);
                }
            }
        }


    }
}