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

namespace HealthyAppAI
{
	[Activity]
	public class loginDemostrator: Activity
	{
		public loginDemostrator ()
		{
			
		}

		protected override void OnCreate(Bundle savedInstanceSate)
		{
			base.OnCreate (savedInstanceSate);

			SetContentView (Resource.Layout.loginDemonstrator);


			Button btnSummt = FindViewById<Button>(Resource.Id.btnSubmit);

			btnSummt.Click += delegate {

				if(this.FindViewById<EditText>(Resource.Id.txtPassDemonstrator).Text == "5523")
				{
					Intent intent = new Intent (this, typeof(TabContainer));
					intent.PutExtra ("FormType", "Application");
					
					this.StartActivity (intent); 
					this.Finish();
				}
				else
				{
					Toast.MakeText(this,"Incorrect password. Try again.",ToastLength.Short).Show();
					this.FindViewById<EditText>(Resource.Id.txtPassDemonstrator).Text = string.Empty;
				}
			
			};

		}

	}
}

