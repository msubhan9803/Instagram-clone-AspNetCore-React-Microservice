using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Instagram.Services.User.Extensions;
using Microsoft.AspNetCore.Http;
using BlobInfo = Instagram.Common.DTOs.User.BlobInfo;

namespace Instagram.Services.User.Services
{
    public class ImageBlobService : IImageBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public ImageBlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            BlobContainerClient container = blobServiceClient.GetBlobContainerClient("images");
            container.CreateIfNotExists();
        }

        public async Task<BlobInfo> GetFileAsync(string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClient = containerClient.GetBlobClient(fileName);
            var blobDownloadInfo = await blobClient.DownloadAsync();
            return new BlobInfo(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
        }

        public async Task UploadProfileImageBlobAsync(IFormFile file, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blob = containerClient.GetBlobClient(fileName);

            using(var stream = file.OpenReadStream()) {
                await blob.UploadAsync(stream, new BlobHttpHeaders {ContentType = file.FileName.GetContentType()});
            }
        }
    }
}