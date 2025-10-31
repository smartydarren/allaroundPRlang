using LearnIdentityAut.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LearnIdentityAut.Components
{
    public class Top3BooksViewComponent : ViewComponent
    {
        private readonly IBookRepo _BookRepoContext;

        public Top3BooksViewComponent(IBookRepo bookRepo)
        {
            this._BookRepoContext = bookRepo;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var top3Books = await _BookRepoContext.GetTop3Books(count);
            return View(top3Books);
        }
    }
}
