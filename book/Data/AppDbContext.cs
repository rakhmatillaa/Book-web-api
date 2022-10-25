﻿using book.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace book.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}