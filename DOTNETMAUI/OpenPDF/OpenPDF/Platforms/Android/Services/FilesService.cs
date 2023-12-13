using Android.Content;
using Android.Webkit;
using OpenPDF.Domain.Enums;
using OpenPDF.Interfaces;
using AndroidNet = Android.Net;
using AndroidApplication = Android.App.Application;

namespace OpenPDF.Platforms.Android.Services
{
    public class FilesService : IFilesService
    {
        public async Task SaveAndView(string fileName, MemoryStream stream, OpenOption context, string contentType = "application/pdf")
        {
            string exception = string.Empty;
            string root = null;
            root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Java.IO.File myDir = new Java.IO.File(Path.Combine(root, "OpenPDF"));
            myDir.Mkdir();
            Java.IO.File file = new Java.IO.File(myDir, fileName);
            if (file.Exists())
            {
                file.Delete();
            }
            try
            {
                Java.IO.FileOutputStream outStream = new Java.IO.FileOutputStream(file);
                outStream.Write(stream.ToArray());
                outStream.Flush();
                outStream.Close();
            }
            catch (System.Exception exp)
            {

                exception = exp.ToString();
            }

            if (file.Exists() && contentType != "application/html")
            {

                string extension = MimeTypeMap.GetFileExtensionFromUrl(AndroidNet.Uri.FromFile(file).ToString());
                string mimeType = MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                AndroidNet.Uri path = AndroidX.Core.Content.FileProvider.GetUriForFile(AndroidApplication.Context, $"{AndroidApplication.Context.PackageName}.provider", file);
                intent.SetDataAndType(path, mimeType);
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                switch (context)
                {

                    default:
                    case OpenOption.InApp:
                        AndroidApplication.Context.StartActivity(intent);

                        break;
                    case OpenOption.ChooseApp:

                        var chooseIntent = Intent.CreateChooser(intent, "Choose an application");
                        chooseIntent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);

                        AndroidApplication.Context.StartActivity(intent);
                        break;
                }
                await Task.CompletedTask;
            }
        }
    }
}