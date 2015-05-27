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
	class Model {

		public static string IDEvent = "01";

		public static string IDSubEvent = "01";

		public static string NameEvent = "Event01";

		public static string NameSubEvent = "SubEvent01";

		public static string DateEvent = DateTime.Today.ToShortDateString();

		public static int localConcecutive = 1;

		public static string IDDevice = "TAB01";

		public static Prospect nProspect { get; set; }

		public static List<InterestedConcepts> lInterConcepts;

		public static List<HaveConsepts> lHaveConcepts;

		public static bool saveProspect(View currentView)
		{
			bool bRes = false;

			if (nProspect == null)
				nProspect = new Prospect();


			nProspect.FirstName = currentView.FindViewById<EditText>(Resource.Id.txtFirstName) != null ? 
				currentView.FindViewById<EditText>(Resource.Id.txtFirstName).Text : nProspect.FirstName;

			nProspect.LastName = currentView.FindViewById<EditText>(Resource.Id.txtLastName) != null ?
				currentView.FindViewById<EditText>(Resource.Id.txtLastName).Text : nProspect.LastName;

			nProspect.AreaConcernOne = currentView.FindViewById<EditText>(Resource.Id.txtConcern1) != null ?
				currentView.FindViewById<EditText>(Resource.Id.txtConcern1).Text : nProspect.AreaConcernOne;

			nProspect.AreaConcernTwo = currentView.FindViewById<EditText>(Resource.Id.txtConcern2) != null ?
				currentView.FindViewById<EditText>(Resource.Id.txtConcern2).Text : nProspect.AreaConcernTwo;

			nProspect.City = currentView.FindViewById<EditText>(Resource.Id.txtCity) != null ?
				currentView.FindViewById<EditText>(Resource.Id.txtCity).Text : nProspect.City;

			nProspect.DaytimePhone = currentView.FindViewById<EditText>(Resource.Id.txtHomePhone) != null ?
				currentView.FindViewById<EditText>(Resource.Id.txtHomePhone).Text : nProspect.DaytimePhone;

			nProspect.EveningPhone = currentView.FindViewById<EditText>(Resource.Id.txtWorkPhone) != null ?
				currentView.FindViewById<EditText>(Resource.Id.txtWorkPhone).Text : nProspect.EveningPhone;

			nProspect.PostalCode = currentView.FindViewById<EditText>(Resource.Id.txtPostalCode) != null ?
				currentView.FindViewById<EditText>(Resource.Id.txtPostalCode).Text : nProspect.PostalCode;

			nProspect.Profession = currentView.FindViewById<EditText>(Resource.Id.txtProfession) != null ?
				currentView.FindViewById<EditText>(Resource.Id.txtProfession).Text : nProspect.Profession;

			nProspect.Email = currentView.FindViewById<EditText>(Resource.Id.txtEmail) != null ?
			    currentView.FindViewById<EditText>(Resource.Id.txtEmail).Text : nProspect.Email;

			//nProspect.FirstName = currentView.FindViewById<EditText>(Resource.Id.txtFirstName) != null ?
			//    currentView.FindViewById<EditText>(Resource.Id.txtFirstName).Text : nProspect.FirstName;

			//nProspect.FirstName = currentView.FindViewById<EditText>(Resource.Id.txtFirstName) != null ?
			//    currentView.FindViewById<EditText>(Resource.Id.txtFirstName).Text : nProspect.FirstName;
			return bRes;
		}

		public static bool saveHaveConcepts(View currentView)
		{
			bool bRes = false;

			int IDRdioButton = 0;

			if (lHaveConcepts == null)            
				lHaveConcepts = new List<HaveConsepts>();

			else            
				lHaveConcepts.Clear();

			try
			{
				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioAcne).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Acne",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioAllergies).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Allergies",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioAlz).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Alzheimer’s",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioArt).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Arthritis",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioCircadian).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Circadian Rhythm/Sleep Problems",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioCirculation).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Circulation Problems",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioChronic).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Chronic Pain",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioDerma).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Dermatological Issues (i.e. psoriasis, exzema, etc.)",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioDepression).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Depression/Mood Disorder/PTSD",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioDiabetes).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Diabetes",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioFibro).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Fibromyalgia",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});                

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioHair).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Hair Loss",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioNerve).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Nerve Damage",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioStroke).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Stroke",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioTBI).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "TBI/Concussion",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioThyroid).CheckedRadioButtonId;
				lHaveConcepts.Add(new HaveConsepts
					{
						Description = "Thyroid Issues",
						Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text
					});
			}
			catch (Exception excep)
			{ 
			}

			return bRes;
		}

		public static bool saveInterestedConcepts(View currentView)
		{
			bool bRes = false;
			int IDRdioButton = 0;

			if (lInterConcepts == null)
				lInterConcepts = new List<InterestedConcepts>();

			else
				lInterConcepts.Clear();

			try
			{
				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioPhysical).CheckedRadioButtonId;

				lInterConcepts.Add(new InterestedConcepts { Description = "Physical Training & Exercise", 
					Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text });

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioSkin).CheckedRadioButtonId;

				lInterConcepts.Add(new InterestedConcepts{ Description = "Skin Rejuvenation",
					Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text });

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioWeight).CheckedRadioButtonId;

				lInterConcepts.Add(new InterestedConcepts{ Description = "Weight Loss/Body Contouring",
					Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text });

				IDRdioButton = currentView.FindViewById<RadioGroup>(Resource.Id.radioWound).CheckedRadioButtonId;

				lInterConcepts.Add(new InterestedConcepts{ Description = "Wound Healing", 
					Result = currentView.FindViewById<RadioButton>(IDRdioButton).Text });

			}
			catch (Exception excep)
			{ 
			}

			return bRes;
		}

		public static string getProspectString()
		{
			return string.Format("Prospect: {0} {1} {2} {3}", nProspect.FirstName, nProspect.LastName, nProspect.Profession, nProspect.City);
		}

		public static string getInterestedString()
		{
			string strRes = string.Empty;

			if(lInterConcepts != null)
				lInterConcepts.ForEach(x => strRes += x.Description + " " + x.Result + ", ");

			return strRes;
			//return string.Format("Concepts: {0} {1} {2} {3}", nProspect.FirstName, nProspect.LastName, nProspect.Profession, nProspect.City);
		}       

		public static string getProspectID()
		{
			String strRes = string.Empty;

			try
			{
				strRes = IDDevice + (localConcecutive ++).ToString();
			}
			catch(Exception excep) 
			{
			
			}

			return strRes;
		}
	}

	public class Prospect
	{
		public string _IDProspect;

		public String IDProspect;
		public int IDDemonstrator;
		public int IDEvent;
		public int IDSubEvent;
		public int IDChair;
		public int Consecutive;
		public String FirstName;
		public String LastName;
		public String Profession;
		public String Street;
		public String City;
		public String Prov;
		public String PostalCode;
		public String DaytimePhone;
		public String EveningPhone;
		public String Mobile;
		public String Email;
		public String Pregnant;
		public String CancerTreatments;
		public String LightSensitive;
		public String Observations;
		public String AreaConcernOne;
		public String AreaConcernTwo;
		public String AreaConcernThree;
		public String Initials;
		public String PrintName;
		public String SignatureProspect;
		public String NameWitness;
		public String SignatureWitness;
		public String SendEmailRegistered;
		public Boolean SendEmailFeedback;//Boolean (0-1)
		public Boolean ReadReleaseAndWaiver;//Boolean (0-1)
		public Boolean SyncCloud;//Boolean (0-1)
		public Boolean SyncInfusionSoft;//Boolean (0-1)
		public String PathPDF;
		public String PathApplicantSignature;
		public String PathWitnessSignature;
		public String RegistrationDate;//UnixTime (number of seconds since midnight 1 January 1970 UTC)
		public String SyncRegistrationDate;//UnixTime (number of seconds since midnight 1 January 1970 UTC)
		public String SessionStartDateTime;
		public String SessionEndDateTime;
		public String Notes;
		public String Estatus;
		//endregion

	}

	class InterestedConcepts
	{
		public String IDInterestedConcept;
		public String IDProspect;
		public String Description;
		public String Result;//Yes / No

	}

	class HaveConsepts
	{
		public String IDHaveConsepts;
		public String IDProspect;
		public String Description;
		public String Result;//Yes / No
	}
}

