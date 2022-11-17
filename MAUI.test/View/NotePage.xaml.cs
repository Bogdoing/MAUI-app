namespace MAUI.test;

public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    int count_sell = 0;

    public NotePage()
    {
        InitializeComponent();

        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
#if ANDROID
        TableViewData.HeightRequest = 450;
#elif WINDOWS
        TableViewData.HeightRequest = 250;
#endif
    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, TextEditor.Text); // Save the file.

        DateTime dt = DateTime.Now;
        string time_str = dt.ToString("HH:mm:s"); // DATA TIME
        count_sell++;
        if(TextEditor.Text == "") {
            //var ob = new TextCell { Text = $"{count_sell}. ({time_str})", Detail = "NOT TXT" };          
            TableRootSec.Add(new TextCell { Text = $"{count_sell}. ({time_str})", Detail = "NOT TXT" }); 
        }else { 
            TableRootSec.Add(new TextCell { Text = $"#{count_sell}  + {time_str}", Detail = TextEditor.Text }); 
        }
        
    }
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        TextEditor.Text = string.Empty;
    }
}