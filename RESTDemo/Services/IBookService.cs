using RESTDemo.Model;

namespace RESTDemo.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
        int AddBook(Book book);
        Book GetBookById(int id);
        int UpdateBook(Book book);
        int DeleteBook(int id);
        IEnumerable<Book> GetBookByAuthor(string name);
    }
}
