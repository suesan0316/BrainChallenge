using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace BrainChallenge.Droid.Mock
{
	[Activity(Label = "GameResultController")]
	public class GameResultController : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetTheme(AppConst.targetTheme);

			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.GameResult);

			var returnButton = FindViewById<Button>(Resource.Id.returnButton);
			returnButton.Click += delegate
			{
				var next = new Intent(this, typeof(MenuController));
				StartActivity(next);
			};

			var againButton = FindViewById<Button>(Resource.Id.againButton);

			againButton.Click += delegate {
				var next = new Intent(this, typeof(DetectiveGameController));
				StartActivity(next);
			};
		}
	}
}
