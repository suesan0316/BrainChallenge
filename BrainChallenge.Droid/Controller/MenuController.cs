using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace BrainChallenge.Droid.Controller
{
	[Activity(MainLauncher = true)]
    public class MenuController : Activity
	{
	    private TableLayout _menuTable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
			//SetTheme(AppConst.targetTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

            _menuTable = FindViewById<TableLayout>(Resource.Id.menuTable);

			/*selectMemoryGameButton.Click += delegate
			{
				var next = new Intent(this, typeof(GameStartController));
				next.PutExtra("MyData", "DetectiveGameController");
				StartActivity(next);
			};*/
        }
    }
}