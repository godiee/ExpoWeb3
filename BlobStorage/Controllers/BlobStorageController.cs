using Azure.Storage.Blobs;
using BlobStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorage.Controllers
{
    public class BlobStorageController : Controller
    {
        public readonly BlobServiceClient _blob;

        public BlobStorageController(BlobServiceClient blob)
        {
            _blob = blob;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<String> Cargar(IFormFile file)
        {
            String mensaje;
            try
            {
                BlobContainerClient contenedor = _blob.GetBlobContainerClient("imagenes");
                await contenedor.UploadBlobAsync(file.FileName, file.OpenReadStream());
                mensaje = "Se Cargo Exitosamente";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            return mensaje;
        }
    }
}
