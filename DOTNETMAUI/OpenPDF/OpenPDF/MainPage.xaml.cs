using OpenPDF.Interfaces;
using OpenPDF.Platforms.iOS.Services;
namespace OpenPDF;


public partial class MainPage : ContentPage
{
	private IFilesService filesService = new FilesService();
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		HttpClient httpClient = new HttpClient();
		var content = await  httpClient.GetAsync("https://raw.githubusercontent.com/dotnet-architecture/eBooks/main/current/microservices/NET-Microservices-Architecture-for-Containerized-NET-Applications.pdf");
		var stream = new MemoryStream(await content.Content.ReadAsByteArrayAsync());
		 await filesService.SaveAndView("pdfFile.pdf", stream, Domain.Enums.OpenOption.InApp);
			
	}
}

