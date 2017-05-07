using System;
using System.Xml;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace BrainChallenge.Droid.Controller
{
    [Activity(MainLauncher = true)]
    public class MenuController : Activity
    {
        private TableLayout _menuTable;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetTheme(AppConst.targetTheme);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);

            _menuTable = FindViewById<TableLayout>(Resource.Id.menuTable);

            var GameListTitleLinear = Util.GenerateView<LinearLayout>(this, "GameListTitleLinear");
            var GameTypeListTitle = Util.GenerateView<TextView>(this, "GameTypeListTitle");
            
            GameTypeListTitle.Text = "‹L‰¯—Í";
            GameListTitleLinear.AddView(GameTypeListTitle);
            _menuTable.AddView(GameListTitleLinear);

            var GameListScroll = Util.GenerateView<HorizontalScrollView>(this, "GameListScroll");

            var GameListLinaer = Util.GenerateView<LinearLayout>(this, "GameListLinaer");
            var GameLinaer = Util.GenerateView<LinearLayout>(this, "GameLinaer");

            var GameButton = Util.GenerateView<ImageButton>(this, "GameButton");
            GameButton.SetBackgroundResource(Resource.Drawable.detective_game_icon);

            var GameTitle = Util.GenerateView<TextView>(this, "GameTitle");
            GameTitle.Text = "–ÀŽq‚ð’T‚¹!!";

            GameLinaer.AddView(GameButton);
            GameLinaer.AddView(GameTitle);

            GameListLinaer.AddView(GameLinaer);

            GameListScroll.AddView(GameListLinaer);

            _menuTable.AddView(GameListScroll);

        }
    }
}