using GoogleLogin.Views;
using Plugin.Media;
using StudyCalender.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using System;
using StudyCalender.Pages;
using System.IO;
using System.Threading.Tasks;

namespace StudyCalender
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        TapGestureRecognizer tapSettingsGestureRecognizer;
        List<MasterPageItem> masterPageItems;

        public TapGestureRecognizer TapSettingsGestureRecognizer
        {
            get { return tapSettingsGestureRecognizer; }
        }
        public MasterPage()
        {
            InitializeComponent();

            tapSettingsGestureRecognizer = new TapGestureRecognizer();
            Settings.GestureRecognizers.Add(tapSettingsGestureRecognizer);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {

                try
                {
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                        return;
                    }
                    var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                    {
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    });


                    if (file == null)
                        return;

                    //var stream = file.GetStream();
                    //DependencyService.Get<IFileHelper>().SaveFile("TodoSQLite.db3", ReadFully(stream));

                    image.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        return stream;
                    });

                    DependencyService.Get<IFileHelper>().SavePictureToDisk(image.Source, "profile");

                    //image.Source = ImageSource.FromStream(() => new MemoryStream(ReadFully(stream)));
                    //file.Dispose();

                    await DisplayAlert("Image Save",
                                      "The image has been saved",
                                      "OK");

                    file.Dispose();

                }
                catch (Exception ex)
                {

                    throw;
                }
            };
            image.GestureRecognizers.Add(tapGestureRecognizer);

            masterPageItems = new List<MasterPageItem>();


            masterPageItems.Add(new MasterPageItem
            {
                Title = "Overview",
                IconSource = "ic_home_black_24dp.png",
                TargetType = typeof(Overview)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Agenda",
                IconSource = "ic_assignment_black_24dp.png",
                TargetType = typeof(Agenda)
            });


            masterPageItems.Add(new MasterPageItem
            {
                Title = "Calender",
                IconSource = "ic_format_list_numbered_black_24dp.png",
                TargetType = typeof(CalendarsPage)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Remove ads",
                IconSource = "ic_card_membership_black_24dp.png",
                TargetType = typeof(ReminderPage)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Helps and feedback",
                IconSource = "ic_help_black_24dp.png",
                TargetType = typeof(Feedback)

            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Login",
                IconSource = "ic_help_black_24dp.png",
                TargetType = typeof(LoginFacebookPage)

            });

            listView.ItemsSource = masterPageItems;
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        private async void PhotoCommandExecute(object obj)
        {
            this.IsBusy = true;

            // Show incoming call
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });


            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
            this.IsBusy = false;
        }


        public string GetImage(/*int Id*/)
        {
            string fileName = DependencyService.Get<IFileHelper>()
                .GetPictureFromDisk(/*Id*/);
            return fileName;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            //FileImageSource.FromStream()
            //image.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = System.IO.File.Open(jpgFilename, FileMode.Open);
            //    file.Dispose();
            //    return stream;
            //});
            string fileName = DependencyService.Get<IFileHelper>().GetPictureFromDisk("profile");
            image.Source = ImageSource.FromFile(fileName);
        }
    }
}
