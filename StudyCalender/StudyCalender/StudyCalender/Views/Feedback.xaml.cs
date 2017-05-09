
using System;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public partial class Feedback : ContentPage
    {
        public Feedback()
        {
            try
            {
                InitializeComponent();
                Device.OpenUri(new Uri("mailto:ryan.hatfield@test.com"));
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
