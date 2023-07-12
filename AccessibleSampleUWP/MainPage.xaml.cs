using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
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

        private async void PlayButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ShowResponse(true);
        }

        private async void PauseButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ShowResponse(false);
        }

        private async Task ShowResponse(bool playButtonClicked)
        {
            var loader = new ResourceLoader();

            var dlg = new MessageDialog(
                loader.GetString(playButtonClicked ? "PlayButtonResponse" : "PauseButtonResponse"),
                loader.GetString("AppName"));
            await dlg.ShowAsync();
        }
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
                Name = loader.GetString("SongFirst"),
                NotAvailable = true
            });

            this.sampleItems.Add(new SampleItem()
            {
                Name = loader.GetString("SongSecond"),
                NotAvailable = false
            });
        }
    }

    public class SampleItem
    {
        public string Name { get; set; }
        public bool NotAvailable { get; set; }

        public string SongItemAccessibleName
        { 
            get
            {
                var loader = new ResourceLoader();

                // Assume fixed ordering of strings parts is acceptable.
                return Name + (NotAvailable ? ", " + loader.GetString("NotAvailable") : "");
            }
        }
    }
}
