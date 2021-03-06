﻿using StudyCalender.Views;
using System;
using Xamarin.Forms;
using CommonView.Animate;
using Plugin.Messaging;
using StudyCalender.Helpers;

namespace StudyCalender
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;
            masterPage.TapSettingsGestureRecognizer.Tapped += (s, e) =>
            {
                try
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Settings)));
                    masterPage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
                catch (Exception ex)
                {
                    throw;
                }
            };

            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "swap.png";
            }
        }



        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;


            if (item != null)
            {
                if (item.Title == "Helps and feedback")
                {
                    SendEmail();
                    IsPresented = false;
                    return;
                }

                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            var bd = await App.Database.GetItemsAsync();
            //listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        private void SendEmail()
        {
            CrossMessaging.Current.EmailMessenger.SendSampleEmail(false);
        }
    }
}
