using StudyCalender.Core.Helpers;
using StudyCalender.Core.Services;
using StudyCalender.Core.ViewModels;
using StudyCalender.Helpers;
using StudyCalender.Pages;
using StudyCalender.Services;
using StudyCalender.ViewModels;
using StudyCalender.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StudyCalender
{
    public partial class App : Application
    {
        static TodoItemDatabase database;
        public static Action HideLoginView
        {
            get
            {
                return new Action(() => App.Current.MainPage = new LoginPage());
            }
        }

        public static void NavigateToProfile(FacebookResponse profile)
        {

            try
            {
                var profileViewModel = new ProfileViewModel(profile);
                var mainViewModel = MainPageViewModel.GetInstance();
                mainViewModel.Profile = profileViewModel;
                App.Current.MainPage = new ProfilePage();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IReportingService, ReportingService>();
            DependencyService.Register<ViewProvider>();

            RegisterViews();
            var viewProvider = DependencyService.Get<ViewProvider>();
            //MainPage = new MainPage();
            MainPage = viewProvider.GetView(ViewModelProvider.GetViewModel<MainPageViewModel>()) as Page;
            //SetMainPage();

        }
        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }


        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Xamarin.Forms.Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Xamarin.Forms.Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }


        private void RegisterViews()
        {
            var viewProvider = DependencyService.Get<ViewProvider>();
            viewProvider.Register<MainPageViewModel, MainPage>();
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
            //calendar.SpecialDates.Add(new SpecialDate(DateTime.Now.AddDays(5)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
            //calendar.SpecialDates.Add(new SpecialDate(DateTime.Now.AddDays(6)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
            //calendar.RaiseSpecialDatesChanged();
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
