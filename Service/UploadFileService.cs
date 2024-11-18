using IALClient.Util;

namespace IALClient.Service;

public class UploadFileService
{

    public async Task<(string fileName, string entirePath)> SubmitDocumentUserVehicle(ICollection<IFormFile> images)
    {
        if (images == null || images.Count == 0)
        {
            throw new ArgumentNullException();
        }

        var image = (FormFile) images.First();

        var diretory = Path.Combine(Directory.GetCurrentDirectory(), Utils.FilesFolder);

        if (!Directory.Exists(diretory))
        {
            Directory.CreateDirectory(diretory);
        }

        var entirePath = Path.Combine(diretory, image.FileName);

        await using (FileStream stream = new(entirePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        return (image.FileName, entirePath);
    }

}
