using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Leanback.Widget;
using Java.Lang.Annotation;
using Java.Net;
using Java.Util;

namespace droidtvtest
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.Leanback", Icon = "@drawable/videos_by_google_banner",
        MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape)]
    [IntentFilter(actions: new string[] { "android.intent.action.MAIN" }, Categories = new string[] { "android.intent.category.LEANBACK_LAUNCHER" })]
    public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LayoutHub);
        }
	}
}
