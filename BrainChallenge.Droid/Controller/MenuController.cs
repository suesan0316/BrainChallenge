using Android.App;
using Android.OS;
using Android.Widget;
using BrainChallenge.Common.Client.ClientModel;
using BrainChallenge.Common.Client.ClientService.Implement;
using Environment = System.Environment;

namespace BrainChallenge.Droid.Controller
{
    [Activity(MainLauncher = true)]
    public class MenuController : Activity
    {
        private TableLayout _menuTable;

        private readonly MenuService _service = new MenuService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(AppConst.targetTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

            ServiceIinitializer.Initialize(new ServiceInitializeModel {DbPath = GetLocalFilePath("brainchallenge.db3") });

            _menuTable = FindViewById<TableLayout>(Resource.Id.menuTable);


            var gameModels = _service.GetGameList();

            foreach (var type in gameModels)
            {

                int min = 3;

                var GameListTitleLinear = Util.GenerateView<LinearLayout>(this, "GameListTitleLinear");
                var GameTypeListTitle = Util.GenerateView<TextView>(this, "GameTypeListTitle");

                GameTypeListTitle.Text = type.Key;
                GameListTitleLinear.AddView(GameTypeListTitle);
                _menuTable.AddView(GameListTitleLinear);

                var GameListScroll = Util.GenerateView<HorizontalScrollView>(this, "GameListScroll");

                var GameListLinaer = Util.GenerateView<LinearLayout>(this, "GameListLinaer");

                foreach (var gameModel in type.Value)
                {
                    var GameLinaer = Util.GenerateView<LinearLayout>(this, "GameLinaer");

                    var GameButton = Util.GenerateView<ImageButton>(this, "GameButton");
                    GameButton.SetBackgroundResource((int)typeof(Resource.Drawable).GetField(gameModel.Icon).GetValue(null));

                    var GameTitle = Util.GenerateView<TextView>(this, "GameTitle");
                    GameTitle.Text = gameModel.GameName;

                    GameLinaer.AddView(GameButton);
                    GameLinaer.AddView(GameTitle);

                    GameListLinaer.AddView(GameLinaer);

                    min--;
                }

                for (int i = 0; i < min; i++)
                {
                    var GameLinaer = Util.GenerateView<LinearLayout>(this, "GameLinaer");

                    var GameButton = Util.GenerateView<ImageButton>(this, "NoOpenGameButton");
                    GameButton.SetBackgroundResource(Resource.Drawable.noopen);

                    var GameTitle = Util.GenerateView<TextView>(this, "NoOpenGameTitle");

                    GameLinaer.AddView(GameButton);
                    GameLinaer.AddView(GameTitle);

                    GameListLinaer.AddView(GameLinaer);
                }

                GameListScroll.AddView(GameListLinaer);

                _menuTable.AddView(GameListScroll);
            }
        }

        private  string GetLocalFilePath(string filename)
        {
            //指定されたファイルのパスを取得します。なければ作成してそのパスを返却します
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }

    }
}