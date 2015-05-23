using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;


namespace HealthyAppAI
{
	public class CustomAdapter: BaseAdapter<Prospect>
	{
		List<Prospect> items;
		Activity context;

		public CustomAdapter(Activity context, List<Prospect> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override Prospect this[int position]
		{
			get { return items[position]; }
		}

		public override int Count
		{
			get { return items.Count; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			View view = convertView;

			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.RowFeedbackList, null);
			
			view.FindViewById<TextView>(Resource.Id.Text1).Text = string.Format("{0} {1}", item.FirstName, item.LastName);
			view.FindViewById<TextView>(Resource.Id.Text2).Text = item.City;

//			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
			return view;
		}
	}
}

