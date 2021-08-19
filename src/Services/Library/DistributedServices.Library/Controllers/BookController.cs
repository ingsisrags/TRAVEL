using Application.Library.Interfaces;
using Domain.Library.Configuration.Dtos.Input;
using Domain.Library.Configuration.Dtos.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistributedServices.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        // GET: api/<BookController>

        [HttpGet]
        public async Task<IEnumerable<BookOutput>> Get()
        {
            return await _bookService.GetAll();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<BookOutput> Get(int id)
        {
            return await _bookService.GetById(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<BookOutput> Post([FromBody] CreateBookInput input)
        {
            return await _bookService.Create(input);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
