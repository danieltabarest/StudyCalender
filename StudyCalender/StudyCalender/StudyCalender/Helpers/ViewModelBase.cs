using System;
using StudyCalender.Core.Services;
using System.ComponentModel;

namespace StudyCalender.Core.Helpers
{
    public class ViewModelBase : PropertyChangeNotifier
    {
        #region Dependencies

        public IReportingService ReportingService { get; set; }
        public INavigator Navigator { get; set; }

        #endregion


        public virtual void Initialize() { }


        protected void ReportError(Exception ex)
        {
            if (ReportingService != null)
            {
                ReportingService.ReportException(ex);
            }
        }

        protected void ReportMessage(string message, string details)
        {
            if (ReportingService != null)
            {
                ReportingService.ReportMessage(message, details);
            }
        }
    }
}