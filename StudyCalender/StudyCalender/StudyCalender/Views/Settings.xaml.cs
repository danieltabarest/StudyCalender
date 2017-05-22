
using StudyCalender.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public partial class Settings : ContentPage
    {
        public ObservableCollection<ModelSettings> modelSettings { get; set; }
        private SettingsViewModel ViewModel
        {
            get { return BindingContext as SettingsViewModel; }


        }

        public Settings()
        {
            InitializeComponent();

            modelSettings = new ObservableCollection<ModelSettings>();
            modelSettings.Add(new ModelSettings { Name = "General", Type = "Fruit", Image = "ic_help_black_24dp.png" });
            modelSettings.Add(new ModelSettings { Name = "Accounts", Type = "Vegetable", Image = "ic_help_black_24dp.png" });
            modelSettings.Add(new ModelSettings { Name = "Contact us", Type = "Vegetable", Image = "ic_help_black_24dp.png" });
            modelSettings.Add(new ModelSettings { Name = "Remove ads", Type = "Vegetable", Image = "ic_card_membership_black_24dp.png" });
            lstView.ItemsSource = modelSettings;

            lstView.ItemTapped += (sender, args) =>
            {
                if (lstView.SelectedItem == null)
                    return;
                this.Navigation.PushAsync(new SettingsDetailsView(lstView.SelectedItem as ModelSettings));
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
