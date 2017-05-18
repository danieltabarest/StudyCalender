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


        //public event PropertyChangedEventHandler PropertyChanged;
        //public void NotifyPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
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