using Microsoft.Extensions.Logging;
using OpenPDF.Interfaces;

#if ANDROID
using OpenPDF.Platforms.Android.Services;

#elif IOS
using OpenPDF.Platforms.iOS.Services;

#endif

namespace OpenPDF;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif


#if ANDROID
        builder.Services.AddTransient<IFilesService, FilesService>();
#elif IOS
        builder.Services.AddTransient<IFilesService, FilesService>();
#endif
        return builder.Build();
	}
}
