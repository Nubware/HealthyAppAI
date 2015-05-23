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
	class FeedbackStep3 : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			View v = inflater.Inflate(Resource.Layout.FeedbackStep3, container, false);

			TabContainer.btnNext.Text = "Next";

			Helps.setNavigationEvents(TabContainer.btnPrev, TabContainer.btnNext, this, TabContainer.feedStep2, TabContainer.feedStep3, true, true);

			return v;
		}
	}
}

