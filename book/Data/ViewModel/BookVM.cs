﻿using book.Data.Models;
using book.Data.ViewModel;

namespace book.Data.BookVM
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
        public int Rate { get; set; }
        public DateTime DateRead { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public int PublisherId { get; set; }

        public List<int> AuthorsId { get; set; }

    }
}
