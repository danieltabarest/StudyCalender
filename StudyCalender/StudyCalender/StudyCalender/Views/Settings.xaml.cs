
using StudyCalender.ViewModels;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public partial class Settings : ContentPage
    {
        private SettingsViewModel ViewModel
        {
            get { return BindingContext as SettingsViewModel; }
        }

        public Settings()
        {
            InitializeComponent();

            listView.ItemTapped += (sender, args) =>
            {
                if (listView.SelectedItem == null)
                    return;
                //this.Navigation.PushAsync(new BlogDetailsView(listView.SelectedItem as FeedItem));
                listView.SelectedItem = null;
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy /*|| ViewModel.FeedItems.Count > 0*/)
                return;

            ViewModel.LoadItemsCommand.Execute(null);
        }
    }


}
