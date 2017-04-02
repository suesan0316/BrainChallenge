
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BrainChallenge.Droid.Mock
{
	[Activity(Label = "DetectiveGameController")]
	public class DetectiveGameController : Activity
	{
		private int failedcount = 0;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetTheme(AppConst.targetTheme);
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.DetectiveGame);

			var timer = new Timer();
			timer.Elapsed += (sender, args) => RunOnUiThread(() =>
			{ //コールバック
				System.Random r = new System.Random();
				var arry = new string[] { "detective_game_house1", "detective_game_house2", "detective_game_tree" };
				for (int i = 1; i <= 20; i++)
				{
					var index = Resources.GetIdentifier("button" + i, "id", this.PackageName);
					var button = FindViewById<ImageButton>(index);

					if (button.Tag != null)
					{
						button.Click += delegate {
							var dog = Resources.GetIdentifier("detective_game_dog", "drawable", this.PackageName);
							button.SetImageResource(dog);
						};
					}
					else
					{
						button.Click += delegate
						{
							var failed = Resources.GetIdentifier("detective_game_failed", "drawable", this.PackageName);
							button.SetImageResource(failed);
							failedcount++;
							if (failedcount == 3)
							{
								var next = new Intent(this, typeof(GameResultController));
								StartActivity(next);
							}
						};
					}

					int n = r.Next(3);
					var target = Resources.GetIdentifier(arry[n], "drawable", this.PackageName);
					button.SetImageResource(target);

				}
			});
			timer.Interval = 3000;
			timer.AutoReset = false;
			timer.Start();
		}
	}
}
