
using StudyCalender.Core.Helpers;
using StudyCalender.Core.ViewModels;
using StudyCalender.Helpers;
using Xamarin.Forms;

namespace StudyCalender.Pages
{
    public partial class CalendarsPage : ContentPage
    {
     
        public CalendarsPage()
        {
            InitializeComponent();
            BindingContext = ViewModelProvider.GetViewModel<CalendarsViewModel>(vm => vm.Navigator = new Navigator(this));
        }
  
    }
}
