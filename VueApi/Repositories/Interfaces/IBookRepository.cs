using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueApi.Models;

namespace VueApi.Repositories.Interfaces
{
    interface IBookRepository
    {
        IEnumerable<Book> GetBooks(int page, int per_page);
        Book GetBook(int bookId);
    }
}
