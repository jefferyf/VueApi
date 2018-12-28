using System.Collections.Generic;
using System.Linq;
using VueApi.Entities;

namespace VueApi.Services
{
    public static class BooksDbContextExtensions
    {
        public static void CreateSeedData(this BooksDbContext context)
        {
            if (context.Books.Any())
                return;

            var books = new List<Book>()
            {
                new Book()
                {
                    Name = "The Heart Is A Lonely Hunter",
                    Year = 1940
                },
                new Book()
                {
                    Name = "Neuromancer",
                    Year = 1984
                },
                new Book()
                {
                    Name = "A Visit From The Goon Squad",
                    Year = 2011
                }
            };

            context.AddRange(books);
            context.SaveChanges();
        }
    }
}
