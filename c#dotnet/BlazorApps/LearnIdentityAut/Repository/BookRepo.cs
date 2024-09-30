using LearnIdentityAut.Data;
using LearnIdentityAut.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnIdentityAut.Repository
{
    public class BookRepo : IBookRepo
    {
        protected readonly ApplicationDbContext dbContext;

        public BookRepo(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public async Task<int> AddBook(BookModel bookModel)
        {
            var AddBook = new Books()
            {
                BookTitle = bookModel.BookTitle,
                Author = bookModel.Author,
                Description = bookModel.Description,
                Category = bookModel.Category,
                Language = bookModel.Language,
                TotalPages = bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value : 0,
                LanguageIDRef = bookModel.LanguageIDRef,
                CreatedOn = DateTime.Now
            };

            await dbContext.Books.AddAsync(AddBook);
            await dbContext.SaveChangesAsync();

            return AddBook.BookID;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            //var ListOfBooks = BookDataSource();
            var ListOfBookModel = new List<BookModel>();
            var ListOfBooks = await dbContext.Books.Include(x => x.LanguageRef).ToListAsync();

            if (ListOfBooks?.Any() == true)
            {
                foreach (var book in ListOfBooks)
                {

                    ListOfBookModel.Add(new BookModel()
                    {
                        BookTitle = book.BookTitle,
                        Author = book.Author,
                        Description = book.Description,
                        Category = book.Category,
                        Language = book.LanguageRef.Name,
                        TotalPages = book.TotalPages,
                        BookID = book.BookID

                    });



                }
            }

            return ListOfBookModel;
        }

        public async Task<BookModel> GetBook(int BookId)
        {
            //return BookDataSource().Where(b => b.BookID == BookId).FirstOrDefault();

            var GetBook0 = await dbContext.Books.FirstOrDefaultAsync(gb => gb.BookID == BookId);
            var GetBook1 = await dbContext.Books.FindAsync(BookId);
            var GetBook2 = await dbContext.Books.Where(gb => gb.BookID == BookId).FirstOrDefaultAsync();
            var GetBook = await dbContext.Books.Where(x => x.BookID == BookId).Include("LanguageRef").
                FirstOrDefaultAsync();

            BookModel GetBookh = new BookModel()
            {
                BookTitle = GetBook0.BookTitle,
                Author = GetBook0.Author,
                Description = GetBook0.Description,
                Category = GetBook0.Category,
                LanguageIDRef = GetBook0.LanguageIDRef,
                Language = GetBook0.LanguageRef.Name,
                TotalPages = GetBook0.TotalPages,
                BookID = GetBook0.BookID
            };
            return GetBookh;
            //if (GetBook != null)
            //{
            //    BookModel BookModelConvrt = new()
            //    {
            //        BookTitle = GetBook.BookTitle,
            //        Author = GetBook.Author,
            //        Description = GetBook.Description,
            //        Category = GetBook.Category,
            //        LanguageIDRef = GetBook.LanguageIDRef,
            //        Language = GetBook.LanguageRef.Name,
            //        TotalPages = GetBook.TotalPages,
            //        BookID = GetBook.BookID
            //    };

            //return GetBook;
            //}

        }


        public async Task<BookModel> EditBook(int BookId)
        {
            var GetBook1 = await dbContext.Books.FindAsync(BookId);
            return null;

        }

        public List<BookModel> SearchBook(string BookTitle, string Author)
        {
            return BookDataSource().Where(b => b.BookTitle.Contains(BookTitle) || b.Author.Contains(Author)).ToList();
        }

        public async Task<List<BookModel>> GetTop3Books(int count)
        {
            //var ListOfBooks = BookDataSource();
            var ListOfBookModel = new List<BookModel>();
            var ListOfBooks = await dbContext.Books.Include(x => x.LanguageRef).Take(count).ToListAsync();

            if (ListOfBooks?.Any() == true)
            {
                foreach (var book in ListOfBooks)
                {

                    ListOfBookModel.Add(new BookModel()
                    {
                        BookTitle = book.BookTitle,
                        Author = book.Author,
                        Description = book.Description,
                        Category = book.Category,
                        Language = book.LanguageRef.Name,
                        TotalPages = book.TotalPages,
                        BookID = book.BookID

                    });
                }
            }

            return ListOfBookModel;
        }

        //DataSource - Generally we will get this from a DataSource
        private List<BookModel> BookDataSource()
        {
            return new List<BookModel>
            {
            new BookModel() { BookID = 1, BookTitle = "Java", Author = "Darren", Description = "This is a Java Book", Category = "Programming" , Language = "English", TotalPages = 500 },
            new BookModel() { BookID = 2, BookTitle = "Dot Net", Author = "Aislinn", Description = "This is a Dot Net Book", Category = "Programming" , Language = "English", TotalPages = 300  },
            new BookModel() { BookID = 3, BookTitle = "Xml", Author = "Darren", Description = "This is a Xml Book", Category = "Programming" , Language = "English", TotalPages = 400  },
            new BookModel() { BookID = 6, BookTitle = "Php", Author = "Denver", Description = "This is a Php Book", Category = "Programming" , Language = "English", TotalPages = 250  },
            new BookModel() { BookID = 7, BookTitle = "Android", Author = "Roque", Description = "This is a Android Book", Category = "Programming" , Language = "English", TotalPages = 600  },
            new BookModel() { BookID = 8, BookTitle = "JSOn", Author = "Luiza", Description = "This is a Json Book", Category = "Programming" , Language = "English", TotalPages = 100  }
        };

        }
    }
}
