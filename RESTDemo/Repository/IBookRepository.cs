using RESTDemo.Model;

namespace RESTDemo.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        int AddBook(Book book);
        Book GetBookById(int id);
        int UpdateBook(Book book);
        int DeleteBook(int id);
        IEnumerable<Book> GetBookByAuthor(string name);

    }
}
