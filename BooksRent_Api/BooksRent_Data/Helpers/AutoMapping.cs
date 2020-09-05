using System;
using AutoMapper;
using BooksApi.BusinessEntity.Dto;
using BooksRent_Api.Modals;

namespace BooksApi
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
