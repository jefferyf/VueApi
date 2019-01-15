﻿using Microsoft.EntityFrameworkCore;
using VueApi.Models;

namespace VueApi.Services
{
    public class BooksDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
