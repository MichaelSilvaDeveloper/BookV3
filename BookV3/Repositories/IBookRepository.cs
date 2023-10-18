using BookV3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookV3.Repositories
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllBooks();

        public Task<Book> GetBookById(int id);

        public Task<Book> InsertBook(Book book);

        public Task<Book> UpdateBook(Book book, int id);

        public Task DeleteBook(int id);
    }
}