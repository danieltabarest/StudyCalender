
using Plugin.Calendars.Abstractions;
using StudyCalender.Core.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StudyCalender
{
    public class GlobalInfo
    {
        public static Application Application;
        public static DateTimeRangeViewModel DateTimeRangeViewModel;
        public static IList<CalendarEvent> Events;
        public static Calendar Calendar;


    }
}
