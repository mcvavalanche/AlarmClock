using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AlarmClock.Droid
{
    [Activity(Label = "AlarmClock.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.MyButton);


            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var picker = FindViewById<TimePicker>(Resource.Id.AlarmTimePicker);
            var text = FindViewById<TextView>(Resource.Id.InfoTextView);
            text.Text = $"hour:{picker.Hour} minute:{picker.Minute}";
        }

    }
}

