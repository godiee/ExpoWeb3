using BlobStorage.Logica;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorage.Controllers;

public class BlobStorageController : Controller
{
    private IServiceBlobStorage _serviceBlobStorage;

    public BlobStorageController(IServiceBlobStorage serviceBlobStorage)
    {
        _serviceBlobStorage = serviceBlobStorage;
    }

    public async Task<IActionResult> Index()
    {
        List<string>imagenes = await _serviceBlobStorage.GetBlobAsync();
        return View(imagenes);
    }

    public IActionResult UploadImagen()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadImagen(string nombreImagen, IFormFile imagenBBDD)
    {
        string extension = imagenBBDD.FileName.Split(".")[1];
        string fileName = nombreImagen.Trim() + "." + extension;
        using (Stream stream = imagenBBDD.OpenReadStream())
        {
            await _serviceBlobStorage.UploadBlobAsync(fileName, stream);
        }

        return RedirectToAction("Index");
    }

    public IActionResult Detalles()
    {
        return View();
    }

    public async Task<IActionResult> Delete(string nombre)
    {
        await _serviceBlobStorage.DeleteBlobAsync(nombre);
        return RedirectToAction("Index");
    }
}
