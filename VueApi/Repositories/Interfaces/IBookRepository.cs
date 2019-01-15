using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueApi.Models;

namespace VueApi.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> FindBookAsync(int bookId);
        IEnumerable<Book> GetBooks(int page, int per_page);
        Book GetBook(int bookId);
        int GetTotalBookCount();
        bool BookExists(int id);
        void ModifyBookState(Book book);
        Task SaveChangesAsync();
        void AddBookToContext(Book book);
        void RemoveBookFromContext(Book book);
    }
}
