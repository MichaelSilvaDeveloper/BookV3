using BookV3.Data;
using BookV3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookV3.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dBContext;

        public BookRepository(BookContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _dBContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            var searchUserById = await _dBContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if(searchUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado n banco de dados");
            return searchUserById;            
        }

        public async Task<Book> InsertBook(Book book)
        {
            await _dBContext.Books.AddAsync(book);
            await _dBContext.SaveChangesAsync();
            return book;        
        }

        public async Task<Book> UpdateBook(Book book, int id)
        {
            var searchUserById = await GetBookById(id);
            if (searchUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado no banco de dados");

            searchUserById.Id = book.Id;
            searchUserById.Author = book.Author;
            searchUserById.Description = book.Description;

            _dBContext.Books.Update(searchUserById);
            await _dBContext.SaveChangesAsync();

            return searchUserById;
        }

        public async Task DeleteBook(int id)
        {
            var searchUserById = await GetBookById(id);
            if (searchUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado no banco de dados");
            _dBContext.Books.Remove(searchUserById);
            await _dBContext.SaveChangesAsync();
        }
    }
}