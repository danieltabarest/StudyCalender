using GoogleLogin.Views;
using Plugin.Media;
using StudyCalender.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using System;

namespace StudyCalender
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }
        public System.Windows.Input.ICommand SettingsCommand { get; }

        public System.Windows.Input.ICommand PhotoCommand { get; }
        public MasterPage ()
		{
			InitializeComponent ();
            this.SettingsCommand = new Command(this.SettingsCommandExecute);
            this.PhotoCommand = new Command(this.PhotoCommandExecute);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {

                try
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                        return;
                    }
                    var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    });


                    if (file == null)
                        return;

                    image.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                }
                catch (Exception ex)
                {

                    throw;
                }
            };
            image.GestureRecognizers.Add(tapGestureRecognizer);
          

                var masterPageItems = new List<MasterPageItem> ();
			//masterPageItems.Add (new MasterPageItem {
			//	Title = "Contacts",
			//	IconSource = "contacts.png",
			//	TargetType = typeof(ContactsPage)
			//});
            //masterPageItems.Add (new MasterPageItem {
            //	Title = "TodoList",
            //	IconSource = "todo.png",
            //	TargetType = typeof(TodoListPage)
            //});
            //         masterPageItems.Add(new MasterPageItem
            //         {
            //             Title = "Google Profile Page",
            //             IconSource = "todo.png",
            //             TargetType = typeof(GoogleProfileCsPage)
            //         });
            //         masterPageItems.Add (new MasterPageItem {
            //	Title = "Reminders",
            //	IconSource = "reminders.png",
            //	TargetType = typeof(ReminderPage)
            //});

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Overview",
                IconSource = "reminders.png",
                TargetType = typeof(Overview)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Agenda",
                IconSource = "reminders.png",
                TargetType = typeof(Agenda)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Calender",
                IconSource = "reminders.png",
                TargetType = typeof(Calender)
            });


            //         masterPageItems.Add(new MasterPageItem
            //         {
            //             Title = "TimeTable",
            //             IconSource = "ic_perm_contact_calendar_white_24dp.png",
            //             TargetType = typeof(TimeTable)
            //         });

            //         masterPageItems.Add(new MasterPageItem
            //         {
            //             Title = "Grades",
            //             IconSource = "reminders.png",
            //             TargetType = typeof(Grades)
            //         });

            //         masterPageItems.Add(new MasterPageItem
            //         {
            //             Title = "Subjects",
            //             IconSource = "reminders.png",
            //             TargetType = typeof(ReminderPage)
            //         });


            //         masterPageItems.Add(new MasterPageItem
            //         {
            //             Title = "Attendance",
            //             IconSource = "reminders.png",
            //             TargetType = typeof(ReminderPage)
            //         });

            //         masterPageItems.Add(new MasterPageItem
            //         {
            //             Title = "Teachers",
            //             IconSource = "reminders.png",
            //             TargetType = typeof(Teachers)
            //         });


            //         masterPageItems.Add(new MasterPageItem
            //         {
            //             Title = "Recordings",
            //             IconSource = "reminders.png",
            //             TargetType = typeof(ReminderPage)
            //         });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Remove ads",
                IconSource = "reminders.png",
                TargetType = typeof(ReminderPage)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Helps and feedback",
                IconSource = "reminders.png",
                TargetType = typeof(AboutPage)
            });

            listView.ItemsSource = masterPageItems;
		}

        private void SettingsCommandExecute(object obj)
        {
            //throw new NotImplementedException();
        }

        private async void PhotoCommandExecute(object obj)
        {
            this.IsBusy = true;

            // Show incoming call
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });


            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
            this.IsBusy = false;
        }

    }
}
