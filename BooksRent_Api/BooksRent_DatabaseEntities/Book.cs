﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksRent_Api.Modals
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Author { get; set; }
        public int Price { get; set; }
        public string Url { get; set; }

        public bool IsDelete { get; set; }

    }
}
