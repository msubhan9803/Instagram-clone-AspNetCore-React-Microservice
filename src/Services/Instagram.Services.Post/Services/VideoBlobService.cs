using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Instagram.Services.Post.Extensions;
using Microsoft.AspNetCore.Http;
using BlobInfo = Instagram.Common.DTOs.Post.BlobInfo;

namespace Instagram.Services.Post.Services
{
    public class VideoBlobService : IVideoBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public VideoBlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            BlobContainerClient container = blobServiceClient.GetBlobContainerClient("videos");
            container.CreateIfNotExists();
        }

        public async Task<BlobInfo> GetBlobAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = containerClient.GetBlobClient(name);
            var blobDownloadInfo = await blobClient.DownloadAsync();
            return new BlobInfo(blobDownloadInfo.Value.Content, blobDownloadInfo.Value.ContentType);
        }

        public async Task<IEnumerable<string>> ListBlobsAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("videos");
            var items = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }

            return items;
        }

        public async Task UploadFileBlobAsync(IFormFile file, string fileNewName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("videos");
            var blob = containerClient.GetBlobClient(fileNewName);

            using(var stream = file.OpenReadStream()) {
                await blob.UploadAsync(stream, new BlobHttpHeaders {ContentType = file.FileName.GetContentType()});
            }
        }
    }
}