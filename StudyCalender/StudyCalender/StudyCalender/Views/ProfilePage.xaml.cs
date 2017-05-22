
using StudyCalender.Core.ViewModels;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = MainPageViewModel.GetInstance();
        }
    }
}
