using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.BusinessEntity.Dto;
using BooksRent_Api.Modals;

namespace Repository.Interfaces
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<Book> PutBook(BookDto bookDto, int id);
        Task<int> AddBook(BookDto bookDto);
        Task<bool> DeleteBook(int id);
    }
}
