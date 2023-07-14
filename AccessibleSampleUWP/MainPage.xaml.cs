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
        public SampleItemViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.ViewModel = new SampleItemViewModel();

            // Ensure that the border around the controls groups has a strong contrast against
            // its background, regardless of whether the app is shown in light or dark mode.
            InaccessibleGroupBorder.BorderBrush = this.Foreground;
            AccessibleGroupBorder.BorderBrush = this.Foreground;
        }

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
        private ObservableCollection<SampleItemFestival> sampleItemsFestivals = new ObservableCollection<SampleItemFestival>();
        public ObservableCollection<SampleItemFestival> SampleItemsFestivals { get { return this.sampleItemsFestivals; } }

        private ObservableCollection<SampleItemSong> sampleItemsSongs = new ObservableCollection<SampleItemSong>();
        public ObservableCollection<SampleItemSong> SampleItemsSongs { get { return this.sampleItemsSongs; } }

        public SampleItemViewModel()
        {
            var loader = new ResourceLoader();

            this.sampleItemsFestivals.Add(new SampleItemFestival()
            {
                Name = loader.GetString("FestivalFirst")
            });

            this.sampleItemsFestivals.Add(new SampleItemFestival()
            {
                Name = loader.GetString("FestivalSecond")
            });

            this.sampleItemsSongs.Add(new SampleItemSong()
            {
                Name = loader.GetString("SongFirst"),
                NotAvailable = true
            });

            this.sampleItemsSongs.Add(new SampleItemSong()
            {
                Name = loader.GetString("SongSecond"),
                NotAvailable = false
            });
        }
    }

    public class SampleItemFestival
    {
        public string Name { get; set; }
    }

    public class SampleItemSong
    {
        public string Name { get; set; }
        public bool NotAvailable { get; set; }

        public string SongItemAccessibleName
        {
            get
            {
                var loader = new ResourceLoader();

                string accessibleName;

                if (NotAvailable)
                {
                    accessibleName = String.Format(loader.GetString("SampleItemSongAccessibleNotAvailableFormat"),
                                                   Name,
                                                   loader.GetString("NotAvailable"));
                }
                else
                {
                    accessibleName = Name;
                }

                return accessibleName;
            }
        }
    }
}
