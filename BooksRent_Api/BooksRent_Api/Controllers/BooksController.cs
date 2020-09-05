using System;
using System.Threading.Tasks;
using AutoMapper;
using BooksApi.BusinessEntity.Dto;
using BooksRent_Data.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBook _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public BooksController(IBook repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var book = await _repo.GetBooks();
           
            if (book != null)
                return Ok(book);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _repo.GetBook(id);
            if (book != null)  
               return Ok(book);

            return BadRequest("Error while fetching books");
        }

        [HttpPut]
        public async Task<IActionResult> PutBook([FromBody] BookDto bookDto, int id)
        {

            if (!ModelState.IsValid) 
                return BadRequest("Invalid Params!");

            var book = await _repo.PutBook(bookDto, id);

            if (book != null)
                return Ok(book);

            return BadRequest("Error while updaing book");

        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result =  await _repo.AddBook(bookDto);

            Response<int> response = new Response<int>
            {
                Result = result
            };

            if (result == 1)
                return Ok("Book Added");
            
            if (result == 2)
                return Ok("Book Already Exits");

            return BadRequest("Error while adding book");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Unable to delete book");

            var book = await _repo.DeleteBook(id);

            if (book == true)
                return Ok("Book Removed Successfully");

            return BadRequest("Unable To Delete Book");

        }
    }
}