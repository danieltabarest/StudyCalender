
using System;
using Xamarin.Forms;

namespace StudyCalender.Views
{
    public partial class Feedback : ContentPage
    {
        public Feedback()
        {
            InitializeComponent();
            try
            {
                Device.OpenUri(new Uri("mailto:ryan.hatfield@test.com"));
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
