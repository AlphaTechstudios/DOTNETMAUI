using System;
using Foundation;
using QuickLook;

namespace OpenPDF.Platforms.iOS.Helpers
{
	public class QLPreviewItemFileSystem: QLPreviewItem
	{
		string _fileName, _filePath;
		public QLPreviewItemFileSystem(string fileName, string filePath)
		{
			_fileName = fileName;
			_filePath = filePath;
		}

		public override string PreviewItemTitle => _fileName;

        public override NSUrl PreviewItemUrl => NSUrl.FromString(_filePath);

    }
}

