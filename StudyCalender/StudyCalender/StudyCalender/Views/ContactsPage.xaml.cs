using CommonView.Animate;
using Xamarin.Forms;

namespace StudyCalender
{
	public partial class ContactsPage : ContentPage
	{
		public ContactsPage ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Animate.BallAnimate(this.logoImage, 50, 10, 5);
        }

    }
}

