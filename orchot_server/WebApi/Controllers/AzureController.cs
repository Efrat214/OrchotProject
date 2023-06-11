using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Entity;
using System.Net.Http.Headers;
using Newtonsoft.Json;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureController : ControllerBase
    {
        //conection to azure storage account
        public string blobServiceClientUri1 = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["blobServiceClientUri"];

        //function to upload file
        [HttpPost, DisableRequestSizeLimit]

        public async Task<IActionResult> UploadAsync([FromForm] Upload? data)
        {
            if (data is null || data.FormFile is null)
            {
                return BadRequest("Form data is missing.");
            }

            Upload document = data;
            IFormFile formfile = data.FormFile;
            string containerName = "orchot";
            string pathToAzure = document.Organization + '/' + document.BusinessUnit + '/' + document.Department + '/';
            string fileName = ContentDispositionHeaderValue.Parse(formfile.ContentDisposition).FileName.Trim('"');//.Replace(" ", "_");

            //Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new(blobServiceClientUri1);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            if (containerClient == null)
            {
                containerClient = blobServiceClient.CreateBlobContainer(containerName);
            }

            BlobClient blobClient = containerClient.GetBlobClient(pathToAzure + fileName);
            blobClient.DeleteIfExists();

            //Saving data about the document
            Dictionary<string,string> InitialMetaData = new()
            {
                //{ "Name", document.DocumentName },
                { "CreateBy", document.CreateBy},
                { "DocumentType", document.DocType },
                { "MailAddress", document.MailAddress }
            };

            using (Stream stream = formfile.OpenReadStream())
            {
                try
                {
                    await blobClient.UploadAsync(stream);
                    await blobClient.SetMetadataAsync(InitialMetaData);
                }
                catch (Exception)
                {
                    containerClient = blobServiceClient.CreateBlobContainer(containerName);
                    BlobClient blobClient2 = containerClient.GetBlobClient(pathToAzure + fileName);
                    await blobClient2.DeleteIfExistsAsync();

                    stream.Position = 0;

                    await blobClient.UploadAsync(stream);
                    await blobClient.SetMetadataAsync(InitialMetaData);
                }
            }
            
            var myObject = new { Link = blobClient.Uri.ToString() };
            string jsonString = JsonConvert.SerializeObject(myObject);
            return Content(jsonString, "application/json");
        }

        [HttpDelete]
        public async Task<bool> DeleteFileFromAzure(string url)
        {
            try
            {
                var blobUri = new Uri(url);
                var blobClient = new BlobClient(blobUri);

                await blobClient.DeleteIfExistsAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
