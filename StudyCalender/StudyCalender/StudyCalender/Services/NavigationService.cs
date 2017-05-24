using StudyCalender.Core.ViewModels;
using StudyCalender.Models;
using StudyCalender.Views;
using System.Threading.Tasks;

namespace StudyCalender.Services
{
    public class NavigationService
    {
        #region Attributes
        //private DataService dataService;
        #endregion

        #region Constructors
        public NavigationService()
        {
          //  dataService = new DataService();
        }
        #endregion

        #region Methods

        public async Task Navigate(string pageName)
        {
            //App.Master.IsPresented = false;
            var mainViewModel = MainPageViewModel.GetInstance();

            switch (pageName)
            {
                case "SelectGroupPage":
                    //await App.Navigator.PushAsync(new SelectGroupPage());
                    break;
                case "SelectTournamentPage":
                    //mainViewModel.SelectTournament = new SelectTournamentViewModel();
                    //await App.Navigator.PushAsync(new SelectTournamentPage());
                    break;
                default:
                    break;
            }
        }

        public void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new MasterPage();
                    break;
                case "LoginPage":
                    Logout();
                    App.Current.MainPage = new LoginPage();
                    break;
                default:
                    break;
            }
        }

        private void Logout()
        {
            //var user = dataService.First<User>(false);
            //if (user != null)
            //{
            //    user.IsRemembered = false;
            //    dataService.Update(user);
            //}
        }

        public async Task Back()
        {
            //await App.Navigator.PopAsync();
        }

        public async Task Clear()
        {
            //await App.Navigator.PopToRootAsync();
        }
        #endregion

    }
}
