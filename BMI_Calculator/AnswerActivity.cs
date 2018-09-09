using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace BMI_Calculator
{
    [Activity(Label = "AnswerActivity")]
    public class AnswerActivity : Android.App.Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.answer_activity);
            string answer = Intent.GetStringExtra("answer") ?? "Not Recv";

            var txtViewAnswer = FindViewById<TextView>(Resource.Id.txtViewAnswer);
            var goBack = FindViewById<Button>(Resource.Id.btnOK);

            
            txtViewAnswer.Text = answer;

            goBack.Click += delegate{
                this.Finish();
            };
        }
    }
}