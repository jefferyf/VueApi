using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueApi.Models;

namespace VueApi.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks(int page, int per_page);
        Book GetBook(int bookId);
        int GetTotalBookCount();
        bool BookExists(int id);
    }
}
