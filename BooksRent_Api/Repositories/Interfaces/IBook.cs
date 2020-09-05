using BooksRentData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.BusinessEntity.Dto;

namespace Repository.Interfaces
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> PutBook(BookDto bookDto, int id);
        Task<bool> AddBook(BookDto bookDto);
        Task<bool> DeleteBook(int id);
    }
}
