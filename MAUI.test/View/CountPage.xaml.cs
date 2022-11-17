namespace MAUI.test;

public partial class CountPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "count.txt");
    int count = 0;
    public CountPage()
    {
        InitializeComponent();

        if (File.Exists(_fileName))
        {
            LabelCount.Text = File.ReadAllText(_fileName);
            count = int.Parse(File.ReadAllText(_fileName));  // int.Parse(string)
        }
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        count++; 
        LabelCount.Text = count.ToString();
        // Save the file.
        File.WriteAllText(_fileName, LabelCount.Text);
    }


    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        //LabelCount.Text = string.Empty;
        count = 0;
        LabelCount.Text = "0";

    }
}