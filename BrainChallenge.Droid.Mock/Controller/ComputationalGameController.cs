using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace BrainChallenge.Droid.Mock
{
	[Activity(Label = "ComputationalGameController")]
	public class ComputationalGameController : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetTheme(AppConst.targetTheme);

			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.ComputationalGame);

			var returnButton = FindViewById<Button>(Resource.Id.returnButton);
			returnButton.Click += delegate
			{
				var next = new Intent(this, typeof(GameResultController));
				StartActivity(next);
			};
		}
	}
}
