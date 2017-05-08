using System;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using BrainChallenge.Common.Client.ClientService.Implement;

namespace BrainChallenge.Droid.Controller
{
    [Activity(Label = "GameStartController")]
    public class GameStartController : Activity
    {
        private readonly GameStartService _service = new GameStartService();
        private ImageView _gameImage;
        private TextView _gameScore;
        private Button _returnButton;
        private TextView _selectGameTitle;
        private Button _gameStartButton;
        private Button _helpButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(AppConst.targetTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GameStart);

            _gameScore = FindViewById<TextView>(Resource.Id.gameScore);
            _selectGameTitle = FindViewById<TextView>(Resource.Id.selectGameTitle);
            _gameImage = FindViewById<ImageView>(Resource.Id.gameImage);
            _returnButton = FindViewById<Button>(Resource.Id.returnButton);
            _gameStartButton = FindViewById<Button>(Resource.Id.gameStartButton);
            _helpButton = FindViewById<Button>(Resource.Id.helpButton);

            var gameId = Intent.GetIntExtra("MyData", -1);

            var target = _service.GetGameDetail(gameId);

            _selectGameTitle.Text = target.GameName;
            _gameImage.SetBackgroundResource((int) typeof(Resource.Drawable).GetField(target.Title).GetValue(null));

            var scoreText = new StringBuilder();

            for (var i = 0; i < target.Score.Count; i++)
                scoreText.Append(i + 1 + "." + target.Score[i] + "\n");

            _gameScore.Text = scoreText.ToString();

            _gameStartButton.Click += delegate
            {
                var next = new Intent(this, Type.GetType("BrainChallenge.Droid.Controller." + target.Class));
                StartActivity(next);
            };

            _returnButton.Click += delegate
            {
                var next = new Intent(this, typeof(MenuController));
                StartActivity(next);
            };

            _helpButton.Click += delegate
            {
                var next = new Intent(this,typeof(HelpController));
                next.PutExtra("MyData", gameId);
                StartActivity(next);
            };
        }
    }
}