using Microsoft.AspNetCore.Mvc;
using Project_FromFile_Image.Models;

namespace Project_FromFile_Image.Controllers
{
    public class FileUploadController : Controller
    {
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(FileUploadDTO model)
        {
            if (model.File != null && model.File.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", model.File.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }
                return RedirectToAction("Upload");
            }
            return View(model);
        }

        public IActionResult UploadSuccess()
        {
            return View();
        }
    }
}
