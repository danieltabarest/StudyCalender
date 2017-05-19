using Plugin.Messaging;

namespace StudyCalender.Helpers
{
    public static class SamplesExtensions
    {
        #region Methods

        public static void MakeSamplePhoneCall(this IPhoneCallTask phoneCall)
        {
            if (phoneCall.CanMakePhoneCall)
            {
                phoneCall.MakePhoneCall("+27219330000", "Xamarin Demo User");
            }
        }

        public static EmailMessageBuilder BuildSampleEmail(bool sendAsHtml = false)
        {
            var builder = new EmailMessageBuilder()
                .To("to.danieltabares17@gmail.com")
                .Cc("cc.danieltabares17@gmail.com")
                .Bcc(new[] { "bcc1.danieltabares17@gmail.com", "bcc2.danieltabares17@gmail.com" })
                .Subject("Study Calender FeedBack");

#if __ANDROID__ || __IOS__

            if (sendAsHtml)
                builder.BodyAsHtml("Well hello there from <b>Xam.Messaging.Plugin</b>");
#endif
            if (!sendAsHtml)
                builder.Body("Well hello there from Xam.Messaging.Plugin");

            return builder;
        }

        public static void SendSampleEmail(this IEmailTask emailTask, IEmailMessage email)
        {
            if (emailTask.CanSendEmail)
            {
                emailTask.SendEmail(email);
            }
        }

        public static void SendSampleEmail(this IEmailTask emailTask, bool sendAsHtml)
        {
            var email = BuildSampleEmail(sendAsHtml).Build();
            emailTask.SendSampleEmail(email);
        }

        public static void SendSampleSms(this ISmsTask smsTask)
        {
            if (smsTask.CanSendSms)
            {
                smsTask.SendSms("+27219330000", "Well hello there from Xam.Messaging.Plugin");
            }
        }

        public static void SendSampleBackgroundSms(this ISmsTask smsTask)
        {
            if (smsTask.CanSendSmsInBackground)
            {
                smsTask.SendSmsInBackground("+27219330000", "Well hello there from Xam.Messaging.Plugin");
            }
        }

        public static void SendSampleMultipleSms(this ISmsTask smsTask)
        {
            if (smsTask.CanSendSms)
            {
                smsTask.SendSms("+27219330000;+27219330001", "Well hello there from Xam.Messaging.Plugin");
            }
        }

        #endregion
    }
}