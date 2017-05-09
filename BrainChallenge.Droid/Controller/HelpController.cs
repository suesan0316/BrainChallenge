using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using BrainChallenge.Common.Client.ClientService.Implement;
using BrainChallenge.Droid.Custom;

namespace BrainChallenge.Droid.Controller
{
    [Activity(Label = "HelpController")]
    public class HelpController : Activity
    {
        private readonly HelpService _service = new HelpService();
        private TextView _explain;
        private TextView _gameTitle;
        private MyPager _pager;
        private Button _returnButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(AppConst.targetTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Help);

            var gameId = Intent.GetIntExtra("MyData", -1);

            var target = _service.GetHelpModel(gameId);

            _pager = FindViewById<MyPager>(Resource.Id.viewpager);
            _explain = FindViewById<TextView>(Resource.Id.explain);
            _gameTitle = FindViewById<TextView>(Resource.Id.gameTitle);
            _returnButton = FindViewById<Button>(Resource.Id.returnButton);

            _gameTitle.Text = target.GameName + "ヘルプ";

            _explain.Text = target.Help[0].Explain;

            var pagerCatalog = new MyPagerCatalog(target.Help.Select((t, i) => new MyPagerPage
                {
                    Caption = "No." + (i + 1),
                    ImageId = (int) typeof(Resource.Drawable).GetField(t.HelpImage).GetValue(null)
                })
                .ToArray());

            _pager.Adapter = new MyPagerAdapter(this, pagerCatalog);

            _pager.PageSelected += delegate
            {
                var index = _pager.CurrentItem;
                _explain.Text = target.Help[index].Explain;
            };

            _returnButton.Click += delegate
            {
                // ゲームスタート画面へ遷移
                var next = new Intent(this, typeof(GameStartController));
                next.PutExtra("MyData", target.GameId);
                StartActivity(next);
            };
        }
    }
}