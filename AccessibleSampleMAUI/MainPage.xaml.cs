using AccessibleSample.ResX;
using System.Collections.ObjectModel;
using System.Diagnostics;

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

    private async void ReadMeButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new Uri("https://github.com/gbarkerz/AccessibleSample/blob/master/README.md");

            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ReadMeButton_ClickedAsync: " + ex.Message);
        }
    }
}

public class SampleItemViewModel
{
    private ObservableCollection<SampleItemFestival> sampleItemsFestivals = new ObservableCollection<SampleItemFestival>();
    public ObservableCollection<SampleItemFestival> SampleItemsFestivals { get { return this.sampleItemsFestivals; } }

    private ObservableCollection<SampleItem> sampleItems = new ObservableCollection<SampleItem>();
    public ObservableCollection<SampleItem> SampleItems { get { return this.sampleItems; } }

    public SampleItemViewModel()
    {
        this.sampleItemsFestivals.Add(new SampleItemFestival()
        {
            Name = AppResources.ResourceManager.GetString("FestivalFirst")
        });

        this.sampleItemsFestivals.Add(new SampleItemFestival()
        {
            Name = AppResources.ResourceManager.GetString("FestivalSecond")
        });

        this.sampleItems.Add(new SampleItem()
        {
            Name = AppResources.ResourceManager.GetString("SongFirst"),
            NotAvailable = true
        });

        this.sampleItems.Add(new SampleItem()
        {
            Name = AppResources.ResourceManager.GetString("SongSecond"),
            NotAvailable = false
        });
    }
}

public class SampleItemFestival
{
    public string Name { get; set; }
}

public class SampleItem
{
    public string Name { get; set; }
    public bool NotAvailable { get; set; }

    public string SongItemAccessibleName
    {
        get
        {
            string accessibleName;

            // All Items shows the datasource's Name property text. If the datasource class has a NotAvailable
            // property of true, the Item also shows an icon informing users of this fact, and in that case the Item's
            // accessible name must be based on both the Name and NotAvailable properties. If the NotAvailable property
            // is false, the Item shows no icon, and the Item's accessible name can be set solely from its text.

            if (NotAvailable)
            {
                var resManager = AppResources.ResourceManager;

                accessibleName = String.Format(resManager.GetString("SampleItemSongAccessibleNotAvailableFormat"),
                                               Name,
                                               resManager.GetString("NotAvailable"));
            }
            else
            {
                accessibleName = Name;
            }

            return accessibleName;
        }
    }
}

