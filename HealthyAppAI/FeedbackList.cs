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
using DSoft.UI.Grid.Views;
using DSoft.UI.Grid;
using DSoft.Datatypes.Grid.Data;


namespace HealthyAppAI
{
	[Activity]
	public class FeedbackList : Activity
	{
		DSGridView mDataGrid;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.FeedbackList);

			this.FindViewById<Button>(Resource.Id.btnClear).Click += delegate {
				
				SqliteConnection connection = new SqliteConnection("Data Source=" + SQLContext.getDataBasePath());

				SqliteCommand nCommand = connection.CreateCommand();

				SqliteDataReader nReader;
				string strRes = string.Empty;

				nCommand.CommandText = "DELETE FROM PROSPECT";

				connection.Open ();
				nCommand.ExecuteNonQuery ();

				connection.Close ();
			};

			mDataGrid = this.FindViewById<DSGridView>(Resource.Id.myDataGrid);

			if (mDataGrid != null)
			{
				mDataGrid.DataSource = fillGrid();


				mDataGrid.OnRowSelect += (Object rowSender, int row) => 
				{
					string IDProspect = ((DSGridRowView)rowSender).Processor.RowId;

					string test = fillProspect(IDProspect);

					Intent intent = new Intent(this, typeof(TabContainer));
					intent.PutExtra("FormType", "FeedBack");

					StartActivity(intent);
				};
				//mDataGrid.TableName = "DT1";
			}
			//this.bindGrid();
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

		public static DSDataColumn getDataTable(String name, String caption,float Width ,bool readOnly = true, bool AllowSort = false)
		{
			DSDataColumn resTable;

			resTable = new DSDataColumn (name);
			resTable.Caption = caption;
			resTable.ReadOnly = readOnly;
			resTable.DataType = typeof(string);
			resTable.AllowSort = AllowSort;
			resTable.Width = Width;

			return resTable;
		}

		public static DSDataTable fillGrid()
		{			
			DataTable DT = new DataTable ("NombreDT");
			DSDataTable finalDT = new DSDataTable("NombreDT");

			finalDT.Columns.Add(getDataTable("FirstName","FirstName",500));
			finalDT.Columns.Add(getDataTable("LastName","LastName",500));
			finalDT.Columns.Add(getDataTable("City","City",500));

			SqliteConnection connection = new SqliteConnection("Data Source=" + SQLContext.getDataBasePath());

			String nCommand;
			SqliteDataAdapter nAdapter;

			nCommand = "SELECT IDProspect, FirstName, LastName, City FROM Prospect";

			nAdapter = new SqliteDataAdapter (nCommand, connection);
			nAdapter.Fill (DT);

			foreach (DataRow fila in DT.Rows) 
			{
				var dr = new DSDataRow ();
				dr.RowId = fila [0].ToString();

				dr ["FirstName"] = fila [1];
				dr ["LastName"] = fila [2];
				dr ["City"] = fila [3];

				finalDT.Rows.Add (dr);
			}

			return finalDT;
		}



	}

}

