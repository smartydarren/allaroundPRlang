using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
    [AllowAnonymous]
    public class UploadFilesController : Controller
    {
        private IConfiguration Configuration { get; }
        public UploadFilesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }    

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public async Task<IActionResult> UploadFile(IFormFile BindingName)
        {            
            var folderPath = Configuration.GetValue("FileUploadPaths:TestUpload","D:\\files");
            var FileName = BindingName.FileName;
            var cType = BindingName.ContentType;            
            var size = BindingName.Length;
            var FilePath = Path.Combine(folderPath, FileName);

            using(var stream = new FileStream(FilePath, FileMode.Create))
            {               
               await BindingName.CopyToAsync(stream);                
            }

           return RedirectToAction("Index");
        }
    }
}
