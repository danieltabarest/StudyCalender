using StudyCalender.Core.ViewModels;
using StudyCalender.ViewModels;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = new LoginViewModel();
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}
