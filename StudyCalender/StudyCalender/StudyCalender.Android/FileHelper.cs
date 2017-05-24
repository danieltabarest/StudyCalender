using System;
using System.IO;
using Xamarin.Forms;
using StudyCalender.Droid;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using System.Threading.Tasks;
using System.Diagnostics;

[assembly: Dependency(typeof(FileHelper))]
namespace StudyCalender.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename); 
        }

        public string SaveFile(string fileName, byte[] imageStream)
        {
            string path = null;
            string imageFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ProductImages");

            //Check if the folder exist or not
            if (!System.IO.Directory.Exists(imageFolderPath))
            {
                System.IO.Directory.CreateDirectory(imageFolderPath);
            }
            string imagefilePath = System.IO.Path.Combine(imageFolderPath, fileName);

            //Try to write the file bytes to the specified location.
            try
            {
                System.IO.File.WriteAllBytes(imagefilePath, imageStream);

                path = imagefilePath;
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return path;
        }

        public void DeleteDirectory()
        {
            string imageFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ProductImages");
            if (System.IO.Directory.Exists(imageFolderPath))
            {
                System.IO.Directory.Delete(imageFolderPath, true);
            }
        }

        public string GetPictureFromDisk(/*int Id*/)
        {

            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, "ProductImages");

            return jpgFilename;
        }

        public string GetPictureFromDisk(string imagename)
        {
            var documentsDirectory = Environment.GetFolderPath
                (Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, imagename + ".png");
            return jpgFilename;
        }


        public async void SavePictureToDisk(ImageSource imgSrc, string photoname)
        {
            try
            {
                var renderer = new StreamImagesourceHandler();
                var photo = await renderer.LoadImageAsync(imgSrc, Forms.Context);
                var documentsDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string pngFilename = System.IO.Path.Combine(documentsDirectory, photoname + ".png");
                using (FileStream fs = new FileStream(pngFilename, FileMode.OpenOrCreate))
                {
                    photo.Compress(Bitmap.CompressFormat.Png, 100, fs);
                }
            }
            catch (Exception ex)
            {
                string exMessageString = ex.Message;
            }
        }

     
    }
}
