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
            // 共通のテーマを適用
            SetTheme(AppConst.targetTheme);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Menu);

            // サービスの初期化を実行
            ServiceIinitializer.Initialize(
                new ServiceInitializeModel {DbPath = GetLocalFilePath("brainchallenge.db3")});

            _menuTable = FindViewById<TableLayout>(Resource.Id.menuTable);

            // ゲームの一覧情報を取得
            var gameModels = _service.GetGameList();

            // ゲームの種別ごとに水平スクロールにゲームの一覧情報を表示します
            foreach (var type in gameModels)
            {
                // ゲーム情報が3つを満たない場合、準備中のImgaeButtonを設定する
                var min = 3;

                // ゲーム種別のラオナー
                var gameListTitleLinear = Util.GenerateView<LinearLayout>(this, "GameListTitleLinear");
                // ゲーム種別のタイトル
                var gameTypeListTitle = Util.GenerateView<TextView>(this, "GameTypeListTitle");

                gameTypeListTitle.Text = type.Key;
                gameListTitleLinear.AddView(gameTypeListTitle);
                _menuTable.AddView(gameListTitleLinear);

                // ゲーム一覧の水平スクロール
                var gameListScroll = Util.GenerateView<HorizontalScrollView>(this, "GameListScroll");
                // ゲーム一覧のライナー
                var gameListLinaer = Util.GenerateView<LinearLayout>(this, "GameListLinaer");

                foreach (var gameModel in type.Value)
                {
                    // ゲーム情報のライナー
                    var gameLinaer = Util.GenerateView<LinearLayout>(this, "GameLinaer");
                    // ゲームのイメージボタン
                    var gameButton = Util.GenerateView<ImageButton>(this, "GameButton");
                    gameButton.SetBackgroundResource((int) typeof(Resource.Drawable).GetField(gameModel.Icon)
                        .GetValue(null));

                    //　ゲームのボタンのクリックアクションを設定
                    gameButton.Click += delegate
                    {
                        // ゲームスタート画面へ遷移
                        var next = new Intent(this, typeof(GameStartController));
                        next.PutExtra("MyData", gameModel.GameId);
                        StartActivity(next);
                    };

                    //ゲームのタイトル
                    var gameTitle = Util.GenerateView<TextView>(this, "GameTitle");
                    gameTitle.Text = gameModel.GameName;

                    gameLinaer.AddView(gameButton);
                    gameLinaer.AddView(gameTitle);
                    gameListLinaer.AddView(gameLinaer);

                    min--;
                }

                // ゲームの一覧が3つ以上になるまで、準備中ボタンを設定する
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