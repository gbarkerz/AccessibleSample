using System.Collections.ObjectModel;
using Windows.ApplicationModel.Resources;

namespace AccessibleSample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    public SampleItemViewModel ViewModel { get; set; }
}

public class SampleItemViewModel
{
    private ObservableCollection<SampleItem> sampleItems = new ObservableCollection<SampleItem>();
    public ObservableCollection<SampleItem> SampleItems { get { return this.sampleItems; } }

    public SampleItemViewModel()
    {
        //        var loader = new ResourceLoader();

        this.sampleItems.Add(new SampleItem()
        {
            Name = "First"
        }); ;

        this.sampleItems.Add(new SampleItem()
        {
            Name = "Second"
        });
    }
}

public class SampleItem
{
    public string Name { get; set; }
}

