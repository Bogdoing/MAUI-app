using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Data.SqlClient;
using Font = Microsoft.Maui.Font;

namespace MAUI.test;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private int count = 0;
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
    };

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        count++;
        BtnCount.Text = $"qwe {count}";


        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        string text = $"This is a Toast{count}";
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;

        var toast = Toast.Make(text, duration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
    }

    private async void Push_clicked(object sender, EventArgs e)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.Red,
            TextColor = Colors.Green,
            ActionButtonTextColor = Colors.Yellow,
            CornerRadius = new CornerRadius(10),
            Font = Font.SystemFontOfSize(14),
            ActionButtonFont = Font.SystemFontOfSize(14),
            CharacterSpacing = 0.5
        };

        string text = $"This is a Snackbar {count}";
        string actionButtonText = "Click Here to Dismiss";
        Action action = async () => await DisplayAlert("Snackbar ActionButton Tapped", "The user has tapped the Snackbar ActionButton", "OK");
        TimeSpan duration = TimeSpan.FromSeconds(3);

        var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

        await snackbar.Show(cancellationTokenSource.Token);

        //

        //await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }

    private async void OpenPwa_clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://bogdoing.github.io/");
        //GetAsync(sharedClient);
    }

    //static async Task GetAsync(HttpClient httpClient)
    //{
    //    using HttpResponseMessage response = await httpClient.GetAsync("todos/3");

    //    response.EnsureSuccessStatusCode().WriteRequestToConsole();

    //    var jsonResponse = await response.Content.ReadAsStringAsync();
    //    WriteLine($"{jsonResponse}\n");

    //    // Expected output:
    //    //   GET https://jsonplaceholder.typicode.com/todos/3 HTTP/ 1.1
    //    //   {
    //    //     "userId": 1,
    //    //     "id": 3,
    //    //     "title": "fugiat veniam minus",
    //    //     "completed": false
    //    //   }
    //}
}