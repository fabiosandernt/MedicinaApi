using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task<string> UploadBase64(string base64Image, string conteiner)
        { 
            //Gera um nome randomico do imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            //Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");
            
            //Gera um array de bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            //Define o Blob no qual a imagem será armazenada
            var bobClient = new BlobClient(this.configuration["BlobStorageConnection"], conteiner, fileName);

            //Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                await bobClient.UploadAsync(stream);
            }

            //Retorno a URL da imagem
            return bobClient.Uri.AbsoluteUri;
        }

        //Não utilizar esta metodo
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
