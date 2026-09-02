namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object? sender, EventArgs e)
	{
		OpenUnityActivity();

	}
	async void OpenUnityActivity()
	{
		var status = await Permissions.RequestAsync<Permissions.Camera>();
		if (status != PermissionStatus.Granted)
		{
			return;
		}
		else
		{			
			#if ANDROID
			MainActivity.Instance.OpenActivity();
			#endif
		}
	}
}
