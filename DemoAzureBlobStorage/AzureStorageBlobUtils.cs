using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DemoAzureBlobStorage
{
    public class AzureStorageBlobUtils
    {
        private const string ContainerName = "meetupagosto";

        private static CloudBlobClient GetBlobClient()
        {
            // Utilizamos la cuenta de Azure para extraerlo del BLOB.
            var account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StoreSettings"));
            // Creamos el cliente.
            return account.CreateCloudBlobClient();
        }

        public static async Task<string> UploadDocumentToAzure(UploadDocumentAzureRequest request)
        {
            var blobClient = GetBlobClient();

            // Ubicamos el archivo creando la referencia al Contenedor.
            var container = blobClient.GetContainerReference(ContainerName);

            // Si no existe lo creamos.
            await container.CreateIfNotExistsAsync();
            var blob = container.GetBlockBlobReference(request.NombreReferencia);

            await blob.UploadFromFileAsync(request.NombreArchivo);

            return blob.Uri.AbsoluteUri;
        }

        public static async Task<string> DownloadDocument(string blobReference)
        {
            var blobClient = GetBlobClient();

            // Ubicamos el archivo creando la referencia al Contenedor.
            var container = blobClient.GetContainerReference(ContainerName);

            if (!container.Exists())
                throw new InvalidOperationException($"No se encuentra el contenedor {container}");

            var archivo = container.GetBlockBlobReference(blobReference);

            using (var memArchivo = new MemoryStream())
            {
                await archivo.DownloadToStreamAsync(memArchivo);

                return Convert.ToBase64String(memArchivo.ToArray());
            }
        }
    }

    public class UploadDocumentAzureRequest
    {
        public string NombreReferencia { get; set; }
        public string NombreArchivo { get; set; }
    }
}