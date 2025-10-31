using LearnIdentityAut.Models;
using LearnIdentityAut.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearnIdentityAut.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepo _BookRepoContext;
        private readonly ILanguageRepo _languageRepo;
        
        public BookController(IBookRepo _bookRepo, ILanguageRepo languageRepo)
        {
            this._BookRepoContext = _bookRepo;
            this._languageRepo = languageRepo;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var ListOfBooks = await _BookRepoContext.GetAllBooks();
            return View(ListOfBooks);
        }

        [Route("book-details/{bookid:int:min(1)}")]
        public async Task<IActionResult> GetBook(int bookid)
        {
            var data = await _BookRepoContext.GetBook(bookid);
            return View(data);
        }

        public List<BookModel> SearchBooks(string BookName, string author)
        {
            

            return _BookRepoContext.SearchBook(BookName, author);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int BookId=0)
        {
            //I can pass the default values on to the Book as well.
           // var book = new BookModel()
            //{
             //   Language = "English"
            //};

            //passing a list of strings from controller to drop down on view
            var listOfLang = new List<string>() { "English", "Hindi", "Marathi"};
            ViewBag.Language1 = new SelectList(new List<string>() { "English", "Hindi", "Marathi" });
            ViewBag.Language2 = new List<SelectListItem>(){
                new SelectListItem() { Text = "English", Value="1"},
                new SelectListItem() { Text = "Hindi", Value="2"},
                new SelectListItem() { Text = "Marathi", Value="3"},
            };
            //Getting the Language from the DataBase
            ViewBag.Language = new SelectList(await _languageRepo.GetAll(),"Id","Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.ID = BookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _BookRepoContext.AddBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, BookId = id });
                }
            }

            ViewBag.Language = new SelectList(await _languageRepo.GetAll(), "Id", "Name");
            //ViewBag.language = new List<string>() { "English", "Hindi", "Marathi" };
            //ViewBag.IsSuccess = false;
            //ViewBag.ID = 0;
            return View();//RedirectToAction(nameof(AddNewBook), new { isSuccess = false, BookId = 0 });
        }

        public async Task<ViewResult> Top3Books()
        {
            return View()
;        }
    }
}
