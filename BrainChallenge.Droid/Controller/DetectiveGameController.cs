
using Android.App;
using Android.OS;
using Android.Widget;

namespace BrainChallenge.Droid.Controller
{
    [Activity(Label = "DetectiveGameController")]
    public class DetectiveGameController : Activity
    {
        private GridLayout _gameTileGrid;
        private TextView _scoreLabel;
        private ImageView _detectiveTargetImg;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(AppConst.targetTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DetectiveGame);

            _gameTileGrid = FindViewById<GridLayout>(Resource.Id.GameTileGrid);

            GridLayout.LayoutParams parm = new GridLayout.LayoutParams();

            //parm.ColumnSpec = 0;

            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}