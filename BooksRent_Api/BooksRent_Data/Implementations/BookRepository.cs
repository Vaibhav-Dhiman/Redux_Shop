using AutoMapper;
using BooksApi.BusinessEntity.Dto;
using BooksRent_Api.Modals;
using BooksRent_Constants;
using BusinessEntity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dapper;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace BooksRentRepositories.Implementations
{
    public class BookRepository : IBook
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private string _connStr;

        public BookRepository(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _connStr = configuration.GetConnectionString("connectionString").ToString();
        }

        public async Task<int> AddBook(BookDto bookDto)
        {
            //var newBook = new Book
            //{
            //    Name = bookDto.Name,
            //    Author = bookDto.Author,
            //    Price = bookDto.Price,
            //    IsDelete = false
            //};
            //var books = await _context.Book.AddAsync(newBook);
            //_context.SaveChanges();
            //return true;

            // check book if already exist .. if not then add new



            using (var connection = new SqlConnection(_connStr))
            {
                var bookExits = await connection.QueryFirstOrDefaultAsync(
                   QueryConstants.GetBookById,
                   new { Name = bookDto.Name }
                   );

                if (bookExits != null)
                    return 2;

                else
                {
                    var bookToAdd = await connection.QueryAsync(
                       SpConstants.ADD_BOOK,
                       new
                       {
                           Name = bookDto.Name,
                           Author = bookDto.Author,
                           Price = bookDto.Price
                       },
                       commandType: CommandType.StoredProcedure);

                    if (bookToAdd != null)
                        return 1;

                    return 0;

                }
            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            //var bookFromRepo = await _context.Book.FirstOrDefaultAsync(x => x.Id == id);
            //bookFromRepo.IsDelete = true;
            //_context.Book.Update(bookFromRepo);
            //_context.SaveChanges();
            //return true;

            using (var connection = new SqlConnection(_connStr))
            {
                var bookToDelete = await connection.QueryFirstOrDefaultAsync(
                    QueryConstants.DeleteBookById,
                    new { Id = id }
                    );

                if (bookToDelete == null)
                    return true;

                return false;
            }
        }

        public async Task<Book> GetBook(int id)
        {
            //var booksFromRepo = await _context.Book.FirstOrDefaultAsync(x=> x.Id == id && x.IsDelete == false);
            //var data = _mapper.Map<Book>(booksFromRepo);
            //return data;


            using (var connection = new SqlConnection(_connStr))
            {
                var booksFromRepo = await connection.QueryFirstOrDefaultAsync(
                    SpConstants.GET_BOOK_BY_ID,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);

                var data = _mapper.Map<Book>(booksFromRepo);
                return data;
            }
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            // below using ef example
            //var booksFromRepo = await _context.Book.Where(x => x.IsDelete == false).ToListAsync();
            //var data = _mapper.Map<List<Book>>(booksFromRepo);
            //return data;
            // to here

            // below using dapper example

            using (var connection = new SqlConnection(_connStr))
            {
                var booksFromRepo = await connection.QueryAsync(QueryConstants.GetBooks);
                var data = _mapper.Map<List<Book>>(booksFromRepo);
                return data;
            }
            // to here

        }

        public async Task<Book> PutBook(BookDto bookDto, int id)
        {
            //var bookFromRepo = await _context.Book.FirstOrDefaultAsync(x => x.Id == id && x.IsDelete == false);
            //bookFromRepo.Name = bookDto.Name;
            //bookFromRepo.Author = bookDto.Author;
            //bookFromRepo.Price = bookDto.Price;
            //_context.Book.Update(bookFromRepo);
            //_context.SaveChanges();

            //var data = _mapper.Map<Book>(bookFromRepo);
            //return data;


            using (var connection = new SqlConnection(_connStr))
            {
                var booksFromRepo = await connection.QueryFirstOrDefaultAsync
                    (QueryConstants.
                    GetBookById,
                    new { Id = id, Name = bookDto.Name }
                    );

                if (booksFromRepo != null)
                {
                    var bookToAdd = await connection.QueryAsync(
                        SpConstants.UPDATE_BOOK,
                        new
                        {
                            Id = id,
                            Name = bookDto.Name,
                            Author = bookDto.Author,
                            Price = bookDto.Price
                        },
                        commandType: CommandType.StoredProcedure);

                    if (bookToAdd != null)
                    {
                        var dataFrmRepo = await connection.QueryFirstOrDefaultAsync(
                       SpConstants.GET_BOOK_BY_ID,
                       new { Id = id },
                       commandType: CommandType.StoredProcedure);

                        var data = _mapper.Map<Book>(dataFrmRepo);
                        return data;
                    }
                }
                return null;
            }
        }
    }
}
