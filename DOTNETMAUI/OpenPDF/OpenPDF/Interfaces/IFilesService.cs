using OpenPDF.Domain.Enums;

namespace OpenPDF.Interfaces
{
    public interface IFilesService
    {
        Task SaveAndView(string fileName, MemoryStream stream, OpenOption context, string contentType ="application/pdf");
    }
}