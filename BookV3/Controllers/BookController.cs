using BookV3.Models;
using BookV3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks(); 
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }

        [HttpPost]
        public async Task<Book> InsertBook([FromBody] Book book)
        {
            return await _bookRepository.InsertBook(book);
        }

        [HttpPut("{id}")]
        public async Task<Book> UpdateBook([FromBody] Book book, int id)
        {
            return await _bookRepository.UpdateBook(book, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(int id)
        {
            await _bookRepository.DeleteBook(id);
        }
    }
}