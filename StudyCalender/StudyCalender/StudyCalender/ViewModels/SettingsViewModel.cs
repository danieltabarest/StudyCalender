using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StudyCalender.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
            Title = "Settings";
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }

        private Command loadItemsCommand;
        /// <summary>
        /// Command to load/refresh items
        /// </summary>
        public Command LoadItemsCommand
        {
            get { return loadItemsCommand ?? (loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand())); }
        }


        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            //var error = false;
            //try
            //{
            //    var responseString = string.Empty;
            //    using (var httpClient = new HttpClient())
            //    {
            //        var feed = "http://feeds.hanselman.com/ScottHanselman";
            //        responseString = await httpClient.GetStringAsync(feed);
            //    }

            //    FeedItems.Clear();
            //    var items = await ParseFeed(responseString);
            //    foreach (var item in items)
            //    {
            //        FeedItems.Add(item);
            //    }
            //}
            //catch
            //{
            //    error = true;
            //}

            //if (error)
            //{
            //    var page = new ContentPage();
            //    await page.DisplayAlert("Error", "Unable to load blog.", "OK");

            //}

            IsBusy = false;
        }

    }
}
