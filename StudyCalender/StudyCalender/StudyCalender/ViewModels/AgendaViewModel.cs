using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace StudyCalender.ViewModels
{
    public class AgendaViewModel : BaseViewModel
    {
        public AgendaViewModel()
        {
            Title = "Agenda";

            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
