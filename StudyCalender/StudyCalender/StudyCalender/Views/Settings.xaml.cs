
using StudyCalender.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public partial class Settings : ContentPage
    {
        public ObservableCollection<MasterPageItem> modelSettings { get; set; }
        private SettingsViewModel ViewModel
        {
            get { return BindingContext as SettingsViewModel; }


        }

        public Settings()
        {
            InitializeComponent();

            modelSettings = new ObservableCollection<MasterPageItem>();
            //modelSettings.Add(new MasterPageItem { Title = "General", TargetType = typeof(AboutPage), IconSource = "ic_help_black_24dp.png" });
            modelSettings.Add(new MasterPageItem { Title = "Accounts", TargetType = typeof(Accounts), IconSource = "ic_help_black_24dp.png" });
            modelSettings.Add(new MasterPageItem { Title = "Contact us", TargetType = typeof(Feedback), IconSource = "ic_help_black_24dp.png" });
            modelSettings.Add(new MasterPageItem { Title = "Remove ads", TargetType = typeof(AboutPage), IconSource = "ic_card_membership_black_24dp.png" });
            modelSettings.Add(new MasterPageItem { Title = "About", TargetType = typeof(AboutPage), IconSource = "ic_card_membership_black_24dp.png" });
            lstView.ItemsSource = modelSettings;

            lstView.ItemTapped += (sender, args) =>
            {
                if (lstView.SelectedItem == null)
                    return;

                var item = lstView.SelectedItem as MasterPageItem;
                this.Navigation.PushAsync((Page)Activator.CreateInstance(item.TargetType));
                /*this.Navigation.PushAsync(new SettingsDetailsView(lstView.SelectedItem as ModelSettings));*/
                lstView.SelectedItem = null;
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
    public class ModelSettings
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Description { get; internal set; }
    }

}
