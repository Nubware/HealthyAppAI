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
	class ApplicationStep4 : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			View v = inflater.Inflate(Resource.Layout.ApplicationStep4, container, false);

			Helps.setNavigationEvents(TabContainer.btnPrev, TabContainer.btnNext, this, TabContainer.appStep3, TabContainer.appStep1, true);

			return v;
		}
	}
}

