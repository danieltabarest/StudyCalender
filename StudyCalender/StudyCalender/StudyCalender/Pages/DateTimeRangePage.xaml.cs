using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCalender.Core.Helpers;
using StudyCalender.Core.ViewModels;
using StudyCalender.Helpers;
using System;
using Xamarin.Forms;

namespace StudyCalender.Pages
{
    public partial class DateTimeRangePage : ContentPage
    {
        XamForms.Controls.Calendar calendar;
        DateTimeRangeViewModel vm;
        public DateTimeRangePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            
            if (calendar == null)
            {
                CreateCalender();
                //calendar.SpecialDates.Add(new XamForms.Controls.SpecialDate(DateTime.Now.AddDays(5)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
                //calendar.SpecialDates.Add(new XamForms.Controls.SpecialDate(DateTime.Now.AddDays(6)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
                //calendar.RaiseSpecialDatesChanged();
                IsBusy = false;
            }
            //calendar.SelectedDate = null;
            //calendar.SelectedBorderColor= Color.White;

            base.OnAppearing();
        }

        private void CreateCalender()
        {
            calendar = new XamForms.Controls.Calendar
            {
                //MaxDate=DateTime.Now.AddDays(30), 
                MinDate = DateTime.Now.AddDays(-1),
                MultiSelectDates = false,
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
                if (calendar.SelectedDates.Count() == 0)
                {
                    return;
                }
                vm.CalendarClick(calendar.SelectedDates, new Navigator(this));
            };
            vm = GlobalInfo.DateTimeRangeViewModel;// new DateTimeRangeViewModel();//new CalendarsViewModel();//
            calendar.SetBinding(XamForms.Controls.Calendar.DateCommandProperty, nameof(vm.DateChosen));
            calendar.SetBinding(XamForms.Controls.Calendar.SelectedDateProperty, nameof(vm.Date));
            //calendar.BindingContext = ViewModelProvider.GetViewModel<CalendarsViewModel>(vm => vm.Navigator = new Navigator(this)); ;
            StackCalendars.Children.Add(calendar);

        }
    }
}
