using Azure.Storage.Blobs;
using Droos.Model.Models;
using Droos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droos.Repositories
{
    public class BlobStorageRepo : IBlobStorageRepo
    {

        string connectionString = "";
        private BlobContainerClient _blobContainerClient;
        private BlobServiceClient _blobServiceClient;
        private string _storageAccount = "";
        private string _container = "";
        public BlobStorageRepo()
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(_container);
            _blobContainerClient.CreateIfNotExists();
        }
        public async Task<Blob> DownloadAsync(string fileName)
        {
            var file = _blobContainerClient.GetBlobClient(fileName);

            if (await file.ExistsAsync())
            {
                var Content = await file.OpenReadAsync();
                var Downloaded = await file.DownloadContentAsync();

                return new Blob { Content = Content, Name = fileName, Type = Downloaded.Value.Details.ContentType };
            }
            else
            {
                return null;
            }
        }

        public void MoveFileAsync(string fileName, string destinationContainerName)
        {
            var sourceBlobClient = _blobContainerClient.GetBlobClient(fileName);

            var destinationContainerClient = _blobServiceClient.GetBlobContainerClient(destinationContainerName);
            destinationContainerClient.CreateIfNotExists();
            var destinationBlobClient = destinationContainerClient.GetBlobClient(fileName);

            destinationBlobClient.StartCopyFromUriAsync(sourceBlobClient.Uri);

            sourceBlobClient.DeleteIfExistsAsync();
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            try
            {
                var blobClient = _blobContainerClient.GetBlobClient(file.FileName);
                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                return blobClient.Uri.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
