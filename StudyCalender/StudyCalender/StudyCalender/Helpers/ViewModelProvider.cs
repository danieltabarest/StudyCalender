using System;
using StudyCalender.Core.Helpers;
using StudyCalender.Core.Services;
using Xamarin.Forms;

namespace StudyCalender.Core.Helpers
{
    public static class ViewModelProvider
    {
        public static TViewModel GetViewModel<TViewModel>(Action<TViewModel> customInit = null) where TViewModel : ViewModelBase, new()
        {
            var vm = new TViewModel();

            // Satisfy dependencies
            vm.ReportingService = DependencyService.Get<IReportingService>();

            // Allow the caller to include some pre-Initialize configuration
            //
            if (customInit != null)
            {
                customInit(vm);
            }

            vm.Initialize();

            return vm;
        }
    }
}