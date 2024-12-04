using Microsoft.EntityFrameworkCore.Migrations.Internal;
using RESTDemo.Data;
using RESTDemo.Model;

namespace RESTDemo.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext db;
        public BookRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddBook(Book book)
        {
            int result;
            db.Books.Add(book);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteBook(int id)
        {
            int result = 0;
            var b = db.Books?.Where(x => x.id == id).FirstOrDefault();
            if (b != null)
            {
                db.Books.Remove(b);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Book> GetBookByAuthor(string name)
        {
            var model = db.Books?.Where(x => x.author.Contains(name)).ToList();
            return model;
        }

        public Book GetBookById(int id)
        {
            return db.Books?.Where(x => x.id == id).FirstOrDefault();
        }

        public IEnumerable<Book> GetBooks()
        {
            return db.Books.ToList();
        }

        public int UpdateBook(Book book)
        {
            int result = 0;
            var b = db.Books?.Where(x => x.id ==book.id).FirstOrDefault();
            if (b != null)
            {
                b.name = book.name;
                b.author = book.author;
                b.price = book.price;
                result = db.SaveChanges();
            }
            return result;

        }
    }
}
