using System.Reflection;
using Android.App;
using Android.OS;
using Xamarin.Android.NUnitLite;

namespace BrainChallenge.Common.Tests
{
    [Activity(Label = "BrainChallenge.Common.Tests", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : TestSuiteActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            AddTest(Assembly.GetExecutingAssembly());

            TestData.InitDataBase();

            base.OnCreate(bundle);
        }
    }
}

