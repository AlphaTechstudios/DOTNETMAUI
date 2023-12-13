﻿using System;
using Foundation;
using QuickLook;

namespace OpenPDF.Platforms.iOS.Helpers
{
    public class QLPreviewItemBundle : QLPreviewItem
    {
        private string _fileName, _filePath;
        public QLPreviewItemBundle(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string PreviewItemTitle => _fileName;
        public override NSUrl PreviewItemUrl
        {
            get
            {
                var documents = NSBundle.MainBundle.BundlePath;
                var lib = Path.Combine(documents, _filePath);
                var url = NSUrl.FromFilename(lib);
                return url;
            }
        }
    }
}

