
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BrainChallenge.Droid.Mock
{
	[Activity(Label = "GameStartController")]
	public class GameStartController : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetTheme(AppConst.targetTheme);

			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.GameStart);

			var returnButton = FindViewById<Button>(Resource.Id.returnButton);
			returnButton.Click += delegate
			{
				var next = new Intent(this, typeof(MenuController));
				StartActivity(next);
			};

			string nextInfo = Intent.GetStringExtra("MyData") ?? "Data not available";

			var gameStartButton = FindViewById<Button>(Resource.Id.gameStartButton);
			gameStartButton.Click += delegate
			{
				var next = new Intent(this, Type.GetType("BrainChallenge.Droid.Mock." + nextInfo));
				StartActivity(next);
			};

			var helpButton = FindViewById<Button>(Resource.Id.helpButton);
			helpButton.Click += delegate
			{
				var next = new Intent(this, typeof(HelpController));
				StartActivity(next);
			};
		}
	}
}
