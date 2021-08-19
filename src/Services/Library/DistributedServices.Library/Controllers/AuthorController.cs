using Application.Library.Interfaces.Authors;
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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IEnumerable<AuthorOutput>> Get()
        {
            var result = await _authorService.GetAll();
            return result;
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<AuthorOutput> GetById(int id)
        {
            var result = await _authorService.GetById(id);
            return result;
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<AuthorOutput> Post([FromBody] CreateAuthorInput input)
        {
            var result = await _authorService.Create(input);
            return result;
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
