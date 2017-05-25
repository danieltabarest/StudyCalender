using StudyCalender.Core.Helpers;
using StudyCalender.Core.Services;
using StudyCalender.Core.ViewModels;
using StudyCalender.Helpers;
using StudyCalender.Models;
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
        static ViewProvider viewProvider;

        #region Attributes
        private DataService dataService;
        private DialogService dialogService;
        private ApiService apiService;
        private NavigationService navigationService;
        #endregion

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
                App.Current.MainPage = new MainPage();
                //navigationService.SetMainPage("MasterPage");//App.Current.MainPage = new ProfilePage();
                /*var parameters = dataService.First<Parameter>(false);
                //var token = await apiService.LoginFacebook(parameters.URLBase, "/api", "/Users",profile);
                object token = null;
                if (token == null)
                {
                    App.Current.MainPage = new LoginPage();
                    return;
                }

                var response = await apiService.GetUserByEmail(parameters.URLBase, "/api", "/Users/GetUserByEmail", token.TokenType, token.AccessToken, token.UserName);

                if (!response.IsSuccess)
                {
                    //IsRunning = false;
                    //IsEnabled = true;
                    await dialogService.ShowMessage("Error", "Problem ocurred retrieving user information, try latter.");
                    return;
                }

                var user = (User)response.Result;
                //user.AccessToken = token.AccessToken;
                //user.TokenType = token.TokenType;
                //user.TokenExpires = token.Expires;
                //user.IsRemembered = IsRemembered;
                //user.Password = Password;
                dataService.DeleteAllAndInsert(user);

                //var mainViewModel = MainPageViewModel.GetInstance();
                mainViewModel.SetCurrentUser(new User());//user);

                navigationService.SetMainPage("MasterPage");
                /*/

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
            viewProvider = DependencyService.Get<ViewProvider>();

            apiService = new ApiService();
            dialogService = new DialogService();
            dataService = new DataService();
            navigationService = new NavigationService();

            LoadParameters();

            var user = dataService.First<User>(false);

            if (user != null && user.IsRemembered && user.TokenExpires > DateTime.Now)
            {
                var mainViewModel = MainPageViewModel.GetInstance();
                mainViewModel.SetCurrentUser(user);
                MainPage = new MasterPage();
            }
            else
            {
                App.Current.MainPage = new LoginPage();
                //MainPage = viewProvider.GetView(ViewModelProvider.GetViewModel<LoginViewModel>()) as Page;
            }


            //MainPage = new MainPage();
            //MainPage = viewProvider.GetView(ViewModelProvider.GetViewModel<MainPageViewModel>()) as Page;
            //SetMainPage();



        }

        private void LoadParameters()
        {
            var urlBase = Application.Current.Resources["URLBase"].ToString();
            var parameter = dataService.First<Parameter>(false);
            if (parameter == null)
            {
                parameter = new Parameter
                {
                    URLBase = urlBase,
                };

                dataService.Insert(parameter);
            }
            else
            {
                parameter.URLBase = urlBase;
                dataService.Update(parameter);
            }
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
        public static bool IsLoggedIn { get; internal set; }

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
            viewProvider.Register<ProfileViewModel, ProfilePage>();
            //viewProvider.Register<LoginViewModel, LoginPage>();
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
