using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LibraryManagement.Models;
using LibraryManagement.Services.Abstracts;
using Microsoft.Extensions.Options;

namespace LibraryManagement.Services.Concretes;

public class CloudinaryService : ICloudinaryService
{
    private Cloudinary _cloudinary;
    private Account _account;
    private CloudinarySettings _settings;

    public CloudinaryService(IOptions<CloudinarySettings> cloudOptions)
    {
        _settings = cloudOptions.Value;
        _account = new Account(_settings.CloudName, _settings.ApiKey, _settings.ApiSecret);

        _cloudinary = new Cloudinary(_account);

    }
    public string UploadImage(IFormFile formFile, string folderName)
    {
        var imageUploadResult = new ImageUploadResult();

        if (formFile.Length > 0)
        {
            using var stream = formFile.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(formFile.FileName, stream),
                Folder = folderName
            };

            imageUploadResult = _cloudinary.Upload(uploadParams);
            string url = _cloudinary.Api.UrlImgUp.BuildUrl(imageUploadResult.PublicId);

            return url;
        }
        return string.Empty;
    }
}
