using System;
using OpenPDF.Domain.Enums;
using OpenPDF.Interfaces;
using OpenPDF.Platforms.iOS.Helpers;
using QuickLook;
using UIKit;

namespace OpenPDF.Platforms.iOS.Services
{
	public class FilesService: IFilesService
	{
        public async Task SaveAndView(string fileName, MemoryStream stream, OpenOption context, string contentType = "application/pdf")
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, fileName);

            FileStream fileStream = File.Open(filePath, FileMode.Create);
            stream.Position = 0;

            await stream.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            fileStream.Close();

            UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (currentController.PresentedViewController != null)
                currentController = currentController.PresentedViewController;

            UIView currentView = currentController.View;
            QLPreviewController qLPreview = new QLPreviewController();
            QLPreviewItem item = new QLPreviewItemBundle(fileName, filePath);
            qLPreview.DataSource = new PreviewControllerDS(item);
            currentController.PresentViewController(qLPreview, true, null);
        }
    }
}

