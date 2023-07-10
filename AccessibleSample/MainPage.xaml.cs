using AccessibleSample.ResX;
using System.Collections.ObjectModel;

namespace AccessibleSample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    public SampleItemViewModel ViewModel { get; set; }

    private async void PlayButton_Clicked(object sender, EventArgs e)
    {
        var resManager = AppResources.ResourceManager;

        await DisplayAlert(
            resManager.GetString("AppName"),
            resManager.GetString("PlayButtonClicked"),
            resManager.GetString("OK"));
    }
}

public class SampleItemViewModel
{
    private ObservableCollection<SampleItem> sampleItems = new ObservableCollection<SampleItem>();
    public ObservableCollection<SampleItem> SampleItems { get { return this.sampleItems; } }

    public SampleItemViewModel()
    {
        this.sampleItems.Add(new SampleItem()
        {
            Name = AppResources.ResourceManager.GetString("SongFirst")
        }); ;

        this.sampleItems.Add(new SampleItem()
        {
            Name = AppResources.ResourceManager.GetString("SongSecond")
        });
    }
}

public class SampleItem
{
    public string Name { get; set; }
}

