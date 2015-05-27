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
	class FeedbackStep1 : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			View v = inflater.Inflate(Resource.Layout.FeedbackStep1, container, false);

			TabContainer.btnPrev.Enabled = false;

			TabContainer.btnPrev.Visibility = ViewStates.Invisible;

			Helps.setNavigationEvents(TabContainer.btnPrev, TabContainer.btnNext, this, TabContainer.feedStep1, TabContainer.feedStep2, isFeedBack : true);

			return v;
		}
	}
}

