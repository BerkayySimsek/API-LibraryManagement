namespace LibraryManagement.Services.Abstracts;

public interface ICloudinaryService
{
    string UploadImage(IFormFile formFile, string folderName);
}
