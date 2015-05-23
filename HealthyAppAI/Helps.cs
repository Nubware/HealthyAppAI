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
	class Helps
	{
		public static EventHandler delegatePrev;
		public static EventHandler delegateNext;

		public static void setNavigationEvents(Button btnPrev, Button btnNext, Fragment frmtCurrent, Fragment frmtPrev, Fragment frmtNext, bool isFinish = false, bool isFeedBack = false)
		{
			btnPrev.Click -= delegatePrev;
			btnNext.Click -= delegateNext;

			delegatePrev = delegate
			{
				FragmentTransaction fragmentPrev = frmtCurrent.FragmentManager.BeginTransaction();

				fragmentPrev.Replace(Resource.Id.fragmentContainer, frmtPrev);


				fragmentPrev.AddToBackStack(null);
				fragmentPrev.Commit();
			};

			delegateNext = delegate
			{
				Model.saveProspect(frmtCurrent.View);
				string strMessage = isFeedBack ? "Feedback":"Prospect";

				if (isFinish)
				{
					frmtCurrent.Activity.Finish();

					if(!isFeedBack)
					{
						Model.nProspect.Estatus="Feedback";

						SQLContext.insertProspect(Model.nProspect);
					}
					else
					{
						Model.nProspect.Estatus="Completed";

						SQLContext.UpdateProspect(Model.nProspect.IDProspect, Model.nProspect);

						frmtCurrent.Activity.StartActivity(typeof(FeedbackList));
					}

					Toast.MakeText(frmtCurrent.View.Context, strMessage + " Successfully Saved.", ToastLength.Short).Show();
				}
				else
				{
					Toast.MakeText(frmtCurrent.View.Context, Model.getProspectString(), ToastLength.Short).Show();
					FragmentTransaction fragmentNext = frmtCurrent.FragmentManager.BeginTransaction();

					fragmentNext.Replace(Resource.Id.fragmentContainer, frmtNext);
					fragmentNext.AddToBackStack(null);
					fragmentNext.Commit();
				}
			};


			btnPrev.Click += delegatePrev;            
			btnNext.Click += delegateNext;
		}
	}
}

