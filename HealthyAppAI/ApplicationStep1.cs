using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace HealthyAppAI
{
	class ApplicationStep1 : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			View v = inflater.Inflate(Resource.Layout.ApplicationStep1, container, false);

			var adapter = ArrayAdapter.CreateFromResource(v.Context, Resource.Array.provinces_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

			v.FindViewById<Spinner>(Resource.Id.dropProvince).Adapter = adapter;

			TabContainer.btnPrev.Enabled = false;

			TabContainer.btnPrev.Visibility = ViewStates.Invisible;

			Helps.setNavigationEvents(TabContainer.btnPrev, TabContainer.btnNext, this, TabContainer.appStep1, TabContainer.appStep2);

			return v;
		}       
	}
}

