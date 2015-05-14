using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


using System.IO;
using System.Data.Sql;
using Mono.Data.Sqlite;

namespace HealthyAppAI
{
	class SQLContext
	{
		public static string strDataBase_Name = "HealthyAppDB.db";

		public static SqliteConnection connection;


		public enum enumTablesName
		{
			PROSPECT, INTERESTEDCONCEPTS, HAVECONCEPTS ,DEMONSTRATORS };

		#region Initial
		public static bool CreateDataBase()
		{
			bool bRes = false, bExist;

			try
			{                
				bExist = File.Exists( getDataBasePath() );


				if (!bExist)//Si no existe, se crea la Base de Datos
				{
					SqliteConnection.CreateFile(getDataBasePath());

					CreateTable(enumTablesName.PROSPECT);
					CreateTable(enumTablesName.INTERESTEDCONCEPTS);
					CreateTable(enumTablesName.HAVECONCEPTS);
					//CreateTable(enumTablesName.DEMONSTRATORS);
				}
			}
			catch (Exception excep)
			{
			}

			return bRes;
		}

		public static string getDataBasePath()
		{
			string strRes = Path.Combine(
				System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
				strDataBase_Name);

			return strRes;
		}

		public static string getCreateTableQuery(enumTablesName tablename)
		{
			string strRes = string.Empty;

			strRes = "Create table " + Enum.GetName(typeof(enumTablesName), tablename);

			switch (tablename)
			{
			case enumTablesName.PROSPECT:

				strRes += "(_id INTEGER primary key autoincrement, "
					+ " IDProspect text,"
					+ " IDDemonstrator text,"
					+ " IDEvent text,"
					+ " IDSubEvent text,"
					+ " IDChair text,"
					+ " Consecutive int,"
					+ " FirstName text,"
					+ " LastName text,"
					+ " Profession text,"
					+ " Street text,"
					+ " City text,"
					+ " Prov text,"
					+ " PostalCode text,"
					+ " DaytimePhone text,"
					+ " EveningPhone text,"
					+ " Mobile text,"
					+ " Email text,"
					+ " Pregnant text,"
					+ " Observations text,"
					+ " AreaConcernOne text,"
					+ " AreaConcernTwo text,"
					+ " AreaConcernThree text,"
					+ " Initials text,"
					+ " SignatureProspect text,"
					+ " NameWitness text,"
					+ " SignatureWitness text,"
					+ " SendEmailRegistered int,"
					+ " SendEmailFeedback int,"
					+ " ReadReleaseAndWaiver int,"
					+ " SyncCloud int,"
					+ " SyncInfusionSoft int,"
					+ " PathPDF text,"
					+ " PathApplicantSignature text,"
					+ " RegistrationDate text,"
					+ " SyncRegistrationDate text,"
					+ " SessionStartDateTime text,"
					+ " SessionEndDateTime text,"
					+ " Notes text,"
					+ " Estatus text);";                    
				break;

			case enumTablesName.INTERESTEDCONCEPTS:
				strRes += "(_id INTEGER primary key autoincrement, "
					+ " IDInterestedConcept text,"
					+ " IDProspect text,"
					+ " Description text,"
					+ " Result text)";
				break;               

			case enumTablesName.HAVECONCEPTS:
				strRes += "(_id INTEGER primary key autoincrement, "
					+ " IDHaveConcept text,"
					+ " IDProspect text,"
					+ " Description text,"
					+ " Result text)";
				break;

			case enumTablesName.DEMONSTRATORS:
				break;

			}



			return strRes;
		}

		public static bool CreateTable(enumTablesName tableName)
		{
			bool bRes = false;          

			try
			{
				connection = new SqliteConnection("Data Source=" + getDataBasePath());

				SqliteCommand nCommand = connection.CreateCommand();

				nCommand.CommandText = getCreateTableQuery(tableName);//

				connection.Open();

				nCommand.ExecuteNonQuery();
			}
			catch (Exception excep)
			{

			}

			connection.Close();
			return bRes;
		}
		#endregion

		#region Insert
		public static bool insertProspect(Prospect newProspect)
		{
			bool bRes = false;
			string strQuery = string.Empty; 

			SqliteConnection connection = new SqliteConnection("Data Source=" + getDataBasePath() );
			SqliteCommand command;

			try
			{
				strQuery = "INSERT INTO PROSPECT(IDProspect, IDDemonstrator, IDEvent, IDSubEvent, IDChair,FirstName, LastName, Profession, Street, City, Prov, PostalCode, DayTimePhone, EveningPhone, Mobile, Email, Pregnant, Observations, AreaConcernOne, AreaConcernTwo, AreaConcernThree, Initials, SignatureProspect, NameWitness, SignatureWitness, SendEmailRegistered, SendEmailFeedBack, ReadReleaseAndWaiver, SyncCloud, SyncInfusionSoft, PathPDF, PathApplicantSignature, RegistrationDate, SyncRegistrationDate, SessionStartDateTime, SessionEndDateTime, Notes, Estatus)" +
					"VALUES(@IDProspect, @IDDemonstrator, @IDEvent, @IDSubEvent, @IDChair, @FirstName, @LastName, @Profession, @Street, @City, @Prov, @PostalCode, @DayTimePhone, @EveningPhone, @Mobile, @Email, @Pregnant, @Observations, @AreaConcernOne, @AreaConcernTwo, @AreaConcernThree, @Initials, @SignatureProspect, @NameWitness, @SignatureWitness, @SendEmailRegistered, @SendEmailFeedBack, @ReadReleaseAndWaiver, @SyncCloud, @SyncInfusionSoft, @PathPDF, @PathApplicantSignature, @RegistrationDate, @SyncRegistrationDate, @SessionStartDateTime, @SessionEndDateTime, @Notes, @Estatus)";

				command = new SqliteCommand(strQuery, connection);

				command.Parameters.Add(new SqliteParameter("@IDProspect", Model.getProspectID()));
				command.Parameters.Add(new SqliteParameter("@IDDemonstrator", newProspect.IDDemonstrator));
				command.Parameters.Add(new SqliteParameter("@IDEvent", newProspect.IDEvent));
				command.Parameters.Add(new SqliteParameter("@IDSubEvent", newProspect.IDSubEvent));
				command.Parameters.Add(new SqliteParameter("@IDChair", newProspect.IDChair));

				command.Parameters.Add(new SqliteParameter("@FirstName", newProspect.FirstName));
				command.Parameters.Add(new SqliteParameter("@LastName", newProspect.LastName));
				command.Parameters.Add(new SqliteParameter("@Profession", newProspect.Profession));
				command.Parameters.Add(new SqliteParameter("@Street", newProspect.Street));
				command.Parameters.Add(new SqliteParameter("@City", newProspect.City));

				command.Parameters.Add(new SqliteParameter("@Prov", newProspect.Prov));
				command.Parameters.Add(new SqliteParameter("@PostalCode", newProspect.PostalCode));
				command.Parameters.Add(new SqliteParameter("@DayTimePhone", newProspect.DaytimePhone));
				command.Parameters.Add(new SqliteParameter("@EveningPhone", newProspect.EveningPhone));

				command.Parameters.Add(new SqliteParameter("@Mobile", newProspect.Mobile));
				command.Parameters.Add(new SqliteParameter("@Email", newProspect.Email));
				command.Parameters.Add(new SqliteParameter("@Pregnant", newProspect.Pregnant));
				command.Parameters.Add(new SqliteParameter("@Observations", newProspect.Observations));
				command.Parameters.Add(new SqliteParameter("@AreaConcernOne", newProspect.AreaConcernOne));
				command.Parameters.Add(new SqliteParameter("@AreaConcernTwo", newProspect.AreaConcernTwo));

				command.Parameters.Add(new SqliteParameter("@AreaConcernThree", newProspect.AreaConcernThree));
				command.Parameters.Add(new SqliteParameter("@Initials", newProspect.Initials));
				command.Parameters.Add(new SqliteParameter("@SignatureProspect", newProspect.SignatureProspect));
				command.Parameters.Add(new SqliteParameter("@NameWitness", newProspect.NameWitness));
				command.Parameters.Add(new SqliteParameter("@SignatureWitness", newProspect.SignatureWitness));

				command.Parameters.Add(new SqliteParameter("@SendEmailRegistered", newProspect.SendEmailRegistered));
				command.Parameters.Add(new SqliteParameter("@SendEmailFeedBack", newProspect.SendEmailFeedback));
				command.Parameters.Add(new SqliteParameter("@ReadReleaseAndWaiver", newProspect.ReadReleaseAndWaiver));
				command.Parameters.Add(new SqliteParameter("@SyncCloud", newProspect.SyncCloud));

				command.Parameters.Add(new SqliteParameter("@SyncInfusionSoft", newProspect.SyncInfusionSoft));
				command.Parameters.Add(new SqliteParameter("@PathPDF", newProspect.PathPDF));

				command.Parameters.Add(new SqliteParameter("@PathApplicantSignature", newProspect.PathApplicantSignature));
				command.Parameters.Add(new SqliteParameter("@RegistrationDate", newProspect.RegistrationDate));
				command.Parameters.Add(new SqliteParameter("@SyncRegistrationDate", newProspect.SyncRegistrationDate));
				command.Parameters.Add(new SqliteParameter("@EveningPhone", newProspect.EveningPhone));
				command.Parameters.Add(new SqliteParameter("@SessionStartDateTime", newProspect.SessionStartDateTime));

				command.Parameters.Add(new SqliteParameter("@SessionEndDateTime", newProspect.SessionEndDateTime));
				command.Parameters.Add(new SqliteParameter("@Notes", newProspect.Notes));
				command.Parameters.Add(new SqliteParameter("@Estatus", newProspect.Estatus));

				connection.Open();

				command.ExecuteNonQuery();

				bRes = true;
			}
			catch (Exception excep)
			{

			}
			connection.Close();

			return bRes;
		}

		public static bool insertInterestedConcepts(InterestedConcepts newInterestConcept)
		{
			bool bRes = false;

			string strQuery = string.Empty;

			SqliteConnection connection = new SqliteConnection("Data Source=" + getDataBasePath());
			SqliteCommand command;

			try
			{
				strQuery = "INSERT INTO INTERESTEDCONCEPTS(IDInterestedConcept, IDProspect, Description, Result )" +
					"VALUES(@IDInterestedConcept, @IDProspect, @Description, @Result )";

				command = new SqliteCommand(strQuery, connection);

				command.Parameters.Add(new SqliteParameter("@IDInterestedConcept", newInterestConcept.IDInterestedConcept) );
				command.Parameters.Add(new SqliteParameter("@IDProspect", newInterestConcept.IDProspect));
				command.Parameters.Add(new SqliteParameter("@Description", newInterestConcept.Description));
				command.Parameters.Add(new SqliteParameter("@Result", newInterestConcept.Result));

				connection.Open();

				command.ExecuteNonQuery();

				bRes = true;
				Console.WriteLine("Save Inter Concepts");
			}
			catch (Exception excep)
			{ 
			}
			connection.Close();

			return bRes;
		}

		public static bool insertInterestedConcepts(List<InterestedConcepts> lnewInterestedConcepts)
		{
			bool bRes = false;

			try
			{
				lnewInterestedConcepts.ForEach(x => insertInterestedConcepts(x) );

				bRes = true;
			}
			catch (Exception excep)
			{

			}

			return bRes;
		}

		public static bool insertHaveConcept(HaveConsepts newHaveConcept)
		{
			bool bRes = false;

			string strQuery = string.Empty;

			SqliteConnection connection = new SqliteConnection("Data Source=" + getDataBasePath());
			SqliteCommand command;

			try
			{
				strQuery = "INSERT INTO HAVECONCEPTS(IDHaveConcept, IDProspect, Description, Result )" +
					"VALUES(@IDInterestedConcept, @IDProspect, @Description, @Result )";

				command = new SqliteCommand(strQuery, connection);

				command.Parameters.Add(new SqliteParameter("@IDInterestedConcept", newHaveConcept.IDHaveConsepts));
				command.Parameters.Add(new SqliteParameter("@IDProspect", newHaveConcept.IDProspect));
				command.Parameters.Add(new SqliteParameter("@Description", newHaveConcept.Description));
				command.Parameters.Add(new SqliteParameter("@Result", newHaveConcept.Result));

				connection.Open();

				command.ExecuteNonQuery();

				bRes = true;

				Console.WriteLine("Save Have Concepts");
			}
			catch (Exception excep)
			{
			}
			connection.Close();

			return bRes;
		}

		public static bool insertHaveConcept(List<HaveConsepts> lnewHaveConcepts)
		{
			bool bRes = false;

			try
			{
				lnewHaveConcepts.ForEach(x => insertHaveConcept(x));

				bRes = true;


			}
			catch (Exception excep)
			{

			}

			return bRes;
		}
		#endregion



	}
}

