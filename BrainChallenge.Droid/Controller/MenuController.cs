using System.IO;
using Android.App;
using Android.Content;
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
        private readonly MenuService _service = new MenuService();
        private TableLayout _menuTable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(AppConst.targetTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

            ServiceIinitializer.Initialize(
                new ServiceInitializeModel {DbPath = GetLocalFilePath("brainchallenge.db3")});

            _menuTable = FindViewById<TableLayout>(Resource.Id.menuTable);


            var gameModels = _service.GetGameList();

            foreach (var type in gameModels)
            {
                var min = 3;

                var gameListTitleLinear = Util.GenerateView<LinearLayout>(this, "GameListTitleLinear");
                var gameTypeListTitle = Util.GenerateView<TextView>(this, "GameTypeListTitle");

                gameTypeListTitle.Text = type.Key;
                gameListTitleLinear.AddView(gameTypeListTitle);
                _menuTable.AddView(gameListTitleLinear);

                var gameListScroll = Util.GenerateView<HorizontalScrollView>(this, "GameListScroll");

                var gameListLinaer = Util.GenerateView<LinearLayout>(this, "GameListLinaer");

                foreach (var gameModel in type.Value)
                {
                    var gameLinaer = Util.GenerateView<LinearLayout>(this, "GameLinaer");

                    var gameButton = Util.GenerateView<ImageButton>(this, "GameButton");
                    gameButton.SetBackgroundResource((int) typeof(Resource.Drawable).GetField(gameModel.Icon)
                        .GetValue(null));

                    gameButton.Click += delegate
                    {
                        var next = new Intent(this, typeof(GameStartController));
                        next.PutExtra("MyData", gameModel.GameId);
                        StartActivity(next);
                    };

                    var gameTitle = Util.GenerateView<TextView>(this, "GameTitle");
                    gameTitle.Text = gameModel.GameName;

                    gameLinaer.AddView(gameButton);
                    gameLinaer.AddView(gameTitle);

                    gameListLinaer.AddView(gameLinaer);

                    min--;
                }

                for (var i = 0; i < min; i++)
                {
                    var gameLinaer = Util.GenerateView<LinearLayout>(this, "GameLinaer");

                    var gameButton = Util.GenerateView<ImageButton>(this, "NoOpenGameButton");
                    gameButton.SetBackgroundResource(Resource.Drawable.noopen);

                    var gameTitle = Util.GenerateView<TextView>(this, "NoOpenGameTitle");

                    gameLinaer.AddView(gameButton);
                    gameLinaer.AddView(gameTitle);

                    gameListLinaer.AddView(gameLinaer);
                }

                gameListScroll.AddView(gameListLinaer);

                _menuTable.AddView(gameListScroll);
            }
        }

        private static string GetLocalFilePath(string filename)
        {
            //指定されたファイルのパスを取得します。なければ作成してそのパスを返却します
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}