using System;
using System.Collections.Generic;
using System.Text;

namespace BooksRent_Data.Helpers
{
    public class Response<TResult>
    {
        public TResult Result { get; set; }
        public string Message { get; set; }
    }
}
