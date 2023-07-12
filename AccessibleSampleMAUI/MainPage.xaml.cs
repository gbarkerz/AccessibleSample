﻿using AccessibleSample.ResX;
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
