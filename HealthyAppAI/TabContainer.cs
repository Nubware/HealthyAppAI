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
	class TabContainer : Activity
	{        
		public static Button btnPrev;
		public static Button btnNext;

		public static ApplicationStep1 appStep1;
		public static ApplicationStep2 appStep2;
		public static ApplicationStep3 appStep3;
		public static ApplicationStep4 appStep4;

		public static FeedbackStep1 feedStep1;
		public static FeedbackStep2 feedStep2;
		public static FeedbackStep3 feedStep3;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.TabContainer);

			try
			{

				btnPrev = this.FindViewById<Button>(Resource.Id.btnPrevious);
				btnNext = this.FindViewById<Button>(Resource.Id.btnNext);

				appStep1 = new ApplicationStep1();
				appStep2 = new ApplicationStep2();
				appStep3 = new ApplicationStep3();
				appStep4 = new ApplicationStep4();

				feedStep1 = new FeedbackStep1();
				feedStep2 = new FeedbackStep2();
				feedStep3 = new FeedbackStep3();

				FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();

				if (Intent.GetStringExtra("FormType") == "Application")
				{
					fragmentTx.Add(Resource.Id.fragmentContainer, appStep1);
				}
				else
				{
					fragmentTx.Add(Resource.Id.fragmentContainer, feedStep1);
				}

				fragmentTx.Commit();

				#region SQLite

				SQLContext.CreateDataBase();

				#endregion
			}
			catch(Exception excep) {
				Toast.MakeText (this, excep.Message, ToastLength.Long).Show ();
			}

		}
	}
}

