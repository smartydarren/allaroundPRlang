using LearnIdentityAut.Models;

namespace LearnIdentityAut.Repository
{
    public interface IBookRepo
    {
        Task<int> AddBook(BookModel bookModel);
        Task<BookModel> EditBook(int BookId);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBook(int BookId);
        Task<List<BookModel>> GetTop3Books(int count);
        List<BookModel> SearchBook(string BookTitle, string Author);
    }
}