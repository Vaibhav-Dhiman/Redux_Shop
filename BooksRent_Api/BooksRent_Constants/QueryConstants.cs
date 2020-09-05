using System;
using System.Collections.Generic;
using System.Text;

namespace BooksRent_Constants
{
   public static class QueryConstants
    {
        public static string GetBooks => "SELECT * FROM BOOK WHERE IsDelete = 0";
        public static string DeleteBookById => "UPDATE BOOK SET IsDelete = 1 WHERE Id = @Id";
        public static string GetBookById => "SELECT * FROM BOOK WHERE IsDelete = 0 AND Name = @Name";
    }
}
