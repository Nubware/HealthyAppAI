using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HealthyAppAI
{
	[Activity (MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);
			string str; 

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.btnHome);

			button.Click += delegate {
				//Intent intent = new Intent(this, typeof(TabContainer));
				//intent.PutExtra("FormType", "Application");

				StartActivity(typeof(loginDemostrator)); 
			};

			Button buttonTres = FindViewById<Button>(Resource.Id.btnHomeTres);

			buttonTres.Click += delegate
			{
				StartActivity(typeof(FeedbackList));
			};
		}
	}
}


