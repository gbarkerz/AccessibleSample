using System.Collections.ObjectModel;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Controls;

namespace AccessibleSampleUWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.ViewModel = new SampleItemViewModel();

            InaccessibleGroupBorder.BorderBrush = this.Foreground;
            AccessibleGroupBorder.BorderBrush = this.Foreground;
        }

        public SampleItemViewModel ViewModel { get; set; }
    }

    public class SampleItemViewModel
    {
        private ObservableCollection<SampleItem> sampleItems = new ObservableCollection<SampleItem>();
        public ObservableCollection<SampleItem> SampleItems { get { return this.sampleItems; } }

        public SampleItemViewModel()
        {
            var loader = new ResourceLoader();

            this.sampleItems.Add(new SampleItem()
            {
                Name = loader.GetString("First")
            });

            this.sampleItems.Add(new SampleItem()
            {
                Name = loader.GetString("Second")
            });
        }
    }

    public class SampleItem
    {
        public string Name { get; set; }
    }
}
