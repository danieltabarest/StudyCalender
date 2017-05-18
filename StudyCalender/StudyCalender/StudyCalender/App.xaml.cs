using StudyCalender.Core.Helpers;
using StudyCalender.Core.Services;
using StudyCalender.Core.ViewModels;
using StudyCalender.Helpers;
using StudyCalender.Pages;
using StudyCalender.Services;
using StudyCalender.Views;
using XamForms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StudyCalender
{
    public partial class App : Application
    {
        Calendar calendar;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IReportingService, ReportingService>();
            DependencyService.Register<ViewProvider>();

            RegisterViews();

            var viewProvider = DependencyService.Get<ViewProvider>();


            //MainPage = new MainPage();

            ///MainPage = new NavigationPage(viewProvider.GetView(ViewModelProvider.GetViewModel<CalendarsViewModel>()) as Page);

            //SetMainPage();
            CreateCalender();

        }

        private void CreateCalender()
        {
            calendar = new Calendar
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
            };
            var vm = new CalendarVM();
            calendar.SetBinding(Calendar.DateCommandProperty, nameof(vm.DateChosen));
            calendar.SetBinding(Calendar.SelectedDateProperty, nameof(vm.Date));
            calendar.BindingContext = vm;

            // The root page of your application
            MainPage = new ContentPage
            {
                BackgroundColor = Color.White,
                Content = new ScrollView
                {
                    Content = new StackLayout
                    {
                        Padding = new Thickness(5, Device.OS == TargetPlatform.iOS ? 25 : 5, 5, 5),
                        Children = {
                            calendar
                        }
                    }
                }
            };
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }


        private void RegisterViews()
        {
            var viewProvider = DependencyService.Get<ViewProvider>();

            viewProvider.Register<CalendarsViewModel, CalendarsPage>();
            viewProvider.Register<CalendarEditorViewModel, CalendarEditorPage>();
            viewProvider.Register<DateTimeRangeViewModel, DateTimeRangePage>();
            viewProvider.Register<EventsViewModel, EventsPage>();
            viewProvider.Register<EventEditorViewModel, EventEditorPage>();
            viewProvider.Register<ReminderEditorViewModel, ReminderEditorPage>();
        }
        #region Lifecycle stuff

        protected override void OnStart()
        {
            // Handle when your app starts
            calendar.SpecialDates.Add(new SpecialDate(DateTime.Now.AddDays(5)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
            calendar.SpecialDates.Add(new SpecialDate(DateTime.Now.AddDays(6)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
            calendar.RaiseSpecialDatesChanged();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion

    }
}
