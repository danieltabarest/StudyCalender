using GoogleLogin.Views;
using StudyCalender.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StudyCalender
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }
        public System.Windows.Input.ICommand SettingsCommand { get; }
        public MasterPage ()
		{
			InitializeComponent ();

            //SettingsCommand = new Command(() => { ));

            var masterPageItems = new List<MasterPageItem> ();
			masterPageItems.Add (new MasterPageItem {
				Title = "Contacts",
				IconSource = "contacts.png",
				TargetType = typeof(ContactsPage)
			});
			masterPageItems.Add (new MasterPageItem {
				Title = "TodoList",
				IconSource = "todo.png",
				TargetType = typeof(TodoListPage)
			});
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Google Profile Page",
                IconSource = "todo.png",
                TargetType = typeof(GoogleProfileCsPage)
            });
            masterPageItems.Add (new MasterPageItem {
				Title = "Reminders",
				IconSource = "reminders.png",
				TargetType = typeof(ReminderPage)
			});

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


            masterPageItems.Add(new MasterPageItem
            {
                Title = "TimeTable",
                IconSource = "ic_perm_contact_calendar_white_24dp.png",
                TargetType = typeof(TimeTable)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Grades",
                IconSource = "reminders.png",
                TargetType = typeof(Grades)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Subjects",
                IconSource = "reminders.png",
                TargetType = typeof(ReminderPage)
            });


            masterPageItems.Add(new MasterPageItem
            {
                Title = "Attendance",
                IconSource = "reminders.png",
                TargetType = typeof(ReminderPage)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Teachers",
                IconSource = "reminders.png",
                TargetType = typeof(Teachers)
            });


            masterPageItems.Add(new MasterPageItem
            {
                Title = "Recordings",
                IconSource = "reminders.png",
                TargetType = typeof(ReminderPage)
            });

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
	}
}
