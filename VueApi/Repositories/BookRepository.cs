using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueApi.Models;
using VueApi.Repositories.Interfaces;
using VueApi.Services;

namespace VueApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext _context;

        public BookRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<Book> FindBookAsync(int bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public IEnumerable<Book> GetBooks(int page=1, int per_page=5)
        {
            // Basic pagination...
            int skip = (page - 1) * per_page;

            int total = _context.Books.Count();

            var books = _context.Books
                .OrderBy(b => b.Id)
                .Skip(skip)
                .Take(per_page)
                .ToList();

            return books;
        }

        public Book GetBook(int id)
        {
            var book = _context.Books.Find(id);

            return book;
        }

        public int GetTotalBookCount()
        {
            return _context.Books.Count();
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        public void ModifyBookState(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void AddBookToContext(Book book)
        {
            _context.Books.Add(book);
        }

        public void RemoveBookFromContext(Book book)
        {
            _context.Books.Remove(book);
        }
    }
}
