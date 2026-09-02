using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    LaunchMode = LaunchMode.SingleTask,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public static MainActivity Instance { get; private set; }

    protected override void OnCreate(Bundle savedInstanceState)
    {

        base.OnCreate(savedInstanceState);
        Window.SetBackgroundDrawableResource(Android.Resource.Color.Transparent);
        Instance = this;

    }
    
    public void OpenActivity()
    {

        var context = Platform.CurrentActivity ?? Android.App.Application.Context;
		var intent = new Intent();
		intent.SetClassName(context.PackageName, "com.unity3d.player.UnityPlayerActivity");
		if (context is not Activity)
		{
			intent.AddFlags(ActivityFlags.NewTask);
		}
		context.StartActivity(intent);
    }
}
