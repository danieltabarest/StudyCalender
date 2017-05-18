using StudyCalender.Core.ViewModels;
using System;
using Xamarin.Forms;

namespace StudyCalender.Pages
{
    public partial class CalendarsPage : ContentPage
    {
        XamForms.Controls.Calendar calendar;
        CalendarsViewModel vm;
        public CalendarsPage()
        {
            InitializeComponent();
            CreateCalender();
            calendar.SpecialDates.Add(new XamForms.Controls.SpecialDate(DateTime.Now.AddDays(5)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
            calendar.SpecialDates.Add(new XamForms.Controls.SpecialDate(DateTime.Now.AddDays(6)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
            calendar.RaiseSpecialDatesChanged();
            
            //BindingContext = ViewModelProvider.GetViewModel<CalendarsViewModel>(vm => vm.Navigator = new Navigator(this));
        }
        private void CreateCalender()
        {
            calendar = new XamForms.Controls.Calendar
            {
                //MaxDate=DateTime.Now.AddDays(30), 
                MinDate = DateTime.Now.AddDays(-1),
                MultiSelectDates = true,
                DisableAllDates = false,
                WeekdaysShow = true,
                ShowNumberOfWeek = true,
                ShowNumOfMonths = 1,
                EnableTitleMonthYearView = true,
                SelectedDate = DateTime.Now,
                WeekdaysTextColor = Color.Teal,
                StartDay = DayOfWeek.Monday,
                SelectedTextColor = Color.Fuchsia,
                //SpecialDates = new List<SpecialDate>{
                //    new SpecialDate(DateTime.Now.AddDays(2)) { BackgroundColor = Color.Green, TextColor = Color.Accent, BorderColor = Color.Lime, BorderWidth=8, Selectable = true },
                //    new SpecialDate(DateTime.Now.AddDays(3))
                //    {
                //        BackgroundColor = Color.Green,
                //        TextColor = Color.Blue,
                //        Selectable = true,
                //        BackgroundPattern = new BackgroundPattern(1)
                //        {
                //            Pattern = new List<Pattern>
                //            {
                //                new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Red},
                //                new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Purple},
                //                new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Green},
                //                new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Yellow}
                //            }
                //        }
                //    }
                //}
            };

            calendar.DateClicked += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine(calendar.SelectedDates);
                vm.CalendarClick(calendar.SelectedDates);
            };
            vm = new CalendarsViewModel();//new CalendarsViewModel();//
            calendar.SetBinding(XamForms.Controls.Calendar.DateCommandProperty, nameof(vm.DateChosen));
            calendar.SetBinding(XamForms.Controls.Calendar.SelectedDateProperty, nameof(vm.Date));
            calendar.BindingContext = vm;
            StackCalendars.Children.Add(calendar);

            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    BackgroundColor = Color.White,
            //    Content = new ScrollView
            //    {
            //        Content = new StackLayout
            //        {
            //            Padding = new Thickness(5, Device.OS == TargetPlatform.iOS ? 25 : 5, 5, 5),
            //            Children = {
            //                calendar
            //            }
            //        }
            //    }
            //};
        }
    }
}
