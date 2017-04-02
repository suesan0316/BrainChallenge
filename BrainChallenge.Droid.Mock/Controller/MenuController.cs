using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace BrainChallenge.Droid.Mock
{
	[Activity(MainLauncher = true)]
    public class MenuController : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
			//SetTheme(AppConst.targetTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

			var selectMemoryGameButton = FindViewById<ImageButton>(Resource.Id.selectDetectiveGameButton);
			selectMemoryGameButton.Click += delegate
			{
				var next = new Intent(this, typeof(GameStartController));
				next.PutExtra("MyData", "DetectiveGameController");
				StartActivity(next);
			};

			var selectFlexibilityGameButton = FindViewById<ImageButton>(Resource.Id.selectFlexibilityGameButton);
			selectFlexibilityGameButton.Click += delegate
			{
				var next = new Intent(this, typeof(GameStartController));
				next.PutExtra("MyData", "FlexibilityGameController");
				StartActivity(next);
			};


			var selectComputationalGameButton = FindViewById<ImageButton>(Resource.Id.selectComputationalGameButton);
			selectComputationalGameButton.Click += delegate
			{
				var next = new Intent(this, typeof(GameStartController));
				next.PutExtra("MyData", "ComputationalGameController");
				StartActivity(next);
			};
        }
    }
}