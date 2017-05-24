using CommonView.Animate;
using Xamarin.Forms;

namespace StudyCalender
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            try
            {

                base.OnAppearing();
                if (App.IsLoggedIn == false)
                {
                    App.IsLoggedIn = true;
                    await Animate.BallAnimate(this.logoImage, 50, 10, 5);
                }
            }
            catch (System.Exception ex)
            {
                var err = ex.Message;
            }

        }

    }
}

