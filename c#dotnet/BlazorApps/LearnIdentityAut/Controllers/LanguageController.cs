using LearnIdentityAut.Models;
using LearnIdentityAut.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LearnIdentityAut.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageRepo _languageRepo;

        public LanguageController(ILanguageRepo languageRepo)
        {
            this._languageRepo = languageRepo;
        }

        public ViewResult AddNewLanguage(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewlanguage(LanguageModel model)
        {
            if (ModelState.IsValid)
            {
                bool succeed = await _languageRepo.Add(model);
                if (true)
                {
                    return RedirectToAction(nameof(AddNewLanguage),new { isSuccess = true });
                }
            }
            return View();
        }
    }
}
