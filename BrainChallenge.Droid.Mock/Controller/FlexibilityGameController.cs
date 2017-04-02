using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace BrainChallenge.Droid.Mock
{
	[Activity(Label = "FlexibilityGameController")]
	public class FlexibilityGameController : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetTheme(AppConst.targetTheme);

			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.FlexibilityGame);

			var returnButton = FindViewById<Button>(Resource.Id.returnButton);
			returnButton.Click += delegate
			{
				var next = new Intent(this, typeof(GameResultController));
				StartActivity(next);
			};
		}
	}
}
