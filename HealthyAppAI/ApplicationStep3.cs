using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SignaturePad;
using Android.Graphics;

namespace HealthyAppAI
{
	public class ApplicationStep3 : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			View v = inflater.Inflate(Resource.Layout.ApplicationStep3, container, false);

			SignaturePadView signatureProspect = v.FindViewById<SignaturePadView>(Resource.Id.signatureProspect);

			signatureProspect.Caption.Text = "Applicant Signature";
			signatureProspect.Caption.SetTypeface(Typeface.Serif, TypefaceStyle.BoldItalic);
			signatureProspect.Caption.SetTextSize(global::Android.Util.ComplexUnitType.Sp, 16f);
			signatureProspect.SignaturePrompt.Text = "x";
			signatureProspect.SignaturePrompt.SetTypeface(Typeface.SansSerif, TypefaceStyle.Normal);
			signatureProspect.SignaturePrompt.SetTextSize(global::Android.Util.ComplexUnitType.Sp, 32f);
			signatureProspect.BackgroundColor = Color.Rgb(245, 242, 223);
			signatureProspect.StrokeColor = Color.Black;

			SignaturePadView signatureWitness = v.FindViewById<SignaturePadView>(Resource.Id.signatureWitness);

			signatureWitness.Caption.Text = "Witness Signature";
			signatureWitness.Caption.SetTypeface(Typeface.Serif, TypefaceStyle.BoldItalic);
			signatureWitness.Caption.SetTextSize(global::Android.Util.ComplexUnitType.Sp, 16f);
			signatureWitness.SignaturePrompt.Text = "x";
			signatureWitness.SignaturePrompt.SetTypeface(Typeface.SansSerif, TypefaceStyle.Normal);
			signatureWitness.SignaturePrompt.SetTextSize(global::Android.Util.ComplexUnitType.Sp, 32f);
			signatureWitness.BackgroundColor = Color.Rgb(245, 242, 223);
			signatureWitness.StrokeColor = Color.Black;

			TabContainer.btnNext.Text = "Next"; 
			Helps.setNavigationEvents(TabContainer.btnPrev, TabContainer.btnNext, this, TabContainer.appStep2, TabContainer.appStep4);

			return v;
		}


	}
}

