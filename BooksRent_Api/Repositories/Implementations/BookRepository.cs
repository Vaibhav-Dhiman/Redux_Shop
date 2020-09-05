using BooksApi.BusinessEntity.Dto;
using BooksRentData.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksRentRepositories.Implementations
{
    public class BookRepository : IBook
    {
        public Task<bool> AddBook(BookDto bookDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooks()
        {
            throw new NotImplementedException();
        }

        public Task<Book> PutBook(BookDto bookDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
