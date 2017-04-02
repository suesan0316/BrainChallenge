using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;

namespace BrainChallenge.Droid.Mock
{
	[Activity(Label = "HelpController")]
	public class HelpController : Activity
	{
		MyPagerCatalog pagerCatalog;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			SetTheme(AppConst.targetTheme);
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Help);

			var viewPager = FindViewById<MyPager>(Resource.Id.viewpager);

			pagerCatalog = new MyPagerCatalog();

			viewPager.Adapter = new MyPagerAdapter(this, pagerCatalog);

			var returnButton = FindViewById<Button>(Resource.Id.returnButton);
			returnButton.Click += delegate
			{
				var next = new Intent(this, typeof(GameStartController));
				StartActivity(next);
			};

			viewPager.PageSelected += delegate {
				var dat = viewPager.CurrentItem;
				var text = FindViewById<TextView>(Resource.Id.textView2);
				text.Text = "ゲームのヘルプ"+(dat + 1)+"です\nゲームの説明を表示";
			};
		}
	}
}
