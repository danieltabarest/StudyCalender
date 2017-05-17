using System.Windows.Input;
using StudyCalender.Helpers;
using Xamarin.Forms;
using Plugin.Messaging;
using System;

namespace StudyCalender.Views
{
    public partial class Feedback : ContentPage
    {
        public Feedback()
        {
            try
            {
                InitializeComponent();
                SendEmail();
                //SendEmailCommand = new Command(SendEmail);
                //SendHtmlEmailCommand = new Command(SendHtmlEmail);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public ICommand SendEmailCommand { get; set; }
        public ICommand SendHtmlEmailCommand { get; set; }

        private void SendEmail()
        {
            CrossMessaging.Current.EmailMessenger.SendSampleEmail(false);
        }

        private void SendHtmlEmail()
        {
            CrossMessaging.Current.EmailMessenger.SendSampleEmail(true);
        }
    }
}
