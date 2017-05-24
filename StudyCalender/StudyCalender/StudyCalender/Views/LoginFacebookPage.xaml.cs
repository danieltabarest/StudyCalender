
using StudyCalender.Core.ViewModels;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public partial class LoginFacebookPage : ContentPage
    {
        public LoginFacebookPage()
        {
            InitializeComponent();
            //BindingContext = MainPageViewModel.GetInstance();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
         //   SendEmail();
        }
    }
}
