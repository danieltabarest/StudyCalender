using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCalender.Core.Helpers;
using StudyCalender.Core.ViewModels;
using Xamarin.Forms;

namespace StudyCalender.Pages
{
    public partial class CalendarsPage : ContentPage
    {
        public CalendarsPage()
        {
            InitializeComponent();

            //BindingContext = ViewModelProvider.GetViewModel<CalendarsViewModel>(vm => vm.Navigator = new Navigator(this));
        }
    }
}
