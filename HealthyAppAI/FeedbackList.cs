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

using Mono.Data.Sqlite;
using System.Data;
using System.Data.Sql;
using Android.Util;


namespace HealthyAppAI
{
	[Activity]
	public class FeedbackList : Activity
	{
		public List<Prospect> lProspet;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			ListView listView;

			try
			{
				Log.Debug("FeedBack","Create FeedBack");
				base.OnCreate(savedInstanceState);

				SetContentView(Resource.Layout.FeedbackList);

				this.FindViewById<Button>(Resource.Id.btnClear).Click += delegate {

					SqliteConnection connection = new SqliteConnection("Data Source=" + SQLContext.getDataBasePath());

					SqliteCommand nCommand = connection.CreateCommand();


					string strRes = string.Empty;

					nCommand.CommandText = "DELETE FROM PROSPECT";

					connection.Open ();
					nCommand.ExecuteNonQuery ();

					connection.Close ();
				};

				listView = FindViewById<ListView>(Resource.Id.vFeedbackList);

				lProspet = SQLContext.getProspects("Feedback");

				listView.Adapter = new CustomAdapter(this, lProspet);

				listView.ItemClick += OnListitemClick;

			}
			catch(Exception excep) {

				Log.Error("FeedBack",excep.Message);

			}
		}


		void OnListitemClick(Object sender, AdapterView.ItemClickEventArgs e)
		{	
			var listView = sender as ListView;

			Prospect t = lProspet[e.Position];

			Toast.MakeText (this, t.FirstName, ToastLength.Long).Show ();

			string IDProspect = t.IDProspect;
			fillProspect (IDProspect);

			Intent intent = new Intent(this, typeof(TabContainer));
			intent.PutExtra("FormType", "FeedBack");

			StartActivity(intent);
			Finish ();
		}

		public static string fillProspect(string IDProspect)
		{
			SqliteConnection connection = new SqliteConnection("Data Source=" + SQLContext.getDataBasePath());

			SqliteCommand nCommand = connection.CreateCommand();

			SqliteDataReader nReader;
			string strRes = string.Empty;
		
			nCommand.CommandText = "SELECT IDPROSPECT, FIRSTNAME, LASTNAME, CITY, PROFESSION FROM PROSPECT WHERE IDPROSPECT = @IDPROSPECT";

			nCommand.Parameters.Add (new SqliteParameter ("@IDPROSPECT", IDProspect));

			connection.Open ();
			nReader = nCommand.ExecuteReader ();

			if (nReader.Read ()) {

				if (Model.nProspect == null) {
					Model.nProspect = new Prospect ();
				}
				Model.nProspect.FirstName = nReader.GetString (1);
				Model.nProspect.LastName = nReader.GetString (2);
				Model.nProspect.City = nReader.GetString (3);
				Model.nProspect.Profession= nReader.GetString (4);
				

			}

			nReader.Close ();
			connection.Close ();

			return strRes;
		}







	}

}

