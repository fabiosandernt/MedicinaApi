using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Application.AzureBlob
{
    public class AzureBlobStorage
    {
        private readonly IConfiguration configuration;

        public AzureBlobStorage(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> UploadFile(string fileName, Stream buffer, string directory = "")
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(this.configuration["BlobStorageConnection"]);
            BlobContainerClient container = null;           

            if (string.IsNullOrWhiteSpace(directory) == false)
            {
                container = blobServiceClient.GetBlobContainerClient($"images/{directory}");
                await container.UploadBlobAsync(fileName, buffer);
                return $"{this.configuration["BlobStorageBasePath"]}/images/{directory}/{fileName}";
            }

            container = blobServiceClient.GetBlobContainerClient($"images");
            await container.UploadBlobAsync(fileName, buffer);

            return $"{this.configuration["BlobStorageBasePath"]}/images/{fileName}";
        }
    }
}
